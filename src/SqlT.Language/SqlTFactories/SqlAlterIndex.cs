//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class SqlTFactory
    {
        [SqlTBuilder]
        public static Option<SqlAlterIndex> Model(this TSql.AlterIndexStatement src)
            => new SqlAlterIndex(
                src.OnName.ToTableName(),
                src.Name.ToIndexName(),
                src.AlterIndexType.ModelAlterAction()
                );

        public static SqlAlterIndexAction ModelAlterAction(this TSql.AlterIndexType src)
        {
            var action = SqlAlterIndexAction.None;
            switch (src)
            {
                case TSql.AlterIndexType.Disable:
                    action = SqlAlterIndexAction.Disable; break;
                case TSql.AlterIndexType.Rebuild:
                    action = SqlAlterIndexAction.Rebuild; break;
                case TSql.AlterIndexType.Reorganize:
                    action = SqlAlterIndexAction.Reorganize; break;
            }
            return action;
        }
    }
}