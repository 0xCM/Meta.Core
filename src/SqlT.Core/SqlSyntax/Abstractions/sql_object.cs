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

    using Meta.Syntax;
    using Meta.Models;
    using SqlT.Core;    

    using static metacore;

    using sxc = contracts;


    /// <summary>
    /// Abstract base class for syntax representations of schema-bound database objects
    /// </summary>
    /// <typeparam name="o">The derived subtype</typeparam>
    /// <typeparam name="n">The object name type</typeparam>
    public abstract class sql_object<o, n> : Model<o>, sxc.sql_object<n>
       where o : sql_object<o, n>
       where n : sxc.ISqlObjectName, new()
    {

        protected sql_object(n name)
        {
            this.Name = name;
        }

        public n Name { get; }

        public IName ElementName
            => Name;

        public override string ToString()
            => $"{Name}";
    }

}