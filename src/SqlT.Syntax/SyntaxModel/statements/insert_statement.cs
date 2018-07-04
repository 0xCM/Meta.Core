//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using SqlT.Core;

    using sxc = contracts;

    partial class SqlSyntax
    {

       public class insert_statement : statement<insert_statement>
       {

            public insert_statement(table_or_view_name target_object, column_list target_columns)
                : base(INSERT)
            {



            }

        }


     

    }

}