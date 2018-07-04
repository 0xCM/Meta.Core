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

    using static SqlSyntax;
    using sxc = contracts;
    using O = Meta.Models.cdu<Meta.Syntax.ILogicalOperator,
                SqlSyntax.between_op,
                SqlSyntax.all_op,
                SqlSyntax.and_op,
                SqlSyntax.any_op,
                SqlSyntax.not_op,
                SqlSyntax.exists_op,
                SqlSyntax.in_op,
                SqlSyntax.or_op,
                SqlSyntax.some_op,
                SqlSyntax.like_op
                >;

    partial class SqlSyntax
    {
        public sealed class logical_operator : LogicalOperator<logical_operator>
        {

            public static implicit operator O(logical_operator op)
                => op.selection;

            public static implicit operator logical_operator(O op)
                => new logical_operator(op);

            public logical_operator(O op)
                : base(op.selected_value.Designator)
            {
                this.selection = op;
            }

            public O selection { get; }

        }

        public sealed class between_op : LogicalOperator<between_op>, ITernaryOperator
        {
            between_op()
               : base(BETWEEN)
            { }

        }

        public sealed class all_op : LogicalOperator<all_op>
        {

            all_op()
                : base(ALL)
            {

            }
        }

        public sealed class and_op : LogicalOperator<and_op>
        {

            and_op()
                : base(AND)
            {

            }

        }

        public sealed class any_op : LogicalOperator<any_op>
        {

            any_op()
                : base(ANY)
            {

            }
        }

        public sealed class not_op : LogicalOperator<not_op>
        {
            not_op()
                : base(NOT)
            {

            }
        }

        public sealed class exists_op : LogicalOperator<exists_op>
        {
            exists_op()
                : base(EXISTS)
            {

            }
        }


        public sealed class in_op : LogicalOperator<in_op>
        {

            in_op()
                : base(IN)

            {

            }

        }

        public sealed class or_op : LogicalOperator<or_op>
        {

            or_op()
                : base(OR)

            {

            }
        }


        public sealed class some_op : LogicalOperator<some_op>
        {
            some_op()
                : base(SOME)
            {

            }
        }

        public sealed class like_op : LogicalOperator<like_op>
        {

            like_op()
                : base(LIKE)
            {

            }
        }
    }
}