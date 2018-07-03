//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    

    public class MemberOrdering
    {

        public MemberOrdering(IEnumerable<MemberItemOrder> orders)
        {
            Orders = orders.OrderBy(e => e.Precedence).ToList();
        }

        public IReadOnlyList<MemberItemOrder> Orders { get; }
    }
}