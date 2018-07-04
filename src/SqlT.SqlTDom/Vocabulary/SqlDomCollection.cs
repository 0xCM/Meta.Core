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


    public sealed class SqlDomCollection : SqlDomElementMember
    {
        public SqlDomCollection(ClrProperty DefiningProperty, ClrType ElementType)
            : base(DefiningProperty, ElementType, SqlDomPropertyKind.Collection)
        {
        }

        public ClrType ItemType
            => MemberType;

        public override string ToString()
            => spaced(MemberName, "-->", $"seq<{MemberType.Name}>");
            
    }



}