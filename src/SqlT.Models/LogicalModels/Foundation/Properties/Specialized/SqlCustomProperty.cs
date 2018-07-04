//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;

    using static metacore;

    using SqlT.SqlSystem;


    public abstract class SqlCustomProperty<T,V> : ValueObject<T>, ISqlCustomProperty<V>
        where T : SqlCustomProperty<T,V>
    {
        public static implicit operator V(SqlCustomProperty<T,V> p) 
            => p.PropertyValue;

        public SqlCustomProperty(SqlExtendedPropertyName PropertyName, V PropertyValue)
        {
            this.PropertyName = PropertyName;
            this.PropertyValue = PropertyValue;
        }

        public SqlExtendedPropertyName PropertyName { get; }

        public V PropertyValue { get; }

        object ISqlCustomProperty.PropertyValue
            => PropertyValue;

        public override string ToString()
            => $"{PropertyName} = {PropertyValue}";
    }



}
