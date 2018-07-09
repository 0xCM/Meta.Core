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