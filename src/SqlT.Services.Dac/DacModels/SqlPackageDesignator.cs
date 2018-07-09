//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using Meta.Core;
    using SqlT.Core;
    
    /// <summary>
    /// Identifies a DACPAC that resides in the file system
    /// </summary>
    public class SqlPackageDesignator 
    {

        public static implicit operator FilePath(SqlPackageDesignator d)
            => d.PackagePath;

        public static SqlPackageDesignator Create(NodeFilePath PackagePath)
            => new SqlPackageDesignator(PackagePath);

        public SqlPackageDesignator(NodeFilePath PackagePath)
        {
            this.PackagePath = PackagePath;
            this.PackageName = PackagePath.FileName.RemoveExtension().Value;
        }

        /// <summary>
        /// The path to the package
        /// </summary>
        public NodeFilePath PackagePath { get; }

        /// <summary>
        /// The name of the package
        /// </summary>
        public SqlPackageName PackageName { get; }

        public override string ToString()
            => PackagePath.ToString();

    }
}
