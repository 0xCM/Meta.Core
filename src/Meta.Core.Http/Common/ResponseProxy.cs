//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;


    /// <summary>
    /// Ultimate base type for response proxies
    /// </summary>
    /// <typeparam name="R">The derived subtype</typeparam>
    [DebuggerStepThrough]
    public abstract class ResponseProxy<R> : Representation<R>
        where R : ResponseProxy<R>
    {

    }
}
