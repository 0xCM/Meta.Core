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
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sx = Syntax.SqlSyntax;

    public static partial class TSqlFactory
    {
        public static TSql.CreateSchemaStatement TSqlCreate(this SqlSchema model)
            => new TSql.CreateSchemaStatement
            {
                Name = model.Name.TSqlIdentifier()
            };


        public static TSql.CreateSchemaStatement TSqlCreate(this sx.create_schema src)
        {
            var statement = new TSql.CreateSchemaStatement
            {
                Name = src.element_name.TSqlIdentifier()
            };

            return statement;

        }

    }
}