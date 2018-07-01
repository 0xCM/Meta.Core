//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core.Workflow;

    using static metacore;

    /// <summary>
    /// Base type for workflow-centric applications
    /// </summary>
    /// <typeparam name="T">the derived subtype</typeparam>
    public abstract class WorkflowApp<T> : MetaApp<T>
        where T : WorkflowApp<T>, new()
    {

    }

    /// <summary>
    /// Base type for workflow-centric applications
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    /// <typeparam name="A">The application argument type</typeparam>
    public abstract class WorkfowApp<T, A> : WorkflowApp<T>
        where T : WorkfowApp<T, A>, new()
        where A : new()
    {
        protected A Args;

        protected WorkfowApp()
        {
            Args = new A();
        }

        protected WorkfowApp(A Args)
        {
            this.Args = Args;
        }

        A save(A Args)
        {
            this.Args = Args;
            return this.Args;
        }

        protected abstract AppExec Execute(A args);

        protected override sealed Option<AppExec> Execute(IReadOnlyList<string> args)
        {
            try
            {
                Func<FilePath, A> toObject = path
                    => save(C.JsonSerializer().ObjectFromFile<A>(path));

                Func<FilePath, Option<AppExec>> exec = path
                    => Execute(toObject(path));

                Option<FilePath> jsonConfig = none<FilePath>();
                if (args.Any())
                {
                    var candidiate = FilePath.Parse(args.First());
                    if (candidiate.Exists())
                        jsonConfig = candidiate;
                }
                if (jsonConfig)
                    return AppExec.OK;


                var tries = stream(
                    FilePath.Parse($"{GetType().Name}.json"),
                    FilePath.Parse($"{GetType().Assembly.GetSimpleName()}.exe.json"),
                    FilePath.Parse($"{GetType().Assembly.GetSimpleName()}.json"),
                    FilePath.Parse("App.json"),
                    FilePath.Parse("App.config.json"),
                    FilePath.Parse("Service.json")
                    );

                foreach (var @try in tries)
                {
                    if (@try.Exists())
                    {
                        C.NotifyStatus("Initiating execution");
                        var result = exec(@try);
                        if (!result)
                            C.NotifyError($"Execution failed: {result.Message}");
                        else
                            C.NotifyStatus("Completed execution");
                        return result;

                    }
                }

            }
            catch (Exception e)
            {
                C.NotifyError(e);
            }

            return Execute(Args);
        }
    }

    public abstract class WorkflowApp<H, A, S> : WorkfowApp<H, A>
        where H : WorkflowApp<H, A, S>, new()
        where A : new()

    {
        protected S Service { get; private set; }

        protected ClrInterfaceDescription ServiceDescription { get; }

        protected Option<ClrMethodDescription> DescribeOperation(OperationExecSpec execSpec)
            => ServiceDescription.DescribeOperation(execSpec.OperationName);

        protected void Notify(IOption result)
            => C.Notify(result.Message);

        protected WorkflowApp(A args)
            : base(args)
        {
            this.ServiceDescription = ClrInterfaceDescription.Create<S>();
        }

        protected WorkflowApp()
            : this(new A())
        {

        }

        protected void UseDefaultRealization()
        {
            this.Service = C.Service<S>();
        }


    }

}