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
