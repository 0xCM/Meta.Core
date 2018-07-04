//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;



    public abstract class SqlDomElementMember
    {
        protected SqlDomElementMember(ClrProperty DefiningProperty, ClrType MemberType, SqlDomPropertyKind PropertyType)
        {
            this.DefiningProperty = DefiningProperty;
            this.DeclaringType = DefiningProperty.DeclaringType;
            this.MemberType = MemberType;
            this.PropertyKind = PropertyType;
        }

        public ClrProperty DefiningProperty { get; }

        public ClrType DeclaringType { get; }
            
        public ClrType MemberType { get; }

        public SqlDomPropertyKind PropertyKind { get; }

        public string MemberName
            => DefiningProperty.Name;

        public string ElementName
            => DeclaringType.Name;

        public bool IsReadOnly
            => not(DefiningProperty.HasPublicSetter);

        



        public override string ToString()
            => concat(
                MemberName,
                ":", space(),
                ElementName,
                space(),"-->",space(),                
                PropertyKind == SqlDomPropertyKind.Collection 
                ? $"seq<{MemberType.Name}>" 
                : MemberType.Name
                );

    }

 



}