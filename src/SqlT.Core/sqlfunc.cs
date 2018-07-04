//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using static metacore;

using SqlT.Core;

public static class sqlfunc
{


    public static Option<P> option<P>(SqlOutcome<P> x)
            => x ? some(x.Payload)
                 : none<P>(x.Message?.ToApplicationMessage() ??
                        error("A SQL operation failed but there was no message"));    
}
