//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using static metacore;
    using Meta.Core;

    public interface ISqlProxyParser
    {
        IEnumerable<(long LineNumber, P LineValue)> ParseFile<P>(NodeFilePath SrcPath, DelimitedTextDescription Config)
            where P : class, ISqlTabularProxy, new();

        IEnumerable<(long LineNumber, P LineValue)> ParseTop<P>(NodeFilePath SrcPath, DelimitedTextDescription Config, int TopCount)
            where P : class, ISqlTabularProxy, new();
    }

}