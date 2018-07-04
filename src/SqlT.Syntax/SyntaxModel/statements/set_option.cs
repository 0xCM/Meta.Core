//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    using static SqlSyntax;
    using Meta.Syntax;


    partial class SqlSyntax
    {

        public class set_option : statement<set_option>
        {

            public set_option(params IKeyword[] value)
                : base(SET)
            {
                this.value = value;
            }



            public keyword_list value { get; }
        }


    }




}