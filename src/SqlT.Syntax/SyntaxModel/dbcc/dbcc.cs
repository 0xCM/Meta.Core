//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
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