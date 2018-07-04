//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    using sxc = SqlT.Syntax.contracts;

    public sealed class SqlProcedureBuilder : SqlObjectBuilder<SqlProcedure, SqlProcedureBuilder>
    {
        public static implicit operator SqlProcedure(SqlProcedureBuilder b)
            => b.Complete();

        MutableList<SqlRoutineParameter> parameters = MutableList.Create<SqlRoutineParameter>();
        MutableList<sxc.statement> statements = MutableList.Create<sxc.statement>();
        MutableList<sxc.routine_call> invocations = MutableList.Create<sxc.routine_call>();

        public SqlProcedureBuilder(SqlProcedureName ProcedureName)
            : base(ProcedureName)
        {
            
        }
       
        public SqlProcedureName ProcedureName
            => (SqlProcedureName)ObjectName;

        public override SqlProcedure Complete()
            => new SqlProcedure(ProcedureName, parameters, statements, documentation.ValueOrDefault(), properties);

        public Builder<SqlProcedureBuilder> WithStatements(params sxc.statement[] statements)
            => Step(() => this.statements.AddRange(statements));

        public Builder<SqlProcedureBuilder> WithInvocations(params sxc.routine_call[] invocations)
            => Step(() => this.invocations.AddRange(invocations));

        public Builder<SqlProcedureBuilder> WithStatement<T>(T statement)
            where T : SqlStatement<T>
            => Step(() => this.statements.Add(statement));

        public Builder<SqlProcedureBuilder> WithStatement<T>(Builder<T> statement)
            where T : SqlStatement<T>
            => Step( () => this.statements.Add((T)statement));

        public Builder<SqlProcedureBuilder> WithStatement<T>(SqlModelBuilder<T> builder)
            where T : SqlStatement<T>
             => Step(() => statements.Add(builder.Complete()));

        public Builder<SqlProcedureBuilder> WithParameters(params SqlRoutineParameter[] parameters)
            => Step( () =>this.parameters.AddRange(parameters));

        public Builder<SqlProcedureBuilder> WithDeclarations(params SqlVariableDeclaration[] declarations)
            => Step( () => statements.AddRange(declarations));

        public Builder<SqlProcedureBuilder> TruncateTable(SqlTableName TableName)
            => WithStatements(new SqlTruncateTable(TableName));

    }

    
}
