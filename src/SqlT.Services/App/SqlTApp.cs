//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using SqlT.Core;

    using static metacore;

    public abstract class SqlTApp<T> : MetaApp<T>
        where T : SqlTApp<T>, new()
    {

    }

    public abstract class SqlTApp<T, A> : SqlTApp<T>
        where T : SqlTApp<T, A>, new()
        where A : new()
    {
        protected A Args;

        protected SqlTApp()
        {
            Args = new A();
        }

        protected SqlTApp(A Args)
        {
            this.Args = Args;
        }

        A save(A Args)
        {
            this.Args = Args;
            return this.Args;
        }

        protected abstract Option<AppExec> Execute(A args);

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
                    return jsonConfig.MapValueOrDefault(exec);

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
                        try
                        {
                            C.NotifyStatus("Initiating execution");
                            var result = exec(@try);
                            if (!result)
                                C.NotifyError($"Execution failed: {result}");
                            else
                                C.NotifyStatus("Completed execution");
                            return result;
                        }
                        catch(Exception e)
                        {
                            C.NotifyError(e);
                            return AppExec.Error;
                        }

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

    public abstract class SqlTServiceHost<H, A, S> : SqlTApp<H, A>
        where H : SqlTServiceHost<H, A, S>, new()
        where A : new()
    {
        protected S Service { get; private set; }

        protected ClrInterfaceDescription ServiceDescription { get; }

        protected Option<ClrMethodDescription> DescribeOperation(OperationExecSpec execSpec)
            => ServiceDescription.DescribeOperation(execSpec.OperationName);

        protected void Notify(IOption result)
            => C.Notify(result.Message);

        protected SqlTServiceHost(A args)
            : base(args)
        {
            this.ServiceDescription = ClrInterfaceDescription.Create<S>();
        }

        protected SqlTServiceHost()
            : this(new A())
        {

        }

        protected void UseDefaultRealization()
            => this.Service = C.Service<S>();
    }
}