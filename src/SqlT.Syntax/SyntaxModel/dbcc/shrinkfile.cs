//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    using SqlT.Core;
    using static metacore;

    using static SqlSyntax;
    using sxc = contracts;


    partial class SqlSyntax
    {

        /// <summary>
        /// See https://docs.microsoft.com/en-us/sql/t-sql/database-console-commands/dbcc-shrinkfile-transact-sql
        /// </summary>
        public sealed class shrinkfile : dbcc<shrinkfile>
        {
            public shrinkfile(SqlFileName filename, int target_size = 0, bool truncate_only = true)
            {
                this.filename = filename;
                this.target_size = 0;
                this.truncate_only = truncate_only;
            }

            public SqlFileName filename { get; }

            public bool truncate_only { get; }

            public int target_size { get; }

            public IKeyword truncate_option
                => truncate_only ? TRUNCATEONLY as IKeyword : NOTRUNCATE;

            public override string ToString()
                => concat($"{DBCC} ({squote(filename)},{target_size},{truncate_option})");

        }


    }

}