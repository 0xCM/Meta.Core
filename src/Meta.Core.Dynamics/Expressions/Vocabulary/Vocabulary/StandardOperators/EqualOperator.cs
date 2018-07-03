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
    /// Represents the equal operator
    /// </summary>
    public sealed class EqualOperator : ComparisonOperator<EqualOperator>
    {
        internal EqualOperator()
            : base("eq", "==")
        { }
    }

}