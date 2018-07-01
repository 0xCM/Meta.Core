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

    public interface IBinaryExpression : ISyntaxExpression
    {
        ISyntaxExpression Left { get; }

        ISyntaxExpression Right { get; }
    }

    public interface IBinaryExpression<l, r> : IBinaryExpression
        where l : ISyntaxExpression
        where r : ISyntaxExpression
    {
        new l Left { get; }
        new r Right { get; }

    }


}