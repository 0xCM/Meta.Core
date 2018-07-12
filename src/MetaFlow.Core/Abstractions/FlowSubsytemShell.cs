//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;

    public abstract class FlowSubsystemShell<T, A> : FlowApp<T, A>
        where T : FlowSubsystemShell<T, A>, new()
        where A : new()

    {

        protected ISqlRuntimeProvider SqlRuntime { get; }

        protected FlowSubsystemShell(A Args)
            : base(Args)
        {
            Notify(StartMsg);
            SqlRuntime = C.SqlRuntimeProvider();
        }

        protected FlowSubsystemShell()
            : base()
        {
            Notify(StartMsg);
            SqlRuntime = C.SqlRuntimeProvider();
        }

        protected virtual void OnSqlNotification(SqlNotification n)
        {
            Status($"{n}");
        }

        protected IAppMessage StartMsg { get; }
            = inform("Created Application");

  
        protected static string ShellName
            => Assembly.GetEntryAssembly().GetSimpleName();


        void Process(FilePath SrcPath, ICommandSpec Command)
        {
            if (Command is TerminateShell)
            {
                var thisShell = new ShellIdentity(SystemNode.Local.NodeName, Assembly.GetEntryAssembly().GetSimpleName());
                Notify(inform($"{thisShell} has received instruction to commit suicide. Goodbye :/"));
                Shell.PostCommand(Command);
            }

            Notify(inform($"Processing {Command.CommandName} command"));
        }

        ILocalCommandStore InitCommandStore()
        {
            return C.LocalCommandStore(AppStorage("commands"), Process,
                m => Notify(m.IsBabble() ? AppMessage.Empty : m));
        }

        protected virtual bool EnableLocalCommandStore { get; }
            = false;

        void Init()
        {    if(EnableLocalCommandStore)            
                InitCommandStore();
        }

        new protected virtual AppExec OnAppExec(AppExec exec)
        {
            exec.Shell.OnSome(_ => Init());
            exec.ShellTask.OnSome(t => t.Wait());
            return exec;
        }
        protected override Option<AppExec> Execute(A args)
        {
            //iter(SupportedSessions, s => s.RunShellSession());
            return Interactive().Map(exec => OnAppExec(exec));
        
        }


        

    }

}
