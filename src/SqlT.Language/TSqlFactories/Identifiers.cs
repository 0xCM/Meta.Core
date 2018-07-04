//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;
    using SqlT.Language;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {
        public static TSql.MultiPartIdentifier TSqlCompositeIdentifier(this SqlColumnProxySelection src)
        {
            var identifier = new TSql.MultiPartIdentifier();
            if (src.HasSourceAlias)
                identifier.Identifiers.Add(src.SourceAlias.TSqlIdentifier());
            identifier.Identifiers.Add(src.ColumnName.TSqlIdentifier());
            return identifier;
        }

        public static TSql.MultiPartIdentifier TSqlCompositeIdentifier(this SqlColumnName src)
        {
            var identifier = new TSql.MultiPartIdentifier();           
            identifier.Identifiers.Add(src.UnqualifiedName.TSqlIdentifier());
            return identifier;
        }


        public static TSql.MultiPartIdentifier TSqlCompositeIdentifier(this TSql.Identifier src)
        {
            var mpid = new TSql.MultiPartIdentifier();
            mpid.Identifiers.Add(src);
            return mpid;
        }

        [TSqlBuilder]
        public static TSql.Identifier TSqlIdentifier(this string src, bool quoted = true)
            => new TSql.Identifier()
            {
                Value = src,
                QuoteType = quoted 
                    ? TSql.QuoteType.SquareBracket 
                    : TSql.QuoteType.NotQuoted
            };

        [TSqlBuilder]
        public static TSql.Identifier TSqlIdentifier(this ISqlIdentifier src, bool quoted = true)
            => new TSql.Identifier()
            {
                Value = src.ToString(),
                QuoteType = quoted
                    ? TSql.QuoteType.SquareBracket
                    : TSql.QuoteType.NotQuoted
            };


        [TSqlBuilder]
        public static TSql.Identifier TSqlIdentifier(this ISimpleSqlName src, bool quoted = false)
            => src.Identifier.TSqlIdentifier(quoted);

        [TSqlBuilder]
        public static TSql.Identifier TSqlIdentifier(this SqlParameterName src, bool quoted = false)
            => src.UnqualifiedName.TSqlIdentifier(quoted);

        [TSqlBuilder]
        public static TSql.MultiPartIdentifier TSqlCompositeIdentifier(this IEnumerable<string> src, bool quoted = true)
        {
            var dst = new TSql.MultiPartIdentifier();
            src.Iterate(part => dst.Identifiers.Add(part.TSqlIdentifier(quoted)));
            return dst;
        }

        [TSqlBuilder]
        public static TSql.Identifier TSqlIdentifier(this SqlDatabaseName src, bool quoted = true)
            => src.UnqualifiedName.TSqlIdentifier(quoted);


        public static TSql.IdentifierOrValueExpression TSqlIdentifierOrValueExpression(this ISqlIdentifier model, bool quoted = true)
            => new TSql.IdentifierOrValueExpression
            {
                Identifier = model.TSqlIdentifier(quoted)
            };


        [TSqlBuilder]
        public static TSql.IdentifierOrValueExpression TSqlIdentifierOrValueExpression(this SqlDatabaseName model, bool quoted = true)
            => new TSql.IdentifierOrValueExpression
            {
                Identifier = model.TSqlIdentifier(quoted)
            };

        public static TSql.MultiPartIdentifier TSqlMultiPartIdentifier(this string src)
            => src.TSqlIdentifier().TSqlCompositeIdentifier();

        public static TSql.MultiPartIdentifier AsMultiPartIdentifier(this IEnumerable<TSql.Identifier> src)
        {
            var mpid = new TSql.MultiPartIdentifier();
            iter(src, identifier => mpid.Identifiers.Add(identifier));
            return mpid;
        }

    }
}