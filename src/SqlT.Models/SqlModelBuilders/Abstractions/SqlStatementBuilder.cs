//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using SqlT.Models;
    using SqlT.Syntax;
    
    public abstract class SqlStatementBuilder<M> : SqlModelBuilder<M>
        where M : SqlStatement<M>
    {

    }

    public abstract class SqlStatementBuilder<B, M> : SqlStatementBuilder<M>
        where B : SqlStatementBuilder<B, M>
        where M : SqlStatement<M>
    {

    }


}
