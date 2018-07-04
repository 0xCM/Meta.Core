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
    using SqlT.Models;
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    partial class TSqlFactory
    {

        static TSql.ColumnReferenceExpression TSqlColumnRef(this SqlColumnName col, string alias = null)
            => new TSql.ColumnReferenceExpression
            {
                MultiPartIdentifier = (alias != null
                ? stream(alias, col.UnqualifiedName)
                : stream(col.UnqualifiedName)).TSqlCompositeIdentifier(false)
            };

        [TSqlBuilder]
        public static TSql.InsertStatement TSqlStatement(this SqlInsertStatement statement)
        {
            var values = new TSql.ValuesInsertSource();
            var rowValue = new TSql.RowValue();
            iter(statement.ColumnAssociations.Select(a => a.TargetColumn),
                c => rowValue.ColumnValues.Add(c.ColumnName.TSqlColumnRef()));
            values.RowValues.Add(rowValue);
            var action = new TSql.InsertStatement
            {
                InsertSpecification = new TSql.InsertSpecification
                {
                    InsertOption = TSql.InsertOption.Into,
                    Target = statement.Target.TSqlRef(),
                    InsertSource = new TSql.SelectInsertSource
                    {
                        Select = statement.Source.TSqlStatement().QueryExpression
                    }
                }
            };
            return action;
        }
    }
}