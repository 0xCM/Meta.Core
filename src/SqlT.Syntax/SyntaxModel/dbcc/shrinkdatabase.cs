//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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