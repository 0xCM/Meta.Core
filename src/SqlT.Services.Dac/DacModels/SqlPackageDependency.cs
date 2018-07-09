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

    using static metacore;

    /// <summary>
    /// Represents a dependency of one sql package on another
    /// </summary>
    public class SqlPackageDependency
    {

        public SqlPackageDependency(SqlPackageName ClientPackage, SqlPackageName SupplierPackage, SqlPackageDependencyKind? DependencyType = null)
        {
            this.ClientPackage = ClientPackage;
            this.SupplierPackage = SupplierPackage;
            this.DependencyType = DependencyType ?? SqlPackageDependencyKind.Unspecified;
        }

        /// <summary>
        /// Identifies the dependent package
        /// </summary>
        public SqlPackageName ClientPackage { get; }

        /// <summary>
        /// Identifies the package on which the client package depends
        /// </summary>
        public SqlPackageName SupplierPackage { get; }

        /// <summary>
        /// Specifies the nature of the dependency
        /// </summary>
        public SqlPackageDependencyKind DependencyType { get; }

        public override string ToString()
            => $"{ClientPackage} --> {SupplierPackage}";
    }


    /// <summary>
    /// Defines a dependency replationship from a consuming package
    /// onto an arbitrary number of supplying pakckages
    /// </summary>
    public class SqlPackageDependencySet
    {
        public SqlPackageDependencySet(SqlPackageName ClientPackage, params SqlPackageDependency[] Dependencies)
        {
            this.ClientPackage = ClientPackage;
            this.Dependencies = Dependencies.ToReadOnlySet();            
        }

        public SqlPackageName ClientPackage { get; }

        public IReadOnlySet<SqlPackageDependency> Dependencies { get; }

        public IEnumerable<SqlPackageName> SupplierPackages
             => Dependencies.Select(x => x.SupplierPackage);

    }

}