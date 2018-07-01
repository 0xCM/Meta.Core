//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Collections.Generic;

    using Meta.Models;

    public interface IModelReference : IUnaryExpression
    {
        IName Referent { get; }
    }

    public interface IModelReference<n> : IModelReference
        where n : IName, new()
    {
        new n Referent { get; }
    }

}