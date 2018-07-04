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

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static metacore;

    partial class SqlSyntax
    {
        public class queue_status : du<kwt.ON, kwt.OFF>
        {

            public static implicit operator queue_status(kwt.ON ON)
                => new queue_status(ON);

            public static implicit operator queue_status(kwt.OFF OFF)
                => new queue_status(OFF);

            public queue_status(kwt.ON ON)
                : base(ON)
            { }

            public queue_status(kwt.OFF OFF)
                : base(OFF)
            { }
        }
    }
}