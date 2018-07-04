namespace SqlT.Workflow
{
    using SqlT.Core;
    using SqlT.Models;
    using sxc = Syntax.contracts;
    using Meta.Core.Workflow;

    public interface ISqlWorkflowFunction<F,out T> : IDataTransformer
        where F : sxc.table_function
        where T : class, IDataTarget, new()
    {

    }

    public interface ISqlWorkflowFunction<F, in S, out T> : IDataTransformer
        where F : sxc.table_function
        where S : class, IDataSource, new()
        where T : class, IDataTarget, new()
    {

    }

    public interface ISqlWorkflowFunction<F, in S1, in S2, out T> : IDataTransformer
        where F : sxc.table_function
        where S1 : class, IDataSource, new()
        where S2 : class, IDataSource, new()
        where T : class, IDataTarget, new()
    {

    }


}
