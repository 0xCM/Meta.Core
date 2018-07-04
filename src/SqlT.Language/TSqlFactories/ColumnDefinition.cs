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
    using SqlT.Services;

    public static partial class TSqlFactory
    {
        public static TSql.ColumnDefinition TSqlColumnDef(this ISqlColumn model)
        {
            var column = new TSql.ColumnDefinition()
            {
                ColumnIdentifier = model.Name.TSqlIdentifier(true),
                DataType = model.DataTypeReference.TSqlReference(),
            };
            if (model.ComputationExpression)
            {
                column.ComputedColumnExpression = SqlParser.ParseExpression<TSql.ScalarExpression>(~model.ComputationExpression);
                column.IsPersisted = model.ComputationPersisted;
            }
            else
            {
                column.Constraints.Add(new TSql.NullableConstraintDefinition() { Nullable = model.DataTypeReference.nullable });
                if (model.DefaultConstraint)
                {
                    var constraint = ~model.DefaultConstraint;
                    column.DefaultConstraint = new TSql.DefaultConstraintDefinition()
                    {
                        ConstraintIdentifier = constraint.LocalName.TSqlIdentifier(true),
                        Expression = SqlScript.FromText(constraint.DefaultExpression).ParseExpression<TSql.ScalarExpression>()
                    };


                }
            }
            return column;
        }

    }
}