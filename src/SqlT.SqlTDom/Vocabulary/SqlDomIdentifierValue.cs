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


    public struct SqlDomIdentifierComponent
    {
        public SqlDomIdentifierComponent(string ComponentText, bool Quoted)
        {
            this.ComponentText = ComponentText;
            this.Quoted = Quoted;
        }

        public string ComponentText { get; }

        public bool Quoted { get; }

        public override string ToString()
            => Quoted ? bracket(ComponentText) : ComponentText;

    }

    public sealed class SqlDomIdentifierValue : SqlDomElementValue
    {
        public SqlDomIdentifierValue(SqlDomElementMember Member, object SourceValue, SqlDomElementValue ParentElement, IEnumerable<SqlDomIdentifierComponent> Components)
            : base(Member,SourceValue,ParentElement)
        {

            this.Components = ReadOnlyList.Create(Components,".");
        }

        public IReadOnlyList<SqlDomIdentifierComponent> Components { get; }

        public override string ToString()
            => xmlfunc.tag("Identifier", string.Join(".", Components));


    }


}