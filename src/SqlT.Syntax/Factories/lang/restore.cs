//-------------------------------------------------------------------------------------------
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
    using sx = SqlSyntax;
    using kwt = SqlKeywordTypes;

    partial class sql
    {
        public static restore_database restore(kwt.DATABASE DATABASE, simple_database_name database_name, 
            kwt.FROM FROM, kwt.DISK DISK, FilePath source_path) 
                => new restore_database(database_name, source_path);
    }
}