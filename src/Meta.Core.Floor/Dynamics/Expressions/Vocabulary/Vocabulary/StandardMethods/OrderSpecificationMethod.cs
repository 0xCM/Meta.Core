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

    public class OrderSpecificationMethod : StandardMethod
    {
        public OrderSpecificationMethod(string MethodName, SortDirection Direction, bool IsPrimary)
            : base(MethodName)
        {
            this.Direction = Direction;
            this.IsPrimary = IsPrimary;
        }

        public SortDirection Direction { get; }

        public bool IsPrimary { get; }
    }
}