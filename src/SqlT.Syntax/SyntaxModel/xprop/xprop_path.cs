//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    using Meta.Models;

    using SqlT.Core;

    using static metacore;

    partial class SqlSyntax
    {
        public class xprop_path : Model<xprop_path>
        {
            public xprop_path(SqlExtendedPropertyName xprop_name, params xprop_segment[] segments)
            {
                this.xprop_name = xprop_name;
                this.segments = segments;
            }

            public SqlExtendedPropertyName xprop_name { get; }

            public SyntaxList<xprop_segment> segments { get; }

            public string SegmentPath
                => string.Join("/", segments);

            public override string ToString()
                => ifBlank(SegmentPath, xprop_name);
        }
    }
}
