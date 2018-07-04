//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a node that emits data
    /// </summary>
    public abstract class DataSource : DataJunction, IDataSource
    {

        public DataSource(Type NodeType, DataJunctionName Name = null)
            : base(NodeType, Name)
        {
        }

        protected abstract IEnumerator GetSourceEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetSourceEnumerator();
    }



}
