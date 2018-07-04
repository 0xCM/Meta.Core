//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using static SqlSyntax;
    
    partial class SqlSyntax
    {

        public sealed class alter_database : alter_statement<alter_database>
        {
            public alter_database(simple_database_name database_name, params IModel[] content)
                : base(DATABASE)
            {
                this.database_name = database_name;
                this.cotent = content;
            }
        

            public simple_database_name database_name { get; }

            public SyntaxList<IModel> cotent {get;}
        }
    } 
}