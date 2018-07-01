//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    using System;
    using System.Collections.Generic;

    public abstract class DtoType<T> : IDtoType<T>
        where T : DtoType<T>
    {


        protected DtoType(string TypeName, TypeMembers Members)
        {
            this.TypeName = TypeName;
            this.Members = Members;
        }

        public override string ToString()
            => TypeName;

        public string TypeName { get; }

        public TypeMembers Members { get; }

        IEnumerable<IDtoTypeMember> IDtoType.Members
            => Members;

        object IDtoValueParser.ParseValue(string text)
        {
            throw new NotImplementedException();
        }

        string IDtoValueFormatter.FormatValue(object value)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class DtoType<T, V> : DtoType<T>, IDtoType<T, V>
        where T : DtoType<T, V>
        where V : ITypeValue
    {

        protected DtoType(string TypeName, TypeMembers Members)
            : base(TypeName, Members)
        {

        }

        public abstract V ParseValue(string text);

        public abstract string FormatValue(V value);

    }

}
