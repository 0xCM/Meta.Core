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


    public abstract class SqlDomElementValue
    {
        protected SqlDomElementValue(SqlDomElementMember Member, object SourceValue, SqlDomElementValue ParentElement)
        {
            this.SourceValue = SourceValue;
            this.Member = Member;
            this.ParentElement = ParentElement;
           
        }

        public object SourceValue { get; }

        public SqlDomElementMember Member { get; }

        public Option<SqlDomElementValue> ParentElement { get; }

        public override string ToString()
            => $"({Member.MemberName} : {Member.MemberType.Name} = {SourceValue}";

        
             
    }

    public abstract class SqlDomElementValue<V, M> : SqlDomElementValue
       where V : SqlDomElementValue<V, M>
       where M : SqlDomElementMember
    {

        protected SqlDomElementValue(M Member, object Value, SqlDomElementValue ParentElement)
            : base(Member,Value,ParentElement)
        {
            this.Member = Member;            
        }

        public new M Member { get; }

    }


}