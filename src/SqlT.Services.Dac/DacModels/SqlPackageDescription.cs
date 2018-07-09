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
    using Meta.Core;

    using SqlT.Core;
    using static SqlT.Syntax.SqlSyntax;
    using static metacore;

    /// <summary>
    /// Summarizes DACPAC content
    /// </summary>
    public class SqlPackageDescription
    {
        public SqlPackageDescription
        ( 
            SqlPackageName PackageName, 
            IEnumerable<SqlPackageReference> References, 
            IEnumerable<sql_cmd_variable> Variables, 
            NodeFilePath PackageLocation = null,
            NodeFilePath AssemblyLocation = null,
            IEnumerable<NodeFilePath> ProfileLocations = null
        )
        {
            this.PackageName = PackageName;
            this.References = References.ToList();
            this.Variables = Variables.ToList();
            this.PackageLocation = PackageLocation;
            this.AssemblyLocation = AssemblyLocation;
            this.ProfileLocations = ProfileLocations?.ToReadOnlyList() ?? rolist<NodeFilePath>();

        }

        /// <summary>
        /// The name of the package
        /// </summary>
        public SqlPackageName PackageName { get; }

        /// <summary>
        /// The other packages referenced by the package
        /// </summary>
        public IReadOnlyList<SqlPackageReference> References { get; }

        /// <summary>
        /// The <see cref="sql_cmd_variable"/> variables required by the package
        /// </summary>
        public IReadOnlyList<sql_cmd_variable> Variables { get; }

        /// <summary>
        /// The location of the package, when specified
        /// </summary>
        public Option<NodeFilePath> PackageLocation { get; }

        /// <summary>
        /// The location of the package assembly, when specified
        /// </summary>
        public Option<NodeFilePath> AssemblyLocation { get; }

        /// <summary>
        /// The location of known profiles, when specified
        /// </summary>
        public IReadOnlyList<NodeFilePath> ProfileLocations { get; }

        public override string ToString()
            => PackageName;
    }


}