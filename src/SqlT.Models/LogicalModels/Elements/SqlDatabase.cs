//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using static SqlT.Syntax.SqlSyntax;
    using sxc = SqlT.Syntax.contracts;

    [SqlElementType(SqlElementTypeNames.Database)]
    public sealed class SqlDatabase : SqlElement<SqlDatabase, SqlDatabaseName>
    {
        
        public SqlDatabase(SqlDatabaseName DatabaseName,
                dboptions DatabaseOptions = null,
                Seq<SqlFileGroup>? DataFileGroups = null,
                Seq<SqlFileGroup>? LogFileGroups = null,
                Seq<SqlSchema>? Schemas = null,
                Seq<sxc.sql_object>? Objects = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                SqlElementDescription Documentation = null,
                SqlCollationName Collation = null
            ) : base(DatabaseName, Properties: Properties, Documentation: Documentation)
        {
            this.DatabaseOptions = DatabaseOptions;
            this.DataFileGroups = DataFileGroups ?? seq<SqlFileGroup>();
            this.LogFileGroups = LogFileGroups ?? seq<SqlFileGroup>();
            this.Objects = Objects ?? seq<sxc.sql_object>();
            this.Schemas = Schemas ?? seq<SqlSchema>();
            this.Collation = Collation;
        }

        public dboptions DatabaseOptions { get; }

        public Lst<SqlFileGroup> DataFileGroups { get; }

        public Lst<SqlFileGroup> LogFileGroups { get; }

        public Lst<sxc.sql_object> Objects { get; }

        public Lst<SqlSchema> Schemas { get; }

        public Option<SqlCollationName> Collation { get; }

        public override string ToString()
            => Name.ToString();

    }



}
