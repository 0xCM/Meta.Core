//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System;
    using System.Collections.Generic;
    using Meta.Models;


    using kwt = SqlKeywordTypes;
    using sxc = contracts;

    using static metacore;

    partial class SqlSyntax
    {

        public class search_condition : Model<search_condition>
        {

            public search_condition(kwt.NOT NOT, predicate predicate, search_criteria criteria = null)
                : this(new search_condition_branch(!predicate), criteria)
            { }


            public search_condition(predicate predicate, search_criteria criteria = null)
                : this(new search_condition_branch(predicate), criteria)
            { }

            public search_condition(search_condition_branch condition, search_criteria criteria = null)
            {
                this.condition = condition;
                this.criteria = criteria;
            }

            public search_condition_branch condition { get; }

            public ModelOption<search_criteria> criteria { get; }

            public override string ToString()
                => $"{condition} {criteria}";

        }


        

    }   

}
