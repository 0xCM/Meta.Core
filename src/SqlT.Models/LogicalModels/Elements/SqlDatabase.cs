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

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;


    using static SqlT.Syntax.SqlSyntax;

    [SqlElementType(SqlElementTypeNames.Database)]
    public sealed class SqlDatabase : SqlElement<SqlDatabase, SqlDatabaseName>, ISqlDatabase
    {
        
        public SqlDatabase(SqlDatabaseName DatabaseName,
                dboptions DatabaseOptions = null,
                IEnumerable<SqlFileGroup> DataFileGroups = null,
                IEnumerable<SqlFileGroup> LogFileGroups = null,
                IEnumerable<SqlSchema> Schemas = null,
                IEnumerable<ISqlObject> Objects = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                SqlElementDescription Documentation = null,
                SqlCollationName Collation = null
            ) : base(DatabaseName, 
               Properties: Properties, 
               Documentation: Documentation)
        {
            this.DatabaseOptions = DatabaseOptions;
            this.DataFileGroups = rolist(DataFileGroups);
            this.LogFileGroups = rolist(LogFileGroups);
            this.Objects = rolist(Objects);
            this.Schemas = rolist(Schemas);
            this.Collation = Collation;
        }

        public dboptions DatabaseOptions { get; }

        public IReadOnlyList<SqlFileGroup> DataFileGroups { get; }

        public IReadOnlyList<SqlFileGroup> LogFileGroups { get; }

        public IReadOnlyList<ISqlObject> Objects { get; }

        public IReadOnlyList<SqlSchema> Schemas { get; }

        public Option<SqlCollationName> Collation { get; }


        public override string ToString()
            => Name.ToString();

    }



}
