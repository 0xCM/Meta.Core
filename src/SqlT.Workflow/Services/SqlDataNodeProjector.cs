namespace SqlT.Workflow
{

    using SqlT.Core;
    using SqlT.Models;

    using Meta.Core;
    using Meta.Core.Workflow;

    using sxc = SqlT.Syntax.contracts;

    public class SqlDataNodeProjector : DataTransformer
    {
        public SqlProcedureName RoutineName { get; }


        protected SqlDataNodeProjector(SqlProcedureName ProcedureName, IDataSource Source, IDataTarget Target)
            : base(new TransformationName(ProcedureName.FullName), Source, Target)
        {
            this.RoutineName = ProcedureName;
        }
    }


    public class SqlDataNodeProjector<P, T> : SqlDataNodeProjector, ISqlWorkflowProc<P, T>
        where P : sxc.procedure

        where T : class, IDataTarget, new()
    {


        protected SqlDataNodeProjector(SqlProcedureName RoutineName, IDataSource Source, IDataTarget<T> Target)
            : base(RoutineName, Source, Target)
        {
            
        }
    }

    public class SqlDataNodeProjector<P, S, T> : SqlDataNodeProjector, ISqlWorkflowProc<P, S, T>
        where P : sxc.procedure
        where S : class, IDataSource, new()    
        where T : class, IDataTarget, new()
    {


        protected SqlDataNodeProjector(SqlProcedureName RoutineName, IDataSource<S> Source, IDataTarget<T> Target)
            : base(RoutineName, Source, Target)
        {

        }


    }
}
