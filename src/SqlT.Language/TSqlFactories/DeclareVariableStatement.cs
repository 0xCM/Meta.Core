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
    using SqlT.Syntax;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {
        [TSqlBuilder]
        public static TSql.DeclareVariableStatement TSqlStatement(this SqlVariableDeclaration src)
        {
            var test = src.FormatSyntax();


            var dst = new TSql.DeclareVariableStatement();
            dst.Declarations.Add(new TSql.DeclareVariableElement
            {
                DataType = src.VariableType.TSqlReference(),
                VariableName = src.VariableName.TSqlIdentifier(false),
                Value = src.Initializer.MapValueOrDefault(x => SqlParser.ParseScalarExpression(x.FormatSyntax()))
            });
            return dst;
        }

    }
}