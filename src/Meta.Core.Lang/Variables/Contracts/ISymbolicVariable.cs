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
    using System.Text;
    using V = SymbolicVariable;

    public interface ISymbolicVariable : ISymbolicExpression
    {
        SymbolicVariableName VariableName { get; }

        bool IsAnonymous { get; }

        SymbolicReference CreateReference();


        Option<object> ResolveValue();
    }

    public interface ISymbolicVariable<V> : ISymbolicVariable
    {

        new Option<V> ResolveValue();

       
    }

}