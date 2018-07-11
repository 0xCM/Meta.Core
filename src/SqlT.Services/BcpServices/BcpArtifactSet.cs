//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    /// <summary>
    /// Describes a collection of BCP-related artifacts
    /// </summary>
    public class SqlBcpArtifactSet
    {
        public SqlBcpArtifactSet(FilePath ExportScript, FilePath FormatScript, FilePath InsertScript, FilePath ImportScript)
        {
            this.ExportScript = ExportScript;
            this.FormatScript = FormatScript;
            this.InsertScript = InsertScript;
            this.ImportScript = ImportScript;
        }

        /// <summary>
        /// The path to the export script
        /// </summary>
        public FilePath ExportScript { get; }

        /// <summary>
        /// The path to the format sript
        /// </summary>
        public FilePath FormatScript { get; }

        /// <summary>
        /// The path to the insert script
        /// </summary>
        public FilePath InsertScript { get; }

        /// <summary>
        /// The path to the import script
        /// </summary>
        public FilePath ImportScript { get; }
    }
}
