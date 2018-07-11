//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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

        /// <summary>
        /// The number of considered OS hosts
        /// </summary>
        public int HostCount { get; set; }

        /// <summary>
        /// The number of considered SQL Server instances
        /// </summary>
        public int ServerCount { get; set; }

        /// <summary>
        /// The number of considered databases
        /// </summary>
        public int DatabaseCount { get; set; }

        /// <summary>
        /// The number of considered schemas
        /// </summary>
        public int SchemaCount { get; set; }

        /// <summary>
        /// The number of considered tables
        /// </summary>
        public int TableCount { get; set; }

        /// <summary>
        /// The number of considered types
        /// </summary>
        public int TypeCount { get; set; }

        /// <summary>
        /// The number of considered views
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// The number of considered table columns
        /// </summary>
        public int TableColumnCount { get; set; }

        public int ExtendedPropertyCount { get; set; }

        /// <summary>
        /// The number of considered schema-bound objects
        /// </summary>
        public int SchemaObjectCount
            => TableCount + ViewCount;
        
        /// <summary>
        /// The total number of all things considered
        /// </summary>
        public int TotalItemCount
            => HostCount + ServerCount + DatabaseCount 
            + SchemaCount + TableCount + TypeCount + ViewCount 
            + TableColumnCount + ExtendedPropertyCount;
    }

}
