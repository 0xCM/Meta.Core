//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{

    using System;

    [Obsolete]
    public class StandardDevSegments : TypedItemList<StandardDevSegments, DevSegment>
    {
        public static readonly DevSegment BuildRoot = "build";
        public static readonly DevSegment Components = "src";
        public static readonly DevSegment ComponentBuild = "bin";
        public static readonly DevSegment Schemas = "sql";
        public static readonly DevSegment SchemaBuild = "dac";
        public static readonly DevSegment Reports = "reports";
        public static readonly DevSegment ReportBuild = "rpt";
    }
}