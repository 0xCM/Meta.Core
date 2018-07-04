//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;


    using static metacore;
    using sxc = Syntax.contracts;

    /// <summary>
    /// Characterizes a SQL filegroup
    /// </summary>
    [SqlElementType(SqlElementTypeNames.Filegroup)]
    public sealed class SqlFileGroup : SqlElement<SqlFileGroup, SqlFileGroupName>
    {
        public static readonly SqlFileGroupName DefaultFileGroupName = "PRIMARY";

        public static bool IsDefault(SqlName FileGroupName)
            => FileGroupName == DefaultFileGroupName;

        public SqlFileGroup(SqlFileGroupName FileGroupName, 
                IEnumerable<SqlFile> Files, 
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null) 
                    : base(FileGroupName, Documentation, Properties)
        {
            this.Files = rolist(Files);
        }

        public SqlFileGroup(SqlFileGroupName FileGroupName, params SqlFile[] Files)
            : base(FileGroupName)
        {
            this.Files = rolist(Files);
        }

        public IReadOnlyList<SqlFile> Files { get; }

    }
}
