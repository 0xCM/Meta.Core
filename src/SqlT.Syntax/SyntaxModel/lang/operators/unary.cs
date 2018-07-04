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


        public sealed class dollar_op : Operator<dollar_op>, IUnaryOperator
        {
            
            dollar_op()
                : base("dollar", "$")
            { }

        }

        public sealed class pos_op : Operator<pos_op>, IUnaryOperator
        {
            pos_op()
                : base("pos", "+") { }


        }

        public sealed class neg_op : Operator<neg_op>, IUnaryOperator
        {
            neg_op()
                : base("neg", "-") { }


        }

    }

}