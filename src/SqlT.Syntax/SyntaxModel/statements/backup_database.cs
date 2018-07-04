﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using sxc = contracts;
    using static SqlSyntax;
    using SqlT.Core;

    partial class SqlSyntax
    {

        public sealed class backup_database : statement<backup_database>
        {
            public backup_database(SqlDatabaseName database_name, FilePath target_path, int? stats = null, bool compress = true)
                : base(DATABASE)
            {
                this.database_name = database_name;
                this.target_path = target_path;
                this.stats = stats ?? 1;
                this.compress = compress;
               
            }


            public SqlDatabaseName database_name { get; }

            public FilePath target_path { get; }

            public int stats { get; }

            public bool compress { get; }
                    
            public override string ToString()
                => concat($"{BACKUP} {database_name} {TO} {DISK} = {target_path}, {STATS} = {stats}", 
                        compress ? COMPRESSION : string.Empty
                    );
        }
    }
}