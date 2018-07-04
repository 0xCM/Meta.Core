//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;

    partial class SqlSyntax
    {

        public sealed class owner_name : name<SqlUserName, SqlApplicationRoleName>
        {
            public static implicit operator owner_name(SqlUserName x)
                => new owner_name(x);

            public static implicit operator owner_name(SqlApplicationRoleName x)
                => new owner_name(x);

            public owner_name(SqlUserName x)
                : base(x)
            {

            }

            public owner_name(SqlApplicationRoleName x)
                : base(x)
            {

            }

        }
    }


}