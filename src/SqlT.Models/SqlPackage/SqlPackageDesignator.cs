//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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

        public NodeFilePath PackagePath { get; }

        public SqlPackageName PackageName { get; }

        public override string ToString()
            => PackagePath.ToString();

    }
}
