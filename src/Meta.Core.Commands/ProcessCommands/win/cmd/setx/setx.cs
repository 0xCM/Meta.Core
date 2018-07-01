//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;


    using C = commands_spec.setx;
    using R = commands_spec.setx_response;
    using M = ProcessMessage;
    using S = SetX;
    using X = SetXX;

    using static metacore;

    using Meta.Core.Messaging;


    [CommandSpec]
    public sealed class SetX : ProcessCommandSpec<S, C, R>
    {
        public SetX()
        {

        }
        public SetX(C ProcessCommand)
            : base(ProcessCommand)
        {


        }
    }

    [CommandPattern]
    class SetXX : CommandExecutionService<X,S,R>
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


        public SetXX(IApplicationContext context)
            : base(context)
        {
            
        }

        protected override Option<R> TryExecute(S spec)
        {
            try
            {
                var process = ProcessAdapter.ExecuteCmd(OnStandard, OnError, Inspect);
                var c = process.setx(spec);
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

        public static C setx(this IProcess broker, params string[] args)
            => broker.Submit<C>(args);

        public static C setx(this IProcess broker, S spec)
            => broker.Submit<C>(spec.Format());

        public static C help(this C command)
            => command.SubmittingProcess.setx("/?");           
    }

    partial class commands_spec
    {        
        /// <summary>
        /// copies file data
        /// </summary>
        /// <remarks>
        /// See https://technet.microsoft.com/en-us/library/cc733145(v=ws.11).aspx
        /// </remarks>
        public sealed class setx : ProcessCommand<C, R>
        {         
            public setx()
            {

            }

            public setx(EnvironmentVariable variable, string value)
            {
                this.variable = variable;
                this.value = value;
                this.M = variable.IsSystemVariable;
            }

            internal setx(M content)
                : base(content)
            { }

            public override R ok(M content)
                => new R(this, content);

            public override R error(M content)
                => new R(this, content);

            [InputArg(0)]
            public EnvironmentVariable variable { get; set; }

            [InputArg(1)]
            public string value { get; set; }

            [InputFlag]
            public bool M { get; set; }


            public override string Format()
            {
                var text = $"{variable} {value}";
                if (M)
                    text = concat(text, space(), "/", nameof(M));

                return text;

            }



        }

        public class setx_response : ProcessComandResponse<R, C>
        {

            internal setx_response(C command, M content)
                : base(command, content)
            { }
        }

    }
}