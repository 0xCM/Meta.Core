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
    using static metacore;

    /// <summary>
    /// Represents a node that receives data
    /// </summary>
    public abstract class DataTarget : DataJunction, IDataTarget
    {

        public DataTarget(Type NodeType, DataJunctionName Name = null)
            : base(NodeType, Name)
        {
        }



        protected abstract void Receive(object item);

        protected abstract void Receive(IEnumerable items);

        void IDataTarget.Receive(object item)
            => Receive(item);

        void IDataTarget.Receive(IEnumerable items)
            => Receive(items);

    }

}