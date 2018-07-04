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

        public sealed class assignment_op : Operator<assignment_op>, IAssignmentOperator
        {
            assignment_op()
                : base("assignment_op", "=") { }
        }

        public abstract class compound_assignment_op<T,O> : Operator<T>, IAssignmentOperator
            where T : compound_assignment_op<T,O>
            where O : IOperator

        {

            protected compound_assignment_op(O compounded)
                : base("compound_assignment_op", $"{compounded.Symbol}=")
            {
                this.compounded = compounded;

            }

            public O compounded { get; }
        }

        public sealed class sub_assign_op : compound_assignment_op<sub_assign_op, sub_op>, IArithmeticOperator
        {
            sub_assign_op()
                : base(sqlops.SUB)
            { }

        }

        public sealed class mul_assign_op : compound_assignment_op<mul_assign_op, mul_op>, IArithmeticOperator
        {
            mul_assign_op()
                : base(sqlops.MUL)
            { }

        }

        public sealed class add_assign_op : compound_assignment_op<add_assign_op, add_op>, IArithmeticOperator
        {
            add_assign_op()
                : base(sqlops.ADD)
            { }

        }

        public sealed class mod_assign_op : compound_assignment_op<mod_assign_op, mod_op>, IArithmeticOperator
        {
            mod_assign_op()
                : base(sqlops.MOD)
            { }

        }

        public sealed class div_assign_op : compound_assignment_op<div_assign_op, div_op>, IArithmeticOperator
        {
            div_assign_op()
                : base(sqlops.DIV)
            { }

        }

    }

}