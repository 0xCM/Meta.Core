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

    public static partial class contracts
    {
        public interface column_predicate : IBooleanExpression
        {
            SqlColumnName column { get; }

            IBooleanExpression condition { get; }
        }

        public interface column_predicate<t> : column_predicate
        {

        }
    }

}