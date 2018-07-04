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
    using SqlT.Syntax;
    using SqlT.Models;

    using static metacore;
    using static SqlSyntax;
    using sxc = contracts;    

    public static class SqlJoinExtensions
    {
        public static left_join<L, R> LeftJoin<L, R>(this L left, R right, search_condition join_criteria)
           where L : sxc.table_source
           where R : sxc.table_source
               => new left_join<L, R>(left, right, join_criteria);

        public static cross_join<L, R> CrossJoin<L, R>(this L left, R right)
            where L : table_source
            where R : table_source
                => new cross_join<L, R>(left, right);

        public static inner_join<L, R> InnerJoin<L, R>(this L left, R right, search_condition join_criteria)
            where L : sxc.table_source
            where R : sxc.table_source
                => new inner_join<L, R>(left, right, join_criteria);

        public static right_join<L, R> RightJoin<L, R>(this L left, R right, search_condition join_criteria)
            where L : sxc.table_source
            where R : sxc.table_source
                => new right_join<L, R>(left, right, join_criteria);

        public static full_join<L, R> FullJoin<L, R>(this L left, R right, search_condition join_criteria)
            where L : sxc.table_source
            where R : sxc.table_source
                => new full_join<L, R>(left, right, join_criteria);
    }

}