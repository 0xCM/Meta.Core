//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Services;
    using Meta.Core;
    using SqlT.Models;

    /// <summary>
    /// Defines a file-based sql package repository
    /// </summary>
    public class SqlDacRepository : ApplicationComponent, ISqlDacRepository
    {
        public SqlDacRepository(IApplicationContext C, NodeFolderPath Location, 
            Seq<SqlPackageDescription> Packages)
            : base(C)
        {
            this.Location = Location;
            this.Packages = Packages;
        }

        /// <summary>
        /// The repository root folder
        /// </summary>
        public NodeFolderPath Location { get; }
        

        /// <summary>
        /// The packages contained by the respository
        /// </summary>
        public Seq<SqlPackageDescription> Packages { get; }
    }

}