namespace SqlT.Workflow
{
    using SqlT.Core;
    using SqlT.Models;
    using Meta.Core.Workflow;

    using sxc = SqlT.Syntax.contracts;

    public interface ISqlWorkflowProc<P> 
        where P : class, ISqlProcedureProxy, new()
    {
        P Proxy { get; }

        ISqlProxyBroker Broker { get; }
    }

    public interface ISqlWorkflowProc<P, out T> : IDataTransformer
        where P : sxc.procedure
        where T : class, IDataTarget, new()
    {

    }

    public interface ISqlWorkflowProc<P, in S, out T> : IDataTransformer
        where P : sxc.procedure
        where S : class, IDataSource, new()
        where T : class, IDataTarget, new()
    {

    }
}