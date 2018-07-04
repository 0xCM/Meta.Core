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


    using SqlT.Core;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static metacore;
    using static SqlSyntax;

    partial class sql
    {
        public static routine_argument_value argval(scalar_value value)
            => new routine_argument_value(value);

        public static routine_argument_value argval(kwt.DEFAULT DEFAULT)
            => new routine_argument_value(DEFAULT);
    }

}