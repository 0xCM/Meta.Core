//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    public abstract class DataFlowBuilder<S, T>
        where S : DataSource<S>, new()
        where T : DataTarget<T>, new()
    {

        public DataFlowBuilder(TransformationName DataFlowName)
        {
            this.DataFlowName = DataFlowName;
            this.Source = new S();
            this.Target = new T();
        }

        public TransformationName DataFlowName { get; }

        public S Source { get; }

        public T Target { get; }
    }

}
