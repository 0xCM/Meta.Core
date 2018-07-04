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

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static metacore;
    using static SqlSyntax;

    public static partial class sql
    {
        public static alter_database alter(kwt.DATABASE DATABASE,
           simple_database_name database_name,
           kwt.SET SET,
           kwt.SINGLE_USER SINGLE_USER,
           kwt.WITH WITH,
           kwt.ROLLBACK ROLLBACK,
           kwt.IMMEDIATE IMMEDIATE)
               => new alter_database(database_name, SET, SINGLE_USER, WITH, ROLLBACK, IMMEDIATE);

        public static alter_database alter(kwt.DATABASE DATABASE,
            simple_database_name database_name,
            kwt.SET SET,
            kwt.MULTI_USER MULTI_USER)
                => new alter_database(database_name, SET, MULTI_USER);

        public static alter_index alter(kwt.INDEX INDEX, SqlIndexName name,
            kwt.ON ON, table_or_view_name parent_object, kwt.REBUILD REBUILD)
            => new alter_index(name, parent_object, REBUILD);

        public static alter_index alter(kwt.INDEX INDEX, SqlIndexName name,
            kwt.ON ON, table_or_view_name parent_object, kwt.DISABLE DISABLE)
            => new alter_index(name, parent_object, DISABLE);

    }

}