//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    partial class SqlSyntax
    {


        public sealed class xprop_value : Model<xprop_value>
        {
            public xprop_value(xprop_path path, SqlVariant value)
            {
                this.path = path;
                this.value = value;
            }


            public xprop_path path { get; }

            public SqlVariant value { get; }

            public override string ToString()
                => $"{path} = {value}";
        }

        public sealed class xprop_value_list : SyntaxList<xprop_value>
        {
            public static implicit operator xprop_value_list(xprop_value[] values)
                => new xprop_value_list(values);

            public xprop_value_list(params xprop_value[] values)
                : base(values)
            { }
        }
    }
}
