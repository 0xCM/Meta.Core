//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using Meta.Models;


    public abstract class dbcc<C>  : Model<C> 
        where C : dbcc<C>
    {

        protected dbcc(SimpleSqlName name)
        {
            this.name = name;
        }

        protected dbcc()
        {
            this.name = typeof(C).Name;
        }

        public SimpleSqlName name { get; }
    }




}