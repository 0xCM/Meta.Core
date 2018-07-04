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


    public sealed class SqlDomAssociation : SqlDomElementMember
    {
        public static SqlDomAssociation FromProperty(ClrProperty DefiningProperty)
            => new SqlDomAssociation(DefiningProperty);

        public SqlDomAssociation(ClrProperty DefiningProperty)
            : base(DefiningProperty, DefiningProperty.PropertyType, SqlDomPropertyKind.Association)
        {
        }

        public override string ToString()
            => $"{MemberName} --> {MemberType.Name}";


    }



}