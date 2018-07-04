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

    using sxc = Syntax.contracts;

    /// <summary>
    /// Characterizes a file object
    /// </summary>
    [SqlElementType(SqlElementTypeNames.SqlFile)]
    public sealed class SqlFile : SqlElement<SqlFile, SqlFileName>
    {
        public static readonly SqlDataSizeMeasure DefaultInitialSize = new SqlDataSizeMeasure(1);
        public static readonly SqlDataSizeMeasure DefaultGrowthIncrement = new SqlDataSizeMeasure(1);

        public SqlFile(
            SqlFileName LogicalName, 
            FileName Filename, 
            SqlDataSizeMeasure InitialSize = null, 
            SqlDataSizeMeasure MaxSize = null, 
            SqlDataSizeMeasure GrowthIncrement = null,
            int? GrowthRate = null,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null
            ) : base(LogicalName, Documentation, Properties)
        {
            this.FileSystemName = Filename;
            this.InitialSize = InitialSize ?? DefaultInitialSize;
            this.MaxSize = MaxSize;
            this.GrowthIncrement = GrowthIncrement ?? DefaultGrowthIncrement;
            this.GrowthRate = GrowthRate;
        }


        public FileName FileSystemName { get; }

        public Option<SqlDataSizeMeasure> InitialSize { get; }

        public Option<SqlDataSizeMeasure> MaxSize { get; }

        public Option<SqlDataSizeMeasure> GrowthIncrement { get; }

        public int? GrowthRate { get; }

        public override string ToString()
            => $"{ElementName} {FileSystemName}";
            
    }
}
