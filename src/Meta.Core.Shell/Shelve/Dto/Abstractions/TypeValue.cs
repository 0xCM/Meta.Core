//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    using System;

    public abstract class TypeValue<B, T> : ITypeValue<T>, IEquatable<B>
        where B : TypeValue<B, T>, new()
        where T : IDtoType
    {

        public string TypeName { get; set; }

        public object ModeledValue { get; set; }

        protected TypeValue()
        {


        }

        protected TypeValue(string TypeName, object ModeledValue)
        {
            this.TypeName = TypeName;
            this.ModeledValue = ModeledValue;
        }

        public override string ToString()
            => $"{ModeledValue}";

        protected abstract int Hash();

        public override int GetHashCode()
            => Hash();

        public override bool Equals(object obj)
            => (obj as B)?.Equals(this) ?? false;

        public abstract bool Equals(B other);
    }
}
