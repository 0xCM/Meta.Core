//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;


    using C = commands_spec.msbuild;
    using R = commands_spec.msbuild_response;
    using M = ProcessMessage;
    using S = MsBuildTool;
    using X = MsBuildToolX;

    using static metacore;

    using Meta.Core.Messaging;


    [CommandSpec]
    public sealed class MsBuildTool : ProcessCommandSpec<S, C, R>
    {
        public MsBuildTool()
        {

        }

        public MsBuildTool(C ProcessCommand)
            : base(ProcessCommand)
        {


        }
    }

    [CommandPattern]
    class MsBuildToolX : CommandExecutionService<X, S, R>
    {


        void OnError(MessagePacket packet)
        {
            NotifyError(packet.Payload);
        }

        void OnStandard(MessagePacket packet)
        {
            NotifyStatus(packet.Payload);
        }

        IMessage Inspect(IMessage message)
        {
            Notify(babble($"{message}"));
            return message;

        }


        public MsBuildToolX(IApplicationContext context)
            : base(context)
        {

        }

        protected override Option<R> TryExecute(S spec)
        {
            try
            {
                var process = ProcessAdapter.ExecuteCmd(OnStandard, OnError, Inspect);
                var c = process.msbuild(spec);
                process.WaitForExit();
                return new R(c, c.content);
            }
            catch (Exception e)
            {
                return none<R>(e);
            }
        }

    }


    partial class commands_exec
    {


        public static C msbuild(this IProcess broker, params string[] args)
            => broker.Submit<C>(args);

        public static C msbuild(this IProcess broker, S spec)
            => broker.Submit<C>(spec.Format());

        public static C help(this C command)
            => command.SubmittingProcess.msbuild("/?");
    }


    partial class commands
    {
        public C msbuild(FilePath project, FilePath logPath = null, bool m = true)
        {
            return new C
            {
                project = project,
                logPath = logPath,
                bl = isNotNull(logPath),
                m = m
            };
        }
    }

    partial class commands_spec
    {
        /// <summary>
        /// copies file data
        /// </summary>
        /// <remarks>
        /// See https://technet.microsoft.com/en-us/library/cc733145(v=ws.11).aspx
        /// </remarks>
        public sealed class msbuild : ProcessCommand<C, R>
        {
            public msbuild()
            {
                m = true;
                project = FilePath.Empty;
                logPath = FilePath.Empty;
            }

            internal msbuild(M content)
                : base(content)
            {
                m = true;
            }

            public override R ok(M content)
                => new R(this, content);

            public override R error(M content)
                => new R(this, content);

            [InputArg(0)]
            public FilePath project { get; set; }

            [InputFlag("/m", null, "Builds within a solution are executed concurrently when true")]            
            public bool m { get; set; }

            [InputFlag("/bl:", nameof(logPath), "Emits binary log file when true")]
            public bool bl { get; set; }

            [InputArg("The path to the log file if emitted")]
            public FilePath logPath { get; set; }

            public override string Format()
                => join(space(), stream<object>
                    ( 
                        project,
                        cmdFlag(m, "/m"),
                        cmdFlag(bl, "/bl:", logPath))
                    );
        }

        public class msbuild_response : ProcessComandResponse<R, C>
        {

            internal msbuild_response(C command, M content)
                : base(command, content)
            { }
        }

    }
}