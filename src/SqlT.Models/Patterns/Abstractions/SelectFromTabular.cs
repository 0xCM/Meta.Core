//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Patterns
{
    using System;

    using SqlT.Models;
    using SqlT.Core;
    

    public abstract class SelectFromTabular<M, N> : SqlModelFactory<M, SqlSelectStatement>
        where M : SelectFromTabular<M, N>
        where N : SqlTabularName<N>, new()
    {
        protected SelectFromTabular(N SourceName)
        {
            this.SourceName = SourceName;
        }



        public N SourceName { get; }

    }


}