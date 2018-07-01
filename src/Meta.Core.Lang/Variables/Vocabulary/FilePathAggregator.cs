﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;


    using static metacore;

    public class PathVariableAggregator : IValueAggregator<string>
    {
        public string Aggregate(params string[] values)
            => Path.Combine(values);

        object IValueAggregator.Aggregate(params object[] values)
            => Aggregate(values.Cast<string>().ToArray());
    }

}