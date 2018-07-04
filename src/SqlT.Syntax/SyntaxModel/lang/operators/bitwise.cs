//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    
    partial class SqlSyntax
    {

        public sealed class bw_andeq_op : Operator<bw_andeq_op>,  IBitwiseOperator
        {
            bw_andeq_op()
                : base("bw_andeq", "&=") { }
            
        }

        public sealed class bw_and_op : Operator<bw_and_op>, IBitwiseOperator
        {
            bw_and_op()
                : base("bw_and", "&") { }
        }


        public sealed class bw_not_op : Operator<bw_not_op>, IUnaryOperator, IBitwiseOperator
        {
            bw_not_op()
                : base("bw_not", "~") { }
        }

        public sealed class bw_or_op : Operator<bw_or_op>, IBitwiseOperator
        {
            bw_or_op()
                : base("bw_or", "|") { }
        }

        public sealed class bw_xoreq_op : Operator<bw_xoreq_op>, IBitwiseOperator
        {
            bw_xoreq_op()
                : base("bw_xoreq", "^=") { }
        }

        public sealed class bw_oreq_op : Operator<bw_oreq_op>, IBitwiseOperator
        {
            bw_oreq_op()
                : base("bw_oreq", "|=") { }
        }

        public sealed class bw_xor_op : Operator<bw_xor_op>, IBitwiseOperator
        {
            bw_xor_op()
                : base("bw_xor", "^") { }
        }
    }
}