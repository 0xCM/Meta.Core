//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using Meta.Syntax;
    using SqlT.Core;

    using static SqlSyntax;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;


    partial class SqlSyntax
    {

        public sealed class create_message_type : create_statement<create_message_type, SqlMessageTypeName>
        {

            public create_message_type(SqlMessageTypeName element_name)
                : base(MESSAGETYPE, element_name)
            {
                
            }


            public override string ToString()
                => $"{CREATE} {MESSAGE} {TYPE} {element_name}";
        }

        public sealed class create_message_types : SyntaxList<create_message_types, create_message_type>
        {

            public static implicit operator create_message_types(create_message_type[] items)
                => new create_message_types(items);

            public create_message_types()
            { }

            public create_message_types(params create_message_type[] items)
                : base(items)
            { }
        }
    }

}