//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Collects standard method classifications
    /// </summary>
    public class StandardMethods : TypedItemList<StandardMethods, StandardMethod>
    {
        public static readonly StandardMethod ThenBy = new OrderSpecificationMethod(nameof(ThenBy), SortDirection.Ascending, false);
        public static readonly StandardMethod ThenByDescending = new OrderSpecificationMethod(nameof(ThenByDescending), SortDirection.Descending, false);
        public static readonly StandardMethod OrderBy = new OrderSpecificationMethod(nameof(ThenBy), SortDirection.Ascending, true);
        public static readonly StandardMethod OrderByDescending = new OrderSpecificationMethod(nameof(ThenByDescending), SortDirection.Descending, true);
        public static readonly StandardMethod Select = new SelectMethod();
        public static readonly StandardMethod Where = new WhereMethod();
    }
}