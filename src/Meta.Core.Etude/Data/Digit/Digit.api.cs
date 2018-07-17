//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

partial class etude
{

    /// <summary>
    /// Populates a <see cref="Digit"/> container
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static Digits digits(params Digit[] d)
        => new Digits(d);

        
}
