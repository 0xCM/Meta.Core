﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Meta.Syntax;
    using Meta.Models;

    public interface ILogicalExpression : IBooleanExpression
    {
        ILogicalOperator Operator { get; }

        ISyntaxExpression Left { get; }

        ISyntaxExpression Right { get; }
    }

}