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
    using System.Linq.Expressions;

    using SqlT.Core;


    using sx = SqlSyntax;

    using static metacore;

    partial class sql
    {
        public static sx.shrinkfile shrinkfile(SqlFileName filename, int target_size = 0, bool truncate_only = true)
           => new sx.shrinkfile(filename, target_size, truncate_only);

    }
}
