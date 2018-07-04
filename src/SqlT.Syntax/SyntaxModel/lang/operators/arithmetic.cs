//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;    
    using sxc = contracts;

    partial class SqlSyntax
    {

        public sealed class sub_op : Operator<sub_op>, IArithmeticOperator
        {
            sub_op()
                : base("sub", "-") { }
        }

        public sealed class add_op : Operator<add_op>, IArithmeticOperator
        {
            add_op()
                : base("add", "+") { }
        }

        public sealed class div_op : Operator<div_op>, IArithmeticOperator
        {
            div_op()
                : base("div", "/") { }
        }

        public sealed class mod_op : Operator<mod_op>, IArithmeticOperator
        {
            mod_op()
                : base("mod", "%") { }
        }

        public sealed class mul_op : Operator<mul_op>, IArithmeticOperator
        {
            mul_op()
                : base("mul", "*") { }
        }
    }
}