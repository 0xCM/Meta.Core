//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.Collections.Concurrent;

    using Meta.Core;
    using Meta.Core.Workflow;

    using SqlT.Services;

    using static metacore;

    public class SqlTransformationManager 
        : ApplicationService<SqlTransformationManager, ITransformationManager>,  ITransformationManager
    {


        static IEnumerable<TransformationDescription> GetAntecedents(IReadOnlyDictionary<string, IMutableList<TransformationDescription>> dependencies, string wfname)
        {
            if (dependencies.ContainsKey(wfname))
            {
                foreach (var dependency in dependencies[wfname])
                {
                    yield return dependency;
                    foreach (var antecedent in GetAntecedents(dependencies, dependency.Name))
                        yield return antecedent;
                }
            }
        }

        static IReadOnlyDictionary<string, IEnumerable<TransformationDescription>> GetDependencies(IReadOnlyDictionary<string, TransformationDescription> descriptions)
        {
            var dependencies = new Dictionary<string, IMutableList<TransformationDescription>>();
            foreach (var description in descriptions.Values)
            {
                foreach (var precondition in description.Preconditions)
                {
                    if (!dependencies.ContainsKey(description.Name))
                        dependencies[description.Name] = MutableList.Create<TransformationDescription>();

                    //Note that this allows a missing dependency
                    if (descriptions.ContainsKey(precondition))
                        dependencies[description.Name].Add(descriptions[precondition]);
                }
            }

            var require = new Dictionary<string, IEnumerable<TransformationDescription>>();
            foreach (var description in descriptions.Values)
            {
                require[description.Name] = new HashSet<TransformationDescription>(GetAntecedents(dependencies, description.Name));
            }

            return require;

        }

        public static IEnumerable<TransformationDescription> _DiscoverBuilders(Assembly assembly) 
            => (from attribution in assembly.GetTypeAttributions<WorkflowBuilderAttribute>()
                    select new TransformationDescription(
                    BuilderType: attribution.Key,
                    Name: attribution.Value.WorkflowName,
                    Preconditions: attribution.Value.Preconditions.ToArray()
                        )
                );


        public static IEnumerable<TransformationDescription> DiscoverBuilders(params Assembly[] assemblies) 
            => (from a in assemblies select _DiscoverBuilders(a)).SelectMany(x => x);


        Option<FlowSummary> _RunSequential(IEnumerable<IFlowSpec> workflows)
        {
            try
            {
                var result = default(Option<FlowSummary>);
                foreach (var workflow in workflows)
                {
                    var Option = Run(workflow).Result;
                    if (Option)
                    {
                        result = result.Value() + Option.Value();
                    }
                    else
                    {
                        result = Option;
                        break;
                    }

                }
                _tasksCompleted = true;
                return result;
            }
            catch (Exception e)
            {
                return none<FlowSummary>(e);
            }

        }

        FlowSettings Settings
            => Settings<FlowSettings>();

        Action<IApplicationMessage> Observer { get; }

        MutableList<Task<Option<FlowSummary>>> Tasks { get; }

        Func<bool> IsCancelling { get; }

        bool _cancel = false;
        bool _tasksCompleted = false;

        public SqlTransformationManager(IApplicationContext context)
            : base(context)
        {
            Observer = message => Task.Run(() => Notify(message));
            Tasks = MutableList.Create<Task<Option<FlowSummary>>>();
            IsCancelling = () => _cancel;
        }


        public Task<Option<FlowSummary>> Run(IFlowSpec workflow)
        {
            try
            {
                var executor = new FlowExecutor(C.NodeContext(SystemNode.Local));                
                var task = executor.Execute(workflow, IsCancelling);
                Tasks.Add(task);
                return task;
            }
            catch(Exception e)
            {
                return Task.Run(() => none<FlowSummary>(e));
            }
        }        

        public Option<FlowSummary> RunDirect(IEnumerable<IFlowSpec> workflows)
        {
            foreach (var workflow in workflows)
            {
                var executor = new FlowExecutor(C.NodeContext(SystemNode.Local));
                var result = executor.Execute(workflow,IsCancelling).Result;
                if(result.IsNone())
                {
                    return result;
                }
            }
            return some(new FlowSummary(""));
        }

        public Task<Option<FlowSummary>> RunConcurrent(IEnumerable<IFlowSpec> workflows) 
            => Task.Run(() =>
        {
            try
            {
                var bag = new ConcurrentBag<Task<Option<FlowSummary>>>();
                workflows.AsParallel().ForAll(w => {
                    var task = Run(w);
                    if (task != null)
                        bag.Add(task);
                    });

                Task.WhenAll(bag).Wait();
                _tasksCompleted = true;
                return some(new FlowSummary(""));
            }
            catch (Exception e)
            {
                return none<FlowSummary>(e);
            }
        });

        public Task<Option<FlowSummary>> RunConcurrent(IEnumerable<TransformationDescription> descriptions)
        {
            var builders = descriptions.Map(description =>
                   (ISqlDataFlowBuilder)Activator.CreateInstance(description.BuilderType, Settings));
            foreach (var builder in builders)
                builder.InitializeBuilder();
            return RunConcurrent(builders.BuildTransformations());

        }

        public Task<Option<FlowSummary>> RunSequential(IEnumerable<IFlowSpec> workflows) 
            => Task.Run(() => _RunSequential(workflows));


        protected override void Dispose()
        {
           if(Tasks.Count != 0)
            {
                if(not(_tasksCompleted))
                {
                    Notify(inform("Canceling any outstanding workflows"));
                    _cancel = true;
                    var Options = Task.WhenAll(Tasks).Result;
                    foreach(var Option in Options)
                    {
                        if (Option.IsNone())
                            Notify(Option.Message);
                        else
                        {
                            if(!Option.Message.IsEmpty)
                                Notify(Option.Message);
                        }
                    }
                }
            }

            Notify(inform("All workflows finished"));
            base.Dispose();
        }


        TransformationJob DefineJob(ReadOnlyList<TransformationDescription> descriptions)
            => new TransformationJob(Settings, descriptions);

        public Task<ReadOnlyList<Option<FlowMetrics>>> RunSequential(ReadOnlyList<TransformationDescription> descriptions)
            => C.ExecWorkflowSequence(DefineJob(descriptions), IsCancelling, Observer);




    }
}
