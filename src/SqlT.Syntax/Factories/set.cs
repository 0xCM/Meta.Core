//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System.Linq;
    using System.Collections.Generic;

    using static SqlSyntax;

    using static metacore;
    using sxc = contracts;
    using sx = SqlSyntax;
    using kwt = SqlT.Syntax.SqlKeywordTypes;

    partial class sql
    {        
        public static set_option set(kwt.NOCOUNT nocount, kwt.ON ON)
            => new set_option(nocount, ON);

        public static set_option set(kwt.NOCOUNT NOCOUNT, kwt.OFF OFF)
            => new set_option(NOCOUNT, OFF);

        public static set_option set(kwt.XACT_ABORT XACT_ABORT, kwt.ON ON)
            => new set_option(XACT_ABORT, ON);

        public static set_option set(kwt.XACT_ABORT XACT_ABORT, kwt.OFF OFF)
            => new set_option(XACT_ABORT, OFF);

        public static set_option set(kwt.TRANSACTION tx, kwt.ISOLATION i, kwt.LEVEL l, kwt.READ r, kwt.COMMITTED c)
            => new set_option(tx, i, l, r, c);

        public static set_option set(kwt.TRANSACTION tx, kwt.ISOLATION i, kwt.LEVEL l, kwt.READ r, kwt.UNCOMMITTED u)
            => new set_option(tx, i, l, r, u);

        public static set_option set(kwt.TRANSACTION tx, kwt.ISOLATION i, kwt.LEVEL l, kwt.REPEATABLE repeatable, kwt.READ read)
            => new set_option(tx, i, l, repeatable, read);

        public static set_option set(kwt.TRANSACTION tx, kwt.ISOLATION i, kwt.LEVEL l, kwt.SNAPSHOT s)
            => new set_option(tx, i, l, s);

        public static set_option set(kwt.TRANSACTION tx, kwt.ISOLATION i, kwt.LEVEL l, kwt.SERIALIZABLE s)
            => new set_option(tx, i, l, s);

        public static set_option set(kwt.ANSI_NULLS option, kwt.ON ON)
            => new set_option(option, ON);

        public static set_option set(kwt.ANSI_NULLS option, kwt.OFF OFF)
            => new set_option(option, OFF);

        public static set_option set(kwt.ANSI_PADDING option, kwt.ON ON)
            => new set_option(option, ON);

        public static set_option set(kwt.ANSI_PADDING option, kwt.OFF OFF)
            => new set_option(option, OFF);

        public static set_option set(kwt.ANSI_WARNINGS option, kwt.ON ON)
            => new set_option(option, ON);

        public static set_option set(kwt.ANSI_WARNINGS option, kwt.OFF OFF)
            => new set_option(option, OFF);

        public static set_option set(kwt.ARITHABORT option, kwt.ON ON)
            => new set_option(option, ON);

        public static set_option set(kwt.ARITHABORT option, kwt.OFF OFF)
            => new set_option(option, OFF);

        public static set_option set(kwt.CONCAT_NULL_YIELDS_NULL option, kwt.ON ON)
            => new set_option(option, ON);

        public static set_option set(kwt.CONCAT_NULL_YIELDS_NULL option, kwt.OFF OFF)
            => new set_option(option, OFF);

        public static set_option set(kwt.QUOTED_IDENTIFIER option, kwt.ON ON)
            => new set_option(option, ON);

        public static set_option set(kwt.QUOTED_IDENTIFIER option, kwt.OFF OFF)
            => new set_option(option, OFF);            
    }
}