//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = Syntax.contracts;

    using static metacore;

    [SqlElementType(SqlElementTypeNames.Synonym)]
    public class SqlSynonym : SqlObject<SqlSynonym>
    {
        public SqlSynonym(SqlSynonymName SynonymName, sxc.ISqlObjectName Referent, 
                IEnumerable<SqlPropertyAttachment> Properties = null, 
                SqlElementDescription Documentation = null)
            : base(SynonymName, Documentation, Properties, true)
        {
            this.Referent = Referent;
        }

        public SqlSynonymName SynonymName
            => (SqlSynonymName)base.ObjectName;
        
        public sxc.ISqlObjectName Referent { get; }

        public override string ToString()
            => $"{SynonymName} for {Referent}";

    }


}
