//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Services;
    using Meta.Core;
    using SqlT.Models;

    public class SqlDacRepository : ApplicationComponent, ISqlDacRepository
    {
        IReadOnlyList<SqlPackageDescription> descriptions { get; }

        public SqlDacRepository(IApplicationContext C, NodeFolderPath Location, IEnumerable<SqlPackageDescription> descriptions)
            : base(C)
        {
            this.Location = Location;
            this.descriptions = descriptions.ToList();            
        }

        public NodeFolderPath Location { get; }

        public IEnumerable<SqlPackageDescription> Packages
            => descriptions;
    }

}