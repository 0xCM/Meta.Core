﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;

    using static SqlSyntax;
    using static metacore;
    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    partial class sql
    {

        public static backup_database backup(kwt.DATABASE DATABASE, SqlDatabaseName database_name, 
            kwt.TO TO, kwt.DISK DISK, FilePath target_path) 
                => new backup_database(database_name, target_path);


    }

}
 