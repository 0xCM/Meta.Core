//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Data;

    using static metacore;

    /// <summary>
    /// Encapsulates the result of executing a scalar expression/function
    /// </summary>
    /// <typeparam name="V">The scalar type</typeparam>
    /// <remarks>
    /// Note that Success = True paired with a no-valued scalar is possible
    /// </remarks>
    public struct ScalarResult<V>
    {
        public ScalarResult(bool Succeeded, Option<V> ScalarValue)
        {
            this.Succeeded = Succeeded;
            this.ScalarValue = ScalarValue;
        }


        public Option<V> ScalarValue { get; }

        public bool Succeeded { get; }

        public bool HasValue
            => Succeeded 
            ? ScalarValue.IsSome() 
            : false;

        public override string ToString()
            => Succeeded 
            ? toString(ScalarValue.ValueOrDefault()) 
            : ScalarValue.Message.Format(false);

        public Option<X> TryMapValue<X>(Func<V, X> f)
            => HasValue 
            ? ScalarValue.Map(f)
            : ScalarValue.ToNone<X>();
    }
}