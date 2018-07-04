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
    using SqlT.Proxies.Z0;

    using static metacore;

    using static SqlSyntax;
    using static grammar;
    using static SqlGrammar.Choices;

    partial class SqlGrammar
    {
        partial class Statements
        {
            public static class Collate
            {


                public static SyntaxRule windows_collation_name
                    => rule();

                public static SyntaxRule collation_name
                    => define(windows_collation_name | sql_collation_name);

                public static SyntaxRule collate()
                    => define(COLLATE + group(collation_name | DATABASE_DEFAULT));


            }

        }

    }
}