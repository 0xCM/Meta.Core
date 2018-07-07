//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

public static partial class metacore
{

    /// <summary>
    /// Converts a text-based uri representation to a <see cref="SystemUri"/> representation
    /// </summary>
    /// <param name="uriText"></param>
    /// <returns></returns>
    public static SystemUri uri(string uriText)
        => SystemUri.Parse(uriText);

}