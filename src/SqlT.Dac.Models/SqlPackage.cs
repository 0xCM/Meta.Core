//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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

    /// <summary>
    /// Defines DACPAC content
    /// </summary>
    /// <typeparam name="T">A concrete subtype</typeparam>
    public abstract class SqlPackage<T> : SqlModel<T>
        where T : SqlPackage<T>
    {
        protected SqlPackage
        (
            SqlPackageName name,
            SemanticVersion packageVersion,
            IEnumerable<ISqlScript> scripts,
            SqlVersion sqlVersion,
            string Description = "",
            dboptions databaseOptions = null,
            sql_cmd_variables commandVariables = null
        )
        {
            this.PackageName = name;
            this.PackageVersion = packageVersion;
            this.Scripts = scripts.ToList();
            this.SqlVersion = sqlVersion;
            this.PackageDescription = Description;
            this.DatabaseOptions = databaseOptions ?? new dboptions();
            this.CommandVariables = commandVariables ?? sql_cmd_variables.Empty;

        }

        /// <summary>
        /// The name of the package
        /// </summary>
        public SqlPackageName PackageName { get; }

        /// <summary>
        /// The package version
        /// </summary>
        public SemanticVersion PackageVersion { get; }

        /// <summary>
        /// The scripts that will be used to construct the dac model content
        /// </summary>
        public IReadOnlyList<ISqlScript> Scripts { get; }

        /// <summary>
        /// The SQL Server version being targeted
        /// </summary>
        public SqlVersion SqlVersion { get; }

        /// <summary>
        /// A brief description of the package content/role
        /// </summary>
        public string PackageDescription { get; }

        /// <summary>
        /// The database-level options that will be encoded
        /// </summary>
        public dboptions DatabaseOptions { get; }

        /// <summary>
        /// A <see cref="sql_cmd_variable"/> collection required for deployment
        /// </summary>
        public sql_cmd_variables CommandVariables { get; }
    }

    /// <summary>
    /// Canonical closure of the <see cref="SqlPackage{T}"/> type
    /// </summary>
    public sealed class SqlPackage : SqlPackage<SqlPackage>
    {

        public SqlPackage(SqlDatabase db, SqlModelScript script)
            : this(new SqlPackageName(db.Name.Identifier), "1.0.0", stream(script), SqlVersions.Latest,db.Documentation.ValueOrDefault(), db.DatabaseOptions)
        { }
        
        public SqlPackage
        (
            SqlPackageName PackageName, 
            SemanticVersion PackageVersion, 
            IEnumerable<ISqlScript> Scripts, 
            SqlVersion SqlVersion, 
            string Description = "",
            dboptions DatabaseOptions = null,
            sql_cmd_variables CommandVariables = null
        ) : base(PackageName, PackageVersion, Scripts, SqlVersion, Description, DatabaseOptions, CommandVariables)
        {

        }
    }
}
