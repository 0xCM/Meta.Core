//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    partial class SqlTFactory
    {

        [TSqlBuilder]
        public static TSql.DropSequenceStatement TSqlStatement(this SqlDropSequence src)
        {
            var dst =new TSql.DropSequenceStatement
            {
                 IsIfExists = src.CheckExistence,              
            };
            dst.Objects.Add(src.SequenceName.TSqlSchemaObjectName());
            return dst;
        }


    }
}
