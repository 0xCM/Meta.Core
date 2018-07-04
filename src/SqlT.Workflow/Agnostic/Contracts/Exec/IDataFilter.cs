//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{

    using System.Collections.Generic;

    public interface IDataFilter : IDataFlowOperator
    {
        
    }


    public interface IDataFilter<T> : IDataFilter, IDataFlowOperator<T>
    {
        IEnumerable<T> Apply(IEnumerable<T> src);
    }


}
