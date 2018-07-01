//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IUnaryExpression : ISyntaxExpression
    {
        ISyntaxExpression Operand { get; }
    }

    public interface IUnaryExpression<e> : IUnaryExpression
        where e : ISyntaxExpression
    {
        new e Operand { get; }
    }

}