//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using static metacore;


    public abstract class EvaluatedProperties<E> : IEnumerable<PropertyEvaluation>
    {
        IReadOnlyDictionary<string, ReadOnlyList<PropertyEvaluation>> PropertyValues { get; }

        protected Option<PropertyEvaluation> GetProperty([CallerMemberName] string PropertyName = null)
            => PropertyValues.TryFind(PropertyName).Map(x => x.FirstOrDefault());

        public IEnumerator<PropertyEvaluation> GetEnumerator()
            => PropertyValues.Values.SelectMany(x => x).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        protected EvaluatedProperties(IEnumerable<PropertyEvaluation> PropertyValues)
        {
            this.PropertyValues = PropertyValues.GroupBy(x => x.PropertyName).ToDictionary(x => x.Key, x => x.ToReadOnlyList());
        }

    }


}