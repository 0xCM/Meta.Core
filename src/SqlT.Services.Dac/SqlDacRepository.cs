//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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