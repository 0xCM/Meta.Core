//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Meta.Models;

    using static contracts;

    public class syntax_collection<m> : IEnumerable<m>
        where m : IModel
    {

        static HashSet<m> collection = new HashSet<m>();

        IEnumerator<m> IEnumerable<m>.GetEnumerator()
            => ((IEnumerable<m>)collection).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable<m>)collection).GetEnumerator();
    }

}
