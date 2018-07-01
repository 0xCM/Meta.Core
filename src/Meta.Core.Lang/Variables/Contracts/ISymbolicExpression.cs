//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using static metacore;

    /// <summary>
    /// Defines a symbolic expression as an ordered adjunction of constituent expressions
    /// </summary>
    public interface ISymbolicExpression : ISymbolicElement
    {
        /// <summary>
        /// The components that comprise the expression
        /// </summary>
        IEnumerable<ISymbolicExpression> Components { get; }
    }

}