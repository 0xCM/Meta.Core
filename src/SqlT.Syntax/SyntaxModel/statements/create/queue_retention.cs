//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Models;
    using SqlT.Core;

    using static metacore;
    using sxc = contracts;

    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {


        public class queue_retention : du<kwt.ON, kwt.OFF>
        {

            public static implicit operator queue_retention(kwt.ON ON)
                => new queue_retention(ON);

            public static implicit operator queue_retention(kwt.OFF OFF)
                => new queue_retention(OFF);

            public queue_retention(kwt.ON ON)
                : base(ON)
            { }

            public queue_retention(kwt.OFF OFF)
                : base(OFF)
            { }

        }

    }
}