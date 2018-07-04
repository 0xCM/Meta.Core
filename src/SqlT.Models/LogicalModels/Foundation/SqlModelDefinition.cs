//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;



    public abstract class SqlModelDefinition<M> : Model<M>
        where M : SqlModelDefinition<M>, new()
    {

        public SqlModelDefinition(bool IsIntrinsic = false)
        {
            this.IsIntrinsic = IsIntrinsic;
        }

        public bool IsIntrinsic { get; set; }

    }



}