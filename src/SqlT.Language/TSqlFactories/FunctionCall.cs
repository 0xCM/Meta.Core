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
    using SqlT.Syntax;
    
    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using sxc = SqlT.Syntax.contracts;    

    public static partial class TSqlFactory
    {
        public static TSql.FunctionCall TSqlFunctionCall(this sxc.scalar_function f, params SqlParameterValue[] parameters)
        {
           
            var call = new TSql.FunctionCall
            {
                FunctionName =  f.Name.UnquotedLocalName.TSqlIdentifier(f.Name.quoted)
            };

            foreach (var parameter in parameters)
                call.Parameters.Add(parameter.AssignedValue.TSqlLiteral());

            return call;
        }

    }
}