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

    using static contracts;
    using static metacore;

    using sxc = contracts;


    public sealed class udf<r> : udf<udf<r>,r>
        where r :sxc.scalar_type
    {
        public udf(SqlFunctionName name)
            : base(name)
        { }

    }

    
}