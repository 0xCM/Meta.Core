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

    using static metacore;


    public class DataSource<X> : DataSource, IDataSource<X>
    {

        public DataSource(Func<IEnumerable<X>> Producer, DataJunctionName Name = null)
            : base(typeof(X), Name)
        {
            this.Producer = Producer;

        }
        
        Func<IEnumerable<X>> Producer { get; }


        public override string ToString()
            => $"{typeof(X).Name}";


        IEnumerable<X> Enumerate()
            => Producer();

        protected override IEnumerator GetSourceEnumerator()
            => Enumerate().GetEnumerator();

        public IEnumerator<X> GetEnumerator()
            => Enumerate().GetEnumerator();
    }


}
