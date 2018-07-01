//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;

    public class JoinExecutor<X, Y> : ConnectorExecutor<X,Y>, IJoinExecutor<X, Y>
    {
        public JoinExecutor(Func<X, Y> Effector, string Label = null)
            : base(Effector, Label)
        {

        }

    }

}
