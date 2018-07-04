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
        public sealed class shrinkdatabase : dbcc<shrinkdatabase>
        {
            public shrinkdatabase(SqlDatabaseName database_name)
            {
                this.database_name = database_name;
            }

            public Option<SqlDatabaseName> database_name { get; }

            public override string ToString()
                => database_name.Map(
                    db => $"dbcc shrinkdatabase('{db.UnqualifiedName}')",
                    () => $"dbcc shrinkdatabase(0)");
        }

    }


}