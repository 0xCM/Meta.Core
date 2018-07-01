//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;
using Meta.Core.Modules;


using static metacore;

public static class _List
{

    /// <summary>
    /// Parses a list representation produced by the <see cref="format"/> function
    /// </summary>
    /// <typeparam name="X">The item type</typeparam>
    /// <param name="formatted"></param>
    /// <returns></returns>
    public static List<X> parse<X>(string formatted)
        => List.make( from list in formatted.GetBoundedContent('[', ']')
           from item in list.Split(",")
           select metacore.parse<X>(item));


        




}

