//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
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
