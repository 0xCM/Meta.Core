//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;    
    using System.Linq;

    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Collections.Concurrent;

    using Modules;

    using static WorkflowMessages;
    using static FlowTypes;
    using static metacore;

    public class FlowExecutor : NodeComponent
    {
        public FlowExecutor(INodeContext C)
            : base(C)
        {

        }

        public Task<Option<FlowSummary>> Execute(IFlowSpec spec, Func<bool> cancel)
        {
            var methods = ClrType.Get(typeof(FlowExecutor)).DeclaredInstanceGenericMethods.AsArray();
            var factory = methods.SingleOrDefault(x => x.Name == nameof(Factory));
            if (factory != null)
            {
                var method = factory.Close(spec.SrcType, spec.DstType);
                return method.InvokeOnHost<Task<Option<FlowSummary>>>(this, spec, cancel);
            }
            else
            {
                return Task.Run(()
                    => none<FlowSummary>(error("No method found")));
            }
        }

        public Option<FlowMetrics> Transfer(IFlowSpec spec)
        {
            var metrics = new FlowMetrics(spec.SrcType.Name, spec.DstType.Name);
            var batchSize = spec.Arguments.ControlSettings.DefaultBatchSize;
            foreach (var source in spec.Sources)
            {
                foreach (var items in source().Stream().Batch(batchSize))
                {
                    try
                    {
                        var selection = Lst.make(items);
                        metrics += new SelectionCount(selection.Count);

                        Notify(inform("Selected a total of @SelectionCount @SourceTypeName records", metrics));

                        var transformed = spec.Projector(selection);
                        var emission = spec.Sink(transformed);
                        if (emission.IsNone())
                        {
                            var Message
                                = emission.Message.IsEmpty
                                ? "Emission failed for Messages unknown"
                                : emission.Message.Format();
                            Notify(error($"Emission failed:{Message}"));
                        }

                        else
                        {
                            metrics += new EmissionCount(emission.Value());
                            Notify(inform("Emission succeeded: A total of @EmissionCount @SourceTypeName records has been emitted thus far", metrics));
                        }
                    }
                    catch (Exception e)
                    {
                        Notify(error(e));
                    }
                }
            }
            return metrics;
        }

        Task<Option<FlowSummary>> Factory<TSrc, TDst>(IFlowSpec<TSrc, TDst> transformation,
            Func<bool> cancel) 
                => Create<TSrc, TDst>(transformation.Arguments.ControlSettings, cancel)(transformation);

        Option<int> Push<TSrc, TDst>(IFlowSpec<TSrc, TDst> wf, ConcurrentQueue<TSrc> Q, int MaxCount)
           => Try(() =>
              {
                  var items = Lst.make(Q.Dequeue(MaxCount));
                  if (items.Count != 0)
                  {
                      var transformed = wf.Projector(items);
                      return wf.Target(transformed);
                  }
                  else
                      return 0;
              });

        Option<FlowMetrics> Pull<TSrc, TDst>(Source<TSrc> source, FlowSettings settings, ConcurrentQueue<TSrc> Q)
        {
            var metrics = new FlowMetrics(typeof(TSrc).Name, typeof(TDst).Name);   
            try
            {
                foreach (var items in source().Stream().Batch(settings.DefaultBatchSize))
                {
                    metrics += new SelectionCount(Q.Enqueue(items));
                    metrics += new QueueLength(Q.Count);

                    Notify(inform(
                        "Selected a total of @SelectionCount @SourceTypeName records bringing queue length to @QueueLength", metrics));

                    var satcount = 0;
                    while (Q.Count >= settings.MaxSourceQueueLength)
                    {
                        if (satcount == 0)
                        {
                            Notify(inform($"@Name queue is saturated with @Count items",
                                new
                                {
                                    typeof(TSrc).Name,
                                    Q.Count
                                }));
                            satcount++;
                        }
                        Task.Delay(settings.PullPause).Wait();
                    }
                }
                return metrics;
            }
            catch (Exception e)
            {
                return none<FlowMetrics>(e);
            }
        }

        /// <summary>
        /// Creates funnel delegate that pulls records from a source and pushes them into a sink
        /// </summary>
        /// <typeparam name="TSrc">The source type</typeparam>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <param name="cancel">Cancellation delegate</param>
        /// <returns></returns>
        FlowTask<TSrc, TDst> Create<TSrc, TDst>(FlowSettings settings, Func<bool> cancel)
            => async (wf) =>
            {
                var Q = new ConcurrentQueue<TSrc>();

                Func<Action, Option<bool>> Try = (f) =>
                {
                    try
                    {
                        f();
                        return some(true);
                    }
                    catch (Exception e)
                    {
                        var message = error(e);
                        Notify(message);
                        return none<bool>(message);
                    }
                };

                var init = Try(() => wf.Initializer(settings));
                if (!init)
                    return none<FlowSummary>(init.Message);

                var pull = Task.Run(() =>
                {
                    var pullMetrics = new FlowMetrics(typeof(TSrc).Name, typeof(TDst).Name);
                    var sw = Stopwatch.StartNew();
                    foreach (var source in wf.Sources)
                    {
                        if (cancel())
                            break;

                        var pullSourceMetrics = Pull<TSrc, TDst>(source, settings, Q);
                        if (pullSourceMetrics)
                            pullMetrics += pullSourceMetrics.ValueOrDefault();
                        else
                            break;
                    }
                    return pullMetrics + sw.Elapsed;
                });

                var push = Task.Run(() =>
                {
                    Notify(ExecutingWorkflow($"{typeof(TSrc).Name} => {typeof(TDst).Name}"));

                    var pushMetrics = new FlowMetrics(typeof(TSrc).Name, typeof(TDst).Name);
                    var sw = stopwatch();
                    var readSize = settings.MaxSourceReadSize;
                    var emission = some(0);
                    for (;;)
                    {

                        if (pull.IsFinished() && Q.Count == 0)
                            break;

                        if (Q.Count == 0)
                        {
                            Task.Delay(settings.PushPause).Wait();
                            continue;
                        }

                        emission = Push(wf, Q, settings.MaxSourceReadSize);
                        Notify(InvokedEmission(emission, typeof(TSrc).Name));
                        if (emission.IsNone())
                            break;

                        pushMetrics += new EmissionCount(emission.Value());
                    }

                    var elapsed = sw.Elapsed;
                    if (elapsed.TotalSeconds > settings.EmitTimeout / 2)
                    {
                        readSize -= readSize / 20;
                    }
                    else
                    {
                        readSize = settings.MaxSourceReadSize;
                    }

                    return pushMetrics + elapsed;
                });

                var srcMetrics = await pull;
                Notify(inform("Selected @SelectionCount @SourceTypeName records", srcMetrics));

                var dstMetrics = await push;
                return some(new FlowSummary($"{typeof(TSrc).Name} => {typeof(TDst).Name}")
                {
                    Metrics = srcMetrics + dstMetrics,
                    ErrorMessages = MutableList.Create<IAppMessage>()
                });
            };
    }
}
