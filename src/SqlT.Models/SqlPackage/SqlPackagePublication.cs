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
    using Meta.Core;
    using SqlT.Core;
    using System.Collections.Concurrent;

    public class SqlPackagePublication
    {

        public SqlPackagePublication()
        {


        }


        public SqlPackagePublication(NodeFilePath PackagePath, SqlPackageProfile Profile)
        {
            this.PackagePath = PackagePath;
            this.Profile = Profile;
        }

        public SqlPackagePublication(NodeFilePath PackagePath, NodeFilePath ProfilePath)
        {
            this.PackagePath = PackagePath;
            this.SqlProfilePath = ProfilePath;
        }


        public NodeFilePath PackagePath { get; set; }

        public Option<SqlPackageProfile> Profile { get; set; }

        public Option<NodeFilePath> SqlProfilePath { get; set; }


        public override string ToString()
            => PackagePath.AbsolutePath;
    }
}