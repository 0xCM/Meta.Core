//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using Meta.Core;
    using SqlT.Core;

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