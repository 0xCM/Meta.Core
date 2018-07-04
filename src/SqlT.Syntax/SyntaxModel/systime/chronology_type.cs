//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using SqlT.Models;
    using SqlT.Core;
    
    using System;
    using static SqlKeywordTypes;
    using static SqlTSyntax;
    using sxc = SqlT.Syntax.contracts;

    partial class SqlSyntax
    {
        public class chronology_type :
            du
            <
                DATE,
                TIME,
                DATETIME2,
                DATETIME,
                DATETIMEOFFSET,
                SMALLDATETIME
            >
        {
            public chronology_type(DATE v1)
                : base(v1)
            {

            }

            public chronology_type(TIME v2)
                : base(v2)
            { }


            public chronology_type(DATETIME2 v3)
                : base(v3)
            { }

            public chronology_type(DATETIME v4)
                : base(v4)
            { }

            public chronology_type(DATETIMEOFFSET v5)
                : base(v5)
            { }

            public chronology_type(SMALLDATETIME v6)
                : base(v6)
            { }
        }

    }
 
}