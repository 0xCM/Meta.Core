//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;    

    partial class SqlSyntax
    {
        public class routine_argument_list : SyntaxList<routine_argument>, sxc.routine_argument_list
        {
            public static new readonly routine_argument_list empty
                = new routine_argument_list(new routine_argument[] { });

            public static implicit operator routine_argument_list((routine_arg_name name, scalar_value value)[] args)
                => new routine_argument_list(map(args, arg => new routine_argument(arg)));


            public static implicit operator routine_argument_list(routine_argument[] args)
                => new routine_argument_list(args);

            public routine_argument_list(params routine_argument[] args)
                : base(args)
            { }

            public routine_argument_list(IEnumerable<routine_argument> args)
                : base(args)
            { }

            IEnumerator<sxc.routine_argument> IEnumerable<sxc.routine_argument>.GetEnumerator()
                => items.Cast<sxc.routine_argument>().GetEnumerator();

            public override string ToString()
                => string.Join(",", map(items, i => i.ToString()));

            IModelList<sxc.routine_argument> IModelList<sxc.routine_argument>.append(params sxc.routine_argument[] items)
                => SyntaxList.create(this.items.Concat(items));

            IModelList<sxc.routine_argument> IModelList<sxc.routine_argument>.prepend(params sxc.routine_argument[] items)
                => SyntaxList.create(items.Concat(this.items));
        }


    }

}