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

    using Meta.Syntax;
    using SqlT.Core;

    using System.Runtime.CompilerServices;

    using static SqlSyntax;

    using static metacore;
    using static grammar;

    using sxc = contracts;

    partial class SqlGrammar
    {

        partial class Choices
        {
            partial class QueryStore
            {

                public static ChoiceGroup operation_mode
                    => choices(READ_WRITE | READ_ONLY);

                public static ChoiceGroup size_based_cleanup_mode
                    => choices(AUTO | OFF);

                public static ChoiceGroup query_capture_mode
                    => choices(ALL | AUTO | NONE);

                public static ChoiceGroup wait_stats_capture_mode
                    => choices(ON | OFF);
            }
        }
    }
}
