//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using SqlT.Core;

    using sxc = Syntax.contracts;
    partial class SqlSyntax
    {



        public class xprop_segment : Model<xprop_segment>
        {

            public xprop_segment()
            {
                this.type = new xprop_level0_type().Database;
                this.name = SqlIdentifier.empty;
            }

            public xprop_segment(xprop_type type, SqlIdentifier name)
            {
                this.type = type;
                this.name = name;
            }


            public xprop_type type { get; }


            public SqlIdentifier name { get; }

            public override string ToString()
                => name.ToString();
        }
    }
}
