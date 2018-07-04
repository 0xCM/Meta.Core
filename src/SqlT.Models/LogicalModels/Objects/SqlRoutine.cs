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
    using System.Text;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    using static metacore;

    /// <summary>
    /// Base type for database procedure and function elements
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public abstract class SqlRoutine<R> : SqlObject<R>
        where R : SqlRoutine<R>
    {
        public readonly IReadOnlyList<SqlRoutineParameter> Parameters;
        public readonly IReadOnlyList<sxc.statement> Statements;

        public SqlRoutine
        (
            sxc.ISqlObjectName RoutineName, 
            IEnumerable<SqlRoutineParameter> Parameters = null,
            IEnumerable<sxc.statement> Statements = null, 
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null
            

        ) : base
            (
                 ObjectName: RoutineName, 
                 Documentation : Documentation, 
                 Properties : Properties
            )
        {
            this.Statements = Statements?.ToReadOnlyList() ?? rolist<sxc.statement>() ;
            this.Parameters = rolist(Parameters);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(ObjectName);
            sb.Append("(");
            for(int i=0; i< Parameters.Count; i++)
            {
                sb.Append(Parameters[i]);
                if (i != Parameters.Count - 1)
                    sb.Append(", ");
            }
            sb.Append(")");

            return sb.ToString();
        }


    }


    public abstract class SqlRoutine<R,N> : SqlRoutine<R>, sxc.sql_object<N>
        where R : SqlRoutine<R,N>
        where N : sxc.ISqlObjectName, new()
    {
        public SqlRoutine
        (
            N Name,
            IEnumerable<SqlRoutineParameter> Parameters = null,
            IEnumerable<sxc.statement> Statements = null,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null
            

        ) : base
            (
                 RoutineName: Name,
                 Parameters: Parameters,
                 Statements: Statements,
                 Documentation: Documentation,
                 Properties: Properties
            )
        {
        }

        N IModel<N>.Name
            => (N)base.ElementName;
    }



}
