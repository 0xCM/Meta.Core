//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;

    using SqlT.Core;

    /// <summary>
    /// Represents a projection from a source column to a target column
    /// </summary>
    public class SqlColumnProjection
    {


        public SqlColumnProjection()
        {
            ProjectedColumnName = String.Empty;
            SourceTableServer = String.Empty;
            SourceCatalogName = String.Empty;
            SourceTableName = String.Empty;
            SourceTableSchema = String.Empty;
            SourceColumnName = String.Empty;
        }
    

        public string ProjectedColumnName { get; set; }

        public string SourceTableAlias { get; set; }

        public string SourceColumnName { get; set; }

        public string SourceTableServer { get; set; }

        public string SourceCatalogName { get; set; }

        public string SourceTableSchema { get; set; }

        public string SourceTableName { get; set; }

        public SqlObjectName ReferencedTable 
            => new SqlObjectName(SourceTableServer, SourceCatalogName, SourceTableSchema, SourceTableName);

        public override string ToString() =>
            $"{ReferencedTable}.[{SourceColumnName}] => {ProjectedColumnName}";
    }

}
