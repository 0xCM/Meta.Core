//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://openData.org/licenses/MIT
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


    public class DataTarget<Y> : DataTarget, IDataTarget<Y>
    {

        public DataTarget(Action<IEnumerable<Y>> Consumer, DataJunctionName Name = null)
            : base(typeof(Y), Name)
        {

            this.Consumer = Consumer;
        }


        Action<IEnumerable<Y>> Consumer { get; }

        protected override void Receive(IEnumerable items)
            => Consumer(items.Cast<Y>());

        protected override void Receive(object item)
            => Consumer(stream((Y)item));

        public virtual void Receive(Y item)
            => Consumer(stream(item));

        public void Receive(IEnumerable<Y> items)
            => Consumer(items);

        public override string ToString()
            => $"{typeof(Y).Name}";

    }


}
