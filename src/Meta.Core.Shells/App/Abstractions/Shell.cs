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

    using static metacore;

    public abstract class Shell<A,S> : MetaApp<A>
        where A : Shell<A,S>, new()
        where S : NodeSession<S>
    {

        S Session { get; }

        public Shell()
        {
            Session = (S)Activator.CreateInstance(typeof(S), C.NodeContext(SystemNode.Local));  //new AppSession(C.NodeContext(SystemNode.Local));

        }

        protected override IEnumerable<IShellSession> SupportedSessions
            => stream(Session);


    }


}