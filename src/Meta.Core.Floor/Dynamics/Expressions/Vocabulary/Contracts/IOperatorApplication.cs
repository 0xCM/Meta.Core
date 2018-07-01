//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Specifies the application of an n-ary operator to n operands
    /// </summary>
    public interface IOperatorApplication
    {
        /// <summary>
        /// The opererator to apply
        /// </summary>
        IOperator Operator { get; }

        /// <summary>
        /// The operands
        /// </summary>
        IReadOnlyList<object> Operands { get; }
    }



}