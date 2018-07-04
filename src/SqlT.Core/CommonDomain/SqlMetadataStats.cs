//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Encapsulates a collection of metadata statistics relative to some context
    /// </summary>
    public class SqlMetadataStats
    {
        public static SqlMetadataStats operator + (SqlMetadataStats x, SqlMetadataStats y) 
            => new SqlMetadataStats
            {
                HostCount = x.HostCount + y.HostCount,
                ServerCount = x.ServerCount + y.ServerCount,
                DatabaseCount = x.DatabaseCount + y.DatabaseCount,
                SchemaCount = x.SchemaCount + y.SchemaCount,
                TableCount = x.TableCount + y.TableCount,
                TypeCount = x.TypeCount + y.TypeCount,
                ViewCount = x.ViewCount + y.ViewCount,
                TableColumnCount = x.TableColumnCount + y.TableColumnCount,
                ExtendedPropertyCount = x.ExtendedPropertyCount + y.ExtendedPropertyCount,                                
            };

        public int HostCount { get; set; }

        public int ServerCount { get; set; }

        public int DatabaseCount { get; set; }

        public int SchemaCount { get; set; }

        public int TableCount { get; set; }

        public int TypeCount { get; set; }

        public int ViewCount { get; set; }

        public int TableColumnCount { get; set; }

        public int ExtendedPropertyCount { get; set; }

        public int SchemaObjectCount
            => TableCount + ViewCount;

        public int TotalItemCount
            => HostCount + ServerCount + DatabaseCount 
            + SchemaCount + TableCount + TypeCount + ViewCount 
            + TableColumnCount + ExtendedPropertyCount;
    }

}
