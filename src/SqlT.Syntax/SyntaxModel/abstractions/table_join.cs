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
    using Meta.Syntax;

    using SqlT.Core;
    using sx = Syntax.SqlSyntax;
    using sxc = Syntax.contracts;
    using static SqlSyntax;

    public abstract class table_join<j> : SyntaxExpression<j>, IJoinExpression
        where j : table_join<j>
    {

        protected table_join(sxc.table_source left_table, sxc.table_source right_table, search_condition join_criteria = null)
        {
            this.left_table = left_table;
            this.right_table = right_table;
            this.join_criteria = join_criteria;
        }

        public sxc.table_source left_table { get; }

        public sxc.table_source right_table { get; }


        public ModelOption<search_condition> join_criteria { get; }
    }

    public abstract class table_join<l, r> : table_join<table_join<l, r>>, IJoinExpression<l, r>
        where l : sxc.table_source
        where r : sxc.table_source
    {
        protected table_join(l Left, r Right, search_condition join_criteria = null)
            : base(Left, Right)
        {
            this.Left = Left;
            this.Right = Right;             
        }


        public l Left { get; }


        public r Right { get; }

    }

}
