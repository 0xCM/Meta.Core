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

    using static metacore;


    public class SqlPackageDependency
    {

        public SqlPackageDependency(SqlPackageName ClientPackage, SqlPackageName SupplierPackage, SqlPackageDependencyKind? DependencyType = null)
        {
            this.ClientPackage = ClientPackage;
            this.SupplierPackage = SupplierPackage;
            this.DependencyType = DependencyType ?? SqlPackageDependencyKind.Unspecified;
        }

        public SqlPackageName ClientPackage { get; }

        public SqlPackageName SupplierPackage { get; }

        public SqlPackageDependencyKind DependencyType { get; }

        public override string ToString()
            => $"{ClientPackage} --> {SupplierPackage}";

    }

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