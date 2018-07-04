//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class intersect_op : set_operator<intersect_op>
        {
            intersect_op()
                : base(INTERSECT)
            { }
        }

        public sealed class union_op : set_operator<union_op>
        {
            union_op()
             : base(UNION)
            { }

        }

        public sealed class except_op : set_operator<except_op>
        {
            except_op()
                : base(EXCEPT)
            { }
        }

    }

}