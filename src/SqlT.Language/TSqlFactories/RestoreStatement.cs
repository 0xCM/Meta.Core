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
    using SqlT.Templates;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    /// <summary>
    /// Implements translations related to the <see cref="SqlRestoreDatabase"/> action specification
    /// </summary>
    partial class TSqlFactory
    {
        /// <summary>
        /// Hydrates a <see cref="TSql.RestoreStatement"/> from a <see cref="SqlRestoreDatabase"/> model specification
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static TSql.RestoreStatement TSqlStatement(this SqlRestoreDatabase src)
        {
            var statement = new TSql.RestoreStatement
            {
                DatabaseName = src.DatabaseName.TSqlIdentifierOrValueExpression(),
                Kind = TSql.RestoreStatementKind.Database
            };

            statement.Devices.Add(src.SourceFile.TSqlDevice());
            foreach (var movement in src.Movements)
            {
                var option = new TSql.MoveRestoreOption
                {
                    OptionKind = TSql.RestoreOptionKind.Move,
                    LogicalFileName = movement.MoveFrom.TSqlStringLiteral(),
                    OSFileName = movement.MoveTo.TSqlStringLiteral()
                };
                statement.Options.Add(option);
            }

            return statement;
        }
    }
}
