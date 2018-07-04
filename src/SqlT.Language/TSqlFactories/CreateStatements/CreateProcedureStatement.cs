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
    using sxc = Syntax.contracts;


    /// <summary>
    /// Implements <see cref="SqlProcedure"/> model translations
    /// </summary>
    partial class TSqlFactory
    {

        [TSqlBuilder]
        public static TSql.CreateProcedureStatement TSqlCreate(this SqlProcedure model)
        {

            var parameters = model.Parameters.Map(p => new TSql.ProcedureParameter
            {
                VariableName = p.ParameterName.TSqlIdentifier(),
                DataType = p.TypeReference.TSqlReference(),
                Modifier = p.TSqlParameterModifier()
            });

            
            var statement = new TSql.CreateProcedureStatement
            {
                ProcedureReference = new TSql.ProcedureReference
                {
                    Name = model.TSqlSchemaObjectName(),
                },

                StatementList = model.Statements.TSqlStatementList()
                                    
            };

            iter(parameters, 
                parameter => statement.Parameters.Add(parameter));

            return statement;
        }



    }
}
