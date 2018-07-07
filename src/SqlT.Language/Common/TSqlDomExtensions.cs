//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;
    using System.Text;

    using SqlT.Core;
    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    
    public static class TSqlDomExtensions
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

        /// <summary>
        /// Creates a named <see cref="SqlScript"/> based on the fragment's text content
        /// </summary>
        /// <param name="source">The fragment source</param>
        /// <param name="Name">The name of the returned script</param>
        /// <returns></returns>
        public static SqlScript ToNamedScript(this TSql.TSqlFragment source, SqlScriptName Name)
            => new SqlScript(Name, source.GetFragmentText());

        /// <summary>
        /// Extracts the fragment text
        /// </summary>
        /// <param name="source">The source fragment</param>
        /// <returns></returns>
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

        /// <summary>
        /// Determines whether a <see cref="TSql.ValueExpression"/> is a <see cref="TSql.StringLiteral"/> specialization
        /// </summary>
        /// <param name="tsql">The expression to evaluate</param>
        /// <returns></returns>
        public static bool IsStringLiteral(this TSql.ValueExpression tsql)
            => tsql is TSql.StringLiteral;

        /// <summary>
        /// Determines whether a <see cref="TSql.ValueExpression"/> is a <see cref="TSql.IntegerLiteral"/> specialization
        /// </summary>
        /// <param name="tsql">The expression to evaluate</param>
        /// <returns></returns>
        public static bool IsIntegerLiteral(this TSql.ValueExpression tsql)
            => tsql is TSql.IntegerLiteral;

        /// <summary>
        /// Converts a <see cref="TSql.Literal> value to a <see cref="CoreDataValue"/> if possible; 
        /// otherwise, returns None
        /// </summary>
        /// <param name="src">The literal value to convert</param>
        /// <returns></returns>
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
