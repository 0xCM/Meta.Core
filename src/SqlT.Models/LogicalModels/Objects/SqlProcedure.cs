//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    public abstract class SqlProcedure<P> : SqlRoutine<P, SqlProcedureName>, sxc.procedure
        where P : SqlProcedure<P>
    {
        protected SqlProcedure
            (
                SqlProcedureName Name,
                IReadOnlyList<SqlRoutineParameter> Parameters = null,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                bool IsIntrinsic = false

            )
            : base
                (
                  Name,
                  Parameters: Parameters,
                  Statements: Statements,
                  Properties: Properties,
                  Documentation: Documentation
                )
        {
        }


    }

    public abstract class SqlProcedure<P, X> : SqlProcedure<P>
        where P : SqlProcedure<P, X>
    {
        protected SqlProcedure
            (
                SqlProcedureName Name,
                IReadOnlyList<SqlRoutineParameter> Parameters = null,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null,
                bool IsIntrinsic = false

            )
            : base
                (
                  Name,
                  Parameters: Parameters,
                  Statements: Statements,
                  Properties: Properties,
                  Documentation: Documentation,
                  IsIntrinsic: IsIntrinsic
                )
        {
        }


    }


    public abstract class SqlProcedure<P, X, Y> : SqlProcedure<P, X>
        where P : SqlProcedure<P, X, Y>
    {
        protected SqlProcedure
            (
                SqlProcedureName Name,
                IReadOnlyList<SqlRoutineParameter> Parameters = null,
                IEnumerable<sxc.statement> Statements = null,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null

            )
            : base
                (
                  Name,
                  Parameters: Parameters,
                  Statements: Statements,
                  Properties: Properties,
                  Documentation: Documentation
                )
        {
        }


    }






    /// <summary>
    /// Characterizes a procedure
    /// </summary>
    [SqlElementType(SqlElementTypeNames.Procedure)]
    public sealed class SqlProcedure : SqlProcedure<SqlProcedure>
    {

        public SqlProcedure
            (
                SqlProcedureName Name,
                IReadOnlyList<SqlRoutineParameter> Parameters,
                IEnumerable<sxc.statement> Statements,
                SqlElementDescription Documentation = null,
                IEnumerable<SqlPropertyAttachment> Properties = null
            )
            : base
            (
                Name,
                Parameters: Parameters,
                Statements: Statements,
                Documentation: Documentation,
                Properties: Properties
            )
        {

        }

    }










}
