//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public class StandardOperators : TypedItemList<StandardOperators, IOperator>
    {
        
        public static readonly NotNullOperator IsNotNull = new NotNullOperator();
        public static readonly IsNullOperator IsNull = new IsNullOperator();
        public static readonly FalseOperator False = new FalseOperator();
        public static readonly TrueOperator True = new TrueOperator();
        public static readonly EqualOperator Equal = new EqualOperator();
        public static readonly NotEqualOperator NotEqual = new NotEqualOperator();
        public static readonly GreaterThanOperator GreaterThan = new GreaterThanOperator();
        public static readonly LessThanOperator LessThan = new LessThanOperator();
        public static readonly GreaterThanOrEqualOperator GreaterThanOrEqual = new GreaterThanOrEqualOperator();
        public static readonly LessThanOrEqualOperator LessThanOrEqual = new LessThanOrEqualOperator();
        public static readonly AndOperator And = new AndOperator();
        public static readonly OrOperator Or = new OrOperator();
    }


    public sealed class GreaterThanOperator : ComparisonOperator<GreaterThanOperator>
    {
        internal GreaterThanOperator()
            : base("gt", ">")
        { }
    }

    public sealed class LessThanOperator : ComparisonOperator<LessThanOperator>
    {
        internal LessThanOperator()
            : base("lt", "<")
        { }
    }


    public sealed class GreaterThanOrEqualOperator : ComparisonOperator<GreaterThanOrEqualOperator>
    {
        internal GreaterThanOrEqualOperator()
            : base("gteq", ">=")
        { }
    }

    public sealed class LessThanOrEqualOperator : ComparisonOperator<LessThanOrEqualOperator>
    {
        internal LessThanOrEqualOperator()
            : base("lteq", "<=")
        { }
    }

}
