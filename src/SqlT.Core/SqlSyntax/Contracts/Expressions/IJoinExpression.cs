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

    using Meta.Syntax;

    using SqlT.Core;
    using sxc = contracts;

    public interface IJoinExpression : ISyntaxExpression
    {

    }

    public interface IJoinExpression<L, R> : IJoinExpression
            where L : sxc.table_source
            where R : sxc.table_source
    {

        L Left { get; }

        R Right { get; }


    }

}