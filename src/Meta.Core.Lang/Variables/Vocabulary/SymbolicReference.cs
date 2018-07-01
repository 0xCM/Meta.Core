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
    

    using static metacore;
       
    /// <summary>
    /// Defines a refernece to a symbolic variable
    /// </summary>
    public struct SymbolicReference : ISymbolicReference
    {       
        public SymbolicReference(ISymbolicVariable Referent)
        {
            this.Referent = Referent;
        }

        public ISymbolicVariable Referent { get; }

        public IEnumerable<ISymbolicExpression> Components 
            => stream<ISymbolicExpression>();

        public override string ToString()
            => this.Format();
    }
}