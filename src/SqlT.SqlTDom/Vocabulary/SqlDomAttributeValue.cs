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

    public sealed class SqlDomAttributeValue : SqlDomElementValue<SqlDomAttributeValue, SqlDomAttribute>
    {

        public SqlDomAttributeValue(SqlDomAttribute Member, object Value, SqlDomElementValue ParentElement = null)
            : base(Member, Value, ParentElement)
        {

        }

        public override string ToString()
            => $"{Member.MemberName}: {SourceValue}";

    }




}