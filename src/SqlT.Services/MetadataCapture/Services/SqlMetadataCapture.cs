//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;

    using static metacore;
    using SqlT.Core;
    using SqlT.Models;

    /// <summary>
    /// Default realization of the <see cref="ISqlMetadataCapture"/> contract
    /// </summary>
    class SqlMetadataCaptureService : ApplicationService<SqlMetadataCaptureService, ISqlMetadataCapture>, ISqlMetadataCapture
    {

        ISqlMetadataProvider MetadataProvider
            => Service<ISqlMetadataProvider>();

        ISqlMetadataStore MetadataStore
            => Service<ISqlMetadataStore>();

        public SqlMetadataCaptureService(INodeContext C)
            : base(C)
        {

        }

        public Option<MetadataCaptureSummary> CaptureMetadata(SqlConnectorLink<SqlMetadataSelectionOptions> spec)
        {
            var csSource = spec.Source;

            var dbSource = new SqlDatabaseName(csSource.ServerName, csSource.DatabaseName);
            var stats =
                from set in MetadataProvider.DescribeDatabase(csSource, dbSource, spec.Options)
                from saved in MetadataStore.Save(spec.Target, set)
                select saved;

            return stats.Map(s => new MetadataCaptureSummary
            {
                SchemaCount = s.SchemaCount,
                TableColumnCount = s.TableColumnCount,
                TableCount = s.TableCount,
                TypeCount = s.TypeCount,
                ViewCount = s.ViewCount
            });
        }
    }
    

}