//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
namespace Meta.Core.Workflow
{
    public class GuardExecutor<S, T> : ConnectorExecutor<S, T>
    {
        public GuardExecutor(Func<S, T> F, Func<S, bool> Guard, string Label = null)
            : base(F, Label)
        {
            this.Guard = Guard;
        }

        public Func<S, bool> Guard { get; }
    }

}
