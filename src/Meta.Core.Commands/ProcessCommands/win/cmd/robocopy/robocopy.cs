//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;


    using C = commands_spec.robocopy;
    using R = commands_spec.robocopy_response;
    using M = ProcessMessage;
    using S = Robocopy;
    using X = RobocopyX;

    using static metacore;

    using Meta.Core.Messaging;


    [CommandSpec]
    public sealed class Robocopy : ProcessCommandSpec<S, C, R>
    {
        public Robocopy()
        {

        }
        public Robocopy(C ProcessCommand)
            : base(ProcessCommand)
        {


        }

    }

    [CommandPattern]
    class RobocopyX : CommandExecutionService<X,S,R>
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


        public RobocopyX(IApplicationContext context)
            : base(context)
        {
            
        }

        protected override Option<R> TryExecute(S spec)
        {
            try
            {
                var process = ProcessAdapter.ExecuteCmd(OnStandard, OnError, Inspect);
                var c = process.robocopy(spec);
                //process.WaitForExit();
                return new R(c, c.content);
            }
            catch(Exception e)
            {
                return none<R>(e);
            }
        }

    }


    partial class commands_exec
    {

        public static C robocopy(this IProcess broker, params string[] args)
            => broker.Submit<C>(args);

        public static C robocopy(this IProcess broker, S spec)
            => broker.Submit<C>(spec.Format());

        public static C help(this C command)
            => command.SubmittingProcess.robocopy("/?");           
    }

    partial class commands_spec
    {        
        /// <summary>
        /// copies file data
        /// </summary>
        /// <remarks>
        /// See https://technet.microsoft.com/en-us/library/cc733145(v=ws.11).aspx
        /// </remarks>
        public sealed class robocopy : ProcessCommand<C, R>
        {         
            public robocopy()
            {
                this.XF = array<string>();
                this.XD = array<string>();
                this.source = FolderPath.Empty;
                this.target = FolderPath.Empty;
                this.log = FilePath.Empty;

            }

            internal robocopy(M content)
                : base(content)
            {
                this.XF = array<string>();
                this.XD = array<string>();
                this.source = FolderPath.Empty;
                this.target = FolderPath.Empty;
                this.log = FilePath.Empty;

            }

            public override R ok(M content)
                => new R(this, content);

            public override R error(M content)
                => new R(this, content);

            [InputArg(0)]
            public FolderPath source { get; set; }

            [InputArg(1)]
            public FolderPath target { get; set; }

            [InputFlag]
            public bool E { get; set; }

            public string[] XF { get; set; }

            public string[] XD { get; set; }

            public FilePath log { get; set; }

            public override string Format()
            {
                var command = this;
                var text = $"{command.source} {command.target}";
                if (command.E)
                    text = concat(text,
                        space(), "/", nameof(command.E));

                if (command.XF.Length != 0)
                    text = concat(text, space(), "/", nameof(command.XF), space(), join(space(), command.XF));

                if (command.XD.Length != 0)
                    text = concat(text, space(), "/", nameof(command.XD), space(), join(space(), command.XD));

                if (not(log.IsEmpty))
                    text = concat(text, space(), "/tee /", nameof(command.log), "+:", $"{log}");

                return text;
            }

        }

        public class robocopy_response : ProcessComandResponse<R, C>
        {

            internal robocopy_response(C command, M content)
                : base(command, content)
            { }
        }

    }
}