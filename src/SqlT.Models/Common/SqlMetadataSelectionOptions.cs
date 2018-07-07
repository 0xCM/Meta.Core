//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using SqlT.Core;
    using Meta.Core;

    /// <summary>
    /// Specifies metadata aspects to be included during a metadata collection exercise
    /// </summary>
    public class SqlMetadataSelectionOptions
    {

        public SqlMetadataSelectionOptions()
        {
            this.CollectTypes = true;
            this.CollectTables = true;
            this.CollectTableColumns = true;
            this.CollectTableIndexes = true;
            this.CollectViews = true;
            this.CollectExtendedProperties = true;
            this.IncludedSchemas = Set<string>.Empty;
        }

        [Description("The schemas to include in the collection or, if unspecified, means that metadata will include all schemas")]
        public Set<string> IncludedSchemas { get; set; }

        [Description("Specfies whether user-defined type metadata should be collected")]
        public bool CollectTypes { get; set; }

        [Description("Specfies whether table metadata should be collected")]
        public bool CollectTables { get; set; }

        [Description("Specfies whether table column metadata should be collected")]
        public bool CollectTableColumns { get; set; }

        [Description("Specfies whether table index metadata should be collected")]
        public bool CollectTableIndexes { get; set; }

        [Description("Specfies whether view metadata should be collected")]
        public bool CollectViews { get; set; }     
        
        public bool CollectExtendedProperties { get; set; }

        public bool CollectSchemaObjects
            => CollectTypes || CollectTables || CollectViews;

    }
}