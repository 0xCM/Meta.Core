//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;

    using Meta.Core.Messaging;

    using static metacore;

    using C = commands_spec.rmdir;
    using R = commands_spec.rmdir_response;
    using M = ProcessMessage;


    using S = RmDir;
    using X = RmDirX;

    [CommandSpec]
    public sealed class RmDir : ProcessCommandSpec<S, C, R>
    {
        public RmDir()
        {

        }
        public RmDir(C ProcessCommand)
            : base(ProcessCommand)
        {


        }

        

    }

    [CommandPattern]
    class RmDirX : CommandExecutionService<X, S, R>
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


        public RmDirX(IApplicationContext context)
            : base(context)
        {

        }

        protected override Option<R> TryExecute(S spec)
        {
            try
            {
                var process = ProcessAdapter.ExecuteCmd(OnStandard, OnError, Inspect);
                var c = process.rmdir(spec);
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

        static string format(this S spec)
        {
            var command = spec.ProcessCommand;
            var text = $"/S /Q {command.target}";

            return text;
        }

        public static C rmdir(this IProcess broker, S spec)
            => broker.Submit<C>(spec.format());
    }


    partial class commands_spec
    {
        public sealed class rmdir : ProcessCommand<C, R>
        {
            public rmdir()
            { }

            public rmdir(FolderPath target)
            {
                this.target = target;
            }

            internal rmdir(M content)
                : base(content)
            { }


            public override R ok(M content)
                => new R(this, content);

            public override R error(M content)
                => new R(this, content);

            public FolderPath target { get; set; }

        }

        public class rmdir_response : ProcessComandResponse<R, C>
        {
            internal rmdir_response(C command, M content)
                : base(command, content)
            { }
        }

    }
}