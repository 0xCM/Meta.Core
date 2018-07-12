//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;



    public partial class Lst : Modules.Lst
    {
        /// <summary>
        /// Parses a list representation produced by the <see cref="format"/> function
        /// </summary>
        /// <typeparam name="X">The item type</typeparam>
        /// <param name="formatted"></param>
        /// <returns></returns>
        public static Lst<X> parse<X>(string formatted)
            => Lst.make(from list in formatted.GetBoundedContent('[', ']')
                        from item in list.Split(",")
                        select metacore.parse<X>(item));



    }



}