//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using Meta.Core;

    using SqlT.Core;
    using SqlT.Services;

    using static metacore;

    class FlowApp : ApplicationComponent
    {

        ISystemConsole AppConsole { get; }

        void OnApplicationMessage(IAppMessage Message)
        {
            AppConsole.Write(Message, msg => msg.Format(SystemNode.Local));
        }

        public FlowApp(IApplicationContext C)
            : base(C)
        {
            AppConsole = SystemConsole.Get();

        }

        public IMutableContext ComposeContext(IMutableContext C)
        {
            C.ReplaceService<IMessageBroker>(SqlConnectionString.Local.SqlLogMessageBroker(OnApplicationMessage));
            return C;
        }
    }

    public abstract class FlowApp<T> : MetaApp<T>
        where T : FlowApp<T>, new()
    {
        FlowApp State { get; set; }

        protected override IMutableContext OnContextComposing(IMutableContext C)
        {
            State = new FlowApp(C);
            base.OnContextComposing(C);
            return State.ComposeContext(C);
        }

        protected FlowApp()
        { }

    }

    public abstract class FlowApp<T, A> : MetaApp<T, A>
        where T : FlowApp<T, A>, new()
        where A : new()
    {
        FlowApp State { get; set; }

        protected override IMutableContext OnContextComposing(IMutableContext C)
        {
            State = new FlowApp(C);
            base.OnContextComposing(C);
            return State.ComposeContext(C);

        }

        protected FlowApp()
        { }


        protected FlowApp(A Args)
            : base(Args)
        {
        }
    }
}
