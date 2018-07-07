//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;

    /// <summary>
    /// Delineates a contiguous interval between comparable inclusive lower and upper bounds of the same data type
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    public interface IRange<out T> : IInterval<T>
        where T : IComparable
    {


    }
}