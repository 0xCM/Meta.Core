//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;

    public interface INameExpression : ISyntaxExpression
    {
        IName ExpressedName { get; }
    }

    public interface INameExpression<n> : INameExpression
        where n : IName, new()
    {
        new n ExpressedName { get; }
    }

}