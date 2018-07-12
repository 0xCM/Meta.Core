//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    
    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Language;    
    using SqlT.Dom;

    using static metacore;
    using static xmlfunc;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    class SqlXmlSyntaxFormatter : TSql.TSqlConcreteFragmentVisitor, ISqlXmlSyntaxFormatter
    {
        public static ISqlXmlSyntaxFormatter Create(IApplicationContext C)
            => new SqlXmlSyntaxFormatter(C);

        HashSet<TSql.TSqlFragment> Consumed { get; }
            = new HashSet<TSql.TSqlFragment>();

        const char indent_char = '\t';
        int currentLevel = 0;
        StringBuilder buffer = new StringBuilder();


        string Consume<N>(N node, Func<N,string> formatter)
            where N : TSql.TSqlFragment
        {
            if (!Consumed.Contains(node))
            {
                var format = formatter(node);
                Consumed.Add(node);
                return format;
            }
            return string.Empty;
        }

        IApplicationContext C { get; }

        ISqlDomReader DomReader
            => C.SqlDomReader();


        void Notify(IAppMessage message)
            => C.Notify(message);


        SqlDomMetamodel Metamodel { get; }

        public SqlXmlSyntaxFormatter(IApplicationContext C)
        {
            this.C = C;
            this.Metamodel = C.SqlMetamodelSevices().DomMetamodel;
        }

        string offset
            => new string(indent_char, currentLevel);

        void startLine(string content)
            => buffer.Append($"{offset}{content}");

        void endLine(string content)
            => buffer.Append($"{content}{eol()}");

        void appendLine(string content)
            => buffer.Append($"{offset}{content}{eol()}");


        void increment()
            => currentLevel++;

        void decrement()
            => currentLevel--;

        SqlDomTypeDescriptor MetaType(TSql.TSqlFragment node)
            => Metamodel.DomType(node.GetType().Name);


        string Format(TSql.Identifier node)
        {
            if (!Consumed.Contains(node))
                Consumed.Add(node);

            return node.QuoteType != TSql.QuoteType.NotQuoted
           ? bracket(node.Value)
           : node.Value;
        }

        string Format(TSql.MultiPartIdentifier node)
            => Consume(node, n => string.Join(".", map(node.Identifiers, id => Format(id))));

        string Format(TSql.IntegerLiteral node)
            => Consume(node, n =>  n.Value);

        string Format(TSql.StringLiteral node)
            => Consume(node, n =>  squote(n.Value));

        public override void Visit(TSql.IntegerLiteral node)
        {
            if (Consumed.Contains(node))
                return;
           
            var nodeType = MetaType(node);
            increment();
            appendLine(tag(nodeType.ElementName, Format(node)));
            decrement();

            Consumed.Add(node);
        }

        public override void Visit(TSql.StringLiteral node)
        {
            if (Consumed.Contains(node))
                return;

            var nodeType = MetaType(node);
            increment();
            appendLine(tag(nodeType.ElementName, Format(node)));
            decrement();

            Consumed.Add(node);
        }

        public override void Visit(TSql.Identifier node)
        {
            if (Consumed.Contains(node))
                return;

            var nodeType = MetaType(node);
            increment();
            appendLine(tag(nodeType.ElementName, Format(node)));
            decrement();

            Consumed.Add(node);
        }

        public override void Visit(TSql.SchemaObjectName node)
            => Visit(node as TSql.MultiPartIdentifier);


        public override void Visit(TSql.MultiPartIdentifier node)
        {
            if (Consumed.Contains(node))
                return;
           
            var nodeType = MetaType(node);
            increment();
            appendLine(tag(nodeType.ElementName, Format(node)));
            decrement();

            Consumed.Add(node);
            Consumed.AddRange(node.Identifiers);
        }

        void FormatElement(TSql.TSqlFragment node)
        {
            var nodeType = MetaType(node);
            var attributes = join(" ", (from a in DomReader.AttributeValues(node)
                             select  attrib(a.Member.MemberName, a.SourceValue)).ToArray());
            
            appendLine(tagOpen(nodeType.ElementName, ifBlank(attributes,null)));

            foreach(var c in DomReader.CollectionValues(node))
            {
                appendLine(tagOpen(c.Member.MemberName));
                iter(c.Items.Cast<TSql.TSqlFragment>(),  item => item.Accept(this));
                appendLine(tagClose(c.Member.MemberName));
            }

            node.AcceptChildren(this);

            appendLine(tagClose(nodeType.ElementName));

        }
        public override void Visit(TSql.TSqlFragment node)
        {
            if (Consumed.Contains(node))
                return;
            Consumed.Add(node);
            increment();
            FormatElement(node);
            decrement();
        } 

        void Reset()
        {
            buffer = new StringBuilder();
            currentLevel = 0;
            Consumed.Clear();
        }

        Option<TSql.TSqlScript> TryParse(SqlScript sql)
            => TSqlParser.NativeParser().TryParseAny(sql);

        public Option<SqlXmlSyntaxFormat> FormatXmlSyntax(SqlScript SourceScript)
        {
            Reset();

            appendLine($"<TSql>");
            if (!TryParse(SourceScript).OnNone(Notify).OnSome(parsed => parsed.Accept(this)))
                return none<SqlXmlSyntaxFormat>();
            appendLine("</TSql>");
            return new SqlXmlSyntaxFormat(SourceScript, buffer.ToString());
        }
    }
}