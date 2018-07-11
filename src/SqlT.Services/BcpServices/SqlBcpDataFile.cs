//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;


    using static metacore;


    public sealed class SqlBcpPeriodDataFile : SqlBcpPeriodFile<SqlBcpPeriodDataFile>
    {
        public SqlBcpPeriodDataFile(DateRange Period, SqlTableName SourceTable)
            : base(Period, SourceTable, "dat")
        { }

    }


}