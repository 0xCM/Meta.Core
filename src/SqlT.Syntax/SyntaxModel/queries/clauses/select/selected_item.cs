//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using Meta.Models;
    using SqlT.Core;

    using kwt = SqlKeywordTypes;
    
    partial class SqlSyntax
    {
        /// <summary>
        /// An item that appears in a <see cref="select_list"/>
        /// </summary>
        public class selected_item : du<kwt.STAR, SqlColumnName, select_expression>
        {
            public static implicit operator selected_item(kwt.STAR v)
                => new selected_item(v);

            public static implicit operator selected_item(SqlColumnName v)
                => new selected_item(v);

            public static implicit operator selected_item(select_expression v)
                => new selected_item(v);

            public selected_item(kwt.STAR x)
                : base(x) {}

            public selected_item(SqlColumnName x)
                : base(x){}

            public selected_item(select_expression x)
                : base(x)
            { }
        }
    }

}