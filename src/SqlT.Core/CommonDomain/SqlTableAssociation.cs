//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;

    using Meta.Core;

    public class SqlTableAssociation
    {
        public SqlTableAssociation(SqlTableName SourceTable, SqlTableName TargetTable,
            Seq<SqlColumnAssociation> ColumnAssociations)
        {
            this.SourceTable = SourceTable;
            this.TargetTable = TargetTable;
            this.ColumnAssociations = ColumnAssociations;
        }

        public Lst<SqlColumnAssociation> ColumnAssociations { get; }

        /// <summary>
        /// The client table in the association
        /// </summary>
        public SqlTableName SourceTable { get; }

        /// <summary>
        /// The supplier table in the association
        /// </summary>
        public SqlTableName TargetTable { get; }

        public override string ToString()
        => $"{SourceTable} --> {TargetTable}";


        internal Seq<SqlBulkCopyColumnMapping> ToBcpMappings()
            => this.ColumnAssociations.Select(c => c.ToBcpMapping());

    }
}
