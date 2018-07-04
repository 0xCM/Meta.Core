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