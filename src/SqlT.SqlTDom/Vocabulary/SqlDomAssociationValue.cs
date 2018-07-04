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

    public sealed class SqlDomAssociationValue : SqlDomElementValue<SqlDomAssociationValue, SqlDomAssociation>
    {

        public SqlDomAssociationValue(SqlDomAssociation Member, object SourceValue, SqlDomElementValue ParentElement = null)
            : base(Member, SourceValue, ParentElement)
        {

            this.MemberValues = rolist<SqlDomElementValue>();
        }


        public SqlDomAssociationValue(SqlDomAssociation Member, object SourceValue, IEnumerable<SqlDomElementValue> MemberValues, SqlDomElementValue ParentElement = null)
            : base(Member, SourceValue, ParentElement)
        {

            this.MemberValues = rolist(MemberValues);
        }

       
        public IReadOnlyList<SqlDomElementValue> MemberValues { get; }

        public SqlDomAssociationValue WithMemberValues(IEnumerable<SqlDomElementValue> MemberValues)
            => new SqlDomAssociationValue(Member, SourceValue, MemberValues, ParentElement.ValueOrDefault());

        public override string ToString()
            => $"{Member.MemberName}: {MemberValues}";
    }
}