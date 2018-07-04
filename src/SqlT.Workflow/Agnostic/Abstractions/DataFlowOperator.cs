//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    /// <summary>
    /// Represents the identity bijection from a spact to itself
    /// </summary>
    /// <typeparam name="T">The space over which the identity is defined</typeparam>
    public abstract class DataFlowOperator<T> : IDataTransformer
    {
        public DataFlowOperator(IDataSource<T> Node, TransformationName Name = null)
        {
            this.Name = Name ?? "F";
            this.Target = new DataTarget<T>(items => { }, Node.Name);
            this.Source = Node;
        }



        public TransformationName Name { get; }

        public IDataSource Source { get; }

        public IDataTarget Target { get; }
    }

}