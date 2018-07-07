//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    public class SqlBcpArtifactSet
    {
        public SqlBcpArtifactSet(FilePath ExportScript, FilePath FormatScript, FilePath InsertScript, FilePath ImportScript)
        {
            this.ExportScript = ExportScript;
            this.FormatScript = FormatScript;
            this.InsertScript = InsertScript;
            this.ImportScript = ImportScript;
        }

        public FilePath ExportScript { get; }

        public FilePath FormatScript { get; }

        public FilePath InsertScript { get; }

        public FilePath ImportScript { get; }
    }
}
