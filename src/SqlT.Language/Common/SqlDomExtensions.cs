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
    using System.Text;

    using SqlT.Core;
    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sxc = SqlT.Syntax.contracts;
    
    public static class SqlDomExtensions
    {
        public static int CountColumns(this TSql.CreateTableStatement tsql)
            => tsql.Definition.ColumnDefinitions.Count;

        public static bool IsNullable(this TSql.ColumnDefinition definition)
        {
            var ncd = definition.Constraints.OfType<TSql.NullableConstraintDefinition>().FirstOrDefault();
            return ncd == null ? true : ncd.Nullable;
        }

        public static string FormatName(this TSql.ColumnReferenceExpression tql)
            => tql.MultiPartIdentifier.GetLocalName();

        public static string FormatName(this TSql.ColumnWithSortOrder tql)
            => tql.Column.FormatName();

        public static string TSqlQuote(this string value, TSql.QuoteType type)
        {
            switch (type)
            {
                case TSql.QuoteType.SquareBracket:
                    return $"[{value}]";
                case TSql.QuoteType.DoubleQuote:
                    return enquote(value);
                default:
                    return value;
            }
        }

        public static TSql.SqlScriptGenerator ScriptGenerator(this TSql.SqlVersion version)
        {

            var g = none<TSql.SqlScriptGenerator>();
            var options = new TSql.SqlScriptGeneratorOptions { KeywordCasing = TSql.KeywordCasing.Lowercase };
            switch (version)
            {
                case TSql.SqlVersion.Sql140:
                    g = new TSql.Sql140ScriptGenerator(options);
                    break;
                case TSql.SqlVersion.Sql130:
                    g = new TSql.Sql130ScriptGenerator(options);
                    break;
                case TSql.SqlVersion.Sql120:
                    g = new TSql.Sql120ScriptGenerator(options);
                    break;
                case TSql.SqlVersion.Sql110:
                    g = new TSql.Sql110ScriptGenerator(options);
                    break;
            }
            return g.OnNone(() => throw new NotSupportedException()).ValueOrDefault();
        }

        /// <summary>
        /// Creates a named <see cref="SqlScript"/> based on the fragment's text content
        /// </summary>
        /// <param name="source">The fragment source</param>
        /// <param name="Name">The name of the returned script</param>
        /// <returns></returns>
        public static SqlScript ToNamedScript(this TSql.TSqlFragment source, SqlScriptName Name)
            => new SqlScript(Name, source.GetFragmentText());

        public static string GetFragmentText(this TSql.TSqlFragment source)
        {
            var sb = new StringBuilder();
            switch (source)
            {
                case TSql.StatementList list:
                    iter(list.Statements, item => sb.Append(item.GetFragmentText()));
                    return sb.ToString();

            }

            for (int i = source.FirstTokenIndex; i <= source.LastTokenIndex; i++)
                sb.Append(source.ScriptTokenStream[i].Text);
            return sb.ToString();
        }

        public static string GenerateScript(this TSql.TSqlFragment src, TSql.SqlVersion? sqlVersion = null)
        {
            var generator = (sqlVersion ?? TSql.SqlVersion.Sql130).ScriptGenerator();
            var sql = String.Empty;
            generator.GenerateScript(src, out sql);
            return sql;
        }

        public static bool DropExisting(this TSql.CreateIndexStatement src)
            => src.IndexOptions.OfType<TSql.IndexStateOption>().Any(
                        x => x.OptionKind == TSql.IndexOptionKind.DropExisting && x.OptionState == TSql.OptionState.On);

        public static bool DropExisting(this TSql.CreateColumnStoreIndexStatement src)
            => src.IndexOptions.OfType<TSql.IndexStateOption>().Any(
                        x => x.OptionKind == TSql.IndexOptionKind.DropExisting
                        && x.OptionState == TSql.OptionState.On);

        public static string GetOptionValue(this TSql.CreateSequenceStatement src, TSql.SequenceOptionKind optionKind)
        {
            var option = src.SequenceOptions.OfType<TSql.ScalarExpressionSequenceOption>().FirstOrDefault(x => x.OptionKind == optionKind);
            if (option != null)
                return (option.OptionValue as TSql.Literal).Value;
            else
                return null;
        }

        public static string LiteralValue(this TSql.ValueExpression tsql)
            => (tsql as TSql.StringLiteral).Value;

        public static bool IsStringLiteral(this TSql.ValueExpression tsql)
            => tsql is TSql.StringLiteral;

        public static bool IsIntegerLiteral(this TSql.ValueExpression tsql)
            => tsql is TSql.IntegerLiteral;

        public static Option<CoreDataValue> ToCoreDataValue(this TSql.Literal src)
        {
            switch (src.LiteralType)
            {
                case TSql.LiteralType.Default:
                case TSql.LiteralType.Identifier:
                case TSql.LiteralType.String:
                    return new CoreDataValue(CoreDataTypes.UnicodeTextVariable.CreateReference(), src.Value);
                case TSql.LiteralType.Integer:
                    return new CoreDataValue(CoreDataTypes.Int32.CreateReference(), src.Value);
                case TSql.LiteralType.Numeric:
                case TSql.LiteralType.Money:
                    return new CoreDataValue(CoreDataTypes.Decimal.CreateReference(), src.Value);
                case TSql.LiteralType.Real:
                    return new CoreDataValue(CoreDataTypes.Float64.CreateReference(), src.Value);
                case TSql.LiteralType.Binary:
                    return new CoreDataValue(CoreDataTypes.BinaryVariable.CreateReference(), src.Value);
            }
            return none<CoreDataValue>();
        }

    }
}
