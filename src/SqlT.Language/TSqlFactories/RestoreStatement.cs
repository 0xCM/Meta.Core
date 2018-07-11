//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;    

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
