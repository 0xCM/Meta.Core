//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;

    public class ConnectorExecutor<S, T> : WorkflowExecutor, IConnectorExecutor<S, T>
    {


        public ConnectorExecutor(Func<S, T> Effector, string Label = null)
            : base(Label)
        {

        }


        public Func<S, T> Effector { get; }

        public IEnumerable<T> Flow(IEnumerable<S> input)
        {
            foreach (var item in input)
                yield return Effector(item);
        }
    }

}
