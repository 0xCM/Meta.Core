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
    using sxc = contracts;


    using O =
        Meta.Models.cdu<Meta.Syntax.IComparisonOperator,
                SqlSyntax.eq_op,
                SqlSyntax.gt_op,
                SqlSyntax.gteq_op,
                SqlSyntax.lt_op,
                SqlSyntax.lteq_op,
                SqlSyntax.neq_op,
                SqlSyntax.ngt_op,
                SqlSyntax.nlt_op
                >;

    partial class SqlSyntax
    {


        public sealed class comparison_operator  : ComparisonOperator<comparison_operator>
        {
            public static implicit operator O(comparison_operator op)
                => op.selection;

            public static implicit operator comparison_operator(O op)
                => new comparison_operator(op);

            public comparison_operator(O op)
                : base(op.selected_value.Name, op.selected_value.Symbol)
            {
                this.selection = op;
            }

            public O selection { get; }
        }

        public sealed class lt_op : ComparisonOperator<lt_op>
        {
            lt_op()
                : base("lt", "<") { }

        }

        public sealed class lteq_op : ComparisonOperator<lteq_op>
        {
            lteq_op()
                : base("lteq", "<=") { }
        }

        public sealed class neq_op : ComparisonOperator<neq_op>
        {

            neq_op()
                : base("neq", "<>") { }

        }

        public sealed class nlt_op : ComparisonOperator<nlt_op>
        {
            nlt_op()
                : base("nlt", "!<") { }

        }

        public sealed class gteq_op : ComparisonOperator<gteq_op>
        {
            gteq_op()
                : base("gteq", ">=") { }

        }


        public sealed class ngt_op : ComparisonOperator<ngt_op>
        {
            ngt_op()
                : base("ngt", "!>") { }

        }

        public sealed class eq_op : ComparisonOperator<eq_op>
        {
            eq_op()
                : base("eq", "=") { }

        }

        public sealed class gt_op : ComparisonOperator<gt_op>
        {
            gt_op()
                : base("gt", ">") { }

        }

    }

}