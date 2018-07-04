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

    /// <summary>
    /// See https://msdn.microsoft.com/en-us/library/ms189493.aspx
    /// </summary>
    public class SqlShrinkFileResult
    {
        /// <summary>
        /// Database identification number of the file the Database Engine tried to shrink.
        /// </summary>
        public int DbId { get; set; }

        /// <summary>
        /// The file identification number of the file the Database Engine tried to shrink.
        /// </summary>
        public int FileId { get; set; }

        /// <summary>
        /// Number of 8-KB pages the file currently occupies.
        /// </summary>
        public int CurrentSize { get; set; }

        /// <summary>
        /// Number of 8-KB pages the file could occupy, at minimum. This corresponds to the minimum 
        /// size or originally created size of a file.
        /// </summary>
        public int MinimumSize { get; set; }

        /// <summary>
        /// Number of 8-KB pages currently used by the file.
        /// </summary>
        public int UsedPages { get; set; }

        /// <summary>
        /// Number of 8-KB pages that the Database Engine estimates the file could be shrunk down to.
        /// </summary>
        public int EstinatedPages { get; set; }
    }
}