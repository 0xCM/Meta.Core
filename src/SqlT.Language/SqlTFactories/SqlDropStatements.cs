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
    using SqlT.Syntax;
    using SqlT.Services;
    using SqlT.Templates;

    using static SqlT.Templates.SqlRestoreDatabase;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using static metacore;

    public static partial class SqlTFactory
    {

        [SqlTBuilder]
        public static Option<SqlDropSequence> Model(this TSql.DropSequenceStatement src)
        {
            if (src.Objects.Count == 1)
            {
                var name = src.Objects.SingleOrDefault();
                if (name != null)
                    return new SqlDropSequence(name.ToSequenceName(), src.IsIfExists);
            }
            return none<SqlDropSequence>();
        }

        [SqlTBuilder]
        public static Option<SqlDropIndex> Model(this TSql.DropIndexStatement src)
        {
            if (src.DropIndexClauses.Count == 1)
            {
                var clause = src.DropIndexClauses.SingleOrDefault() as TSql.DropIndexClause;
                if (clause != null)
                    return new SqlDropIndex(clause.Object.ToTableName(), clause.Index.ToIndexName(), src.IsIfExists);
            }
            return none<SqlDropIndex>();
        }


        [SqlTBuilder]
        public static Option<SqlDropTable> Model(this TSql.DropTableStatement src)
        {
            if (src.Objects.Count == 1)
            {
                var name = src.Objects.SingleOrDefault();
                if (name != null)
                    return new SqlDropTable(name.ToTableName(), src.IsIfExists);
            }
            return none<SqlDropTable>();
        }
    }

}