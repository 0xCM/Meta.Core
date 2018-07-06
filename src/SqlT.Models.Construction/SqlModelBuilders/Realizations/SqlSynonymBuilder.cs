//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;


    public class SqlSynonymBuilder : SqlModelBuilder<SqlSynonymBuilder, SqlSynonym>
    {
        SqlSynonym Subject;

        internal SqlSynonymBuilder(SqlSynonym Synonym)
            => Subject = Synonym;

        internal SqlSynonymBuilder(SqlSynonymName Name, sxc.ISqlObjectName ReferentName = null)
            => Subject = new SqlSynonym(Name, ReferentName);
        

        public Builder<SqlSynonymBuilder> For(SqlTableName TableName)
            => Step( () => Subject = Subject.For(TableName));
        
        
        public Builder<SqlSynonymBuilder> For(SqlViewName ViewName)
            => Step(() => Subject = Subject.For(ViewName));

        public Builder<SqlSynonymBuilder> For(SqlProcedureName ProcedureName)
            => Step(() => Subject = Subject.For(ProcedureName));

        public Builder<SqlSynonymBuilder> For(SqlFunctionName FunctionName)
            => Step(() => Subject = Subject.For(FunctionName));

        public override SqlSynonym Complete()
            => Subject;
    }


}