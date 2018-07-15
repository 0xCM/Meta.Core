//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;


    public class ForkExecutor<S, T1, T2, T> : ForkExecutor<S,T>, IForkExecutor<S,T1,T2>
        where T1 : T
        where T2 : T
    {
        public ForkExecutor(Func<S, T1> F1,  Func<S,T2> F2, string Label = null)
            : base(Label)
        {
            this.F1 = F1;
            this.F2 = F2;
        }

        public Func<S,T1> F1 { get; }

        public Func<S,T2> F2 { get; }


        public override IEnumerable<T> Flow(IEnumerable<S> input)
        {
            foreach (var item in input)
            {
                yield return F1(item);
                yield return F2(item);
            }
        }

    }

}
