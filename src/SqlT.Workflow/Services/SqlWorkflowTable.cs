//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using SqlT.Core;


    public class SqlWorkflowTable : ISqlWorkflowTable
    {

        public SqlWorkflowTable(ISqlTabularProxy Proxy, SqlWorkflowState State, bool OperationSucceeded, IAppMessage Description)
        {
            this.Subject = Proxy;
            this.State = State;
            this.Description = Description;
            this.OperationSucceeded = OperationSucceeded;
        }
        public ISqlTabularProxy Subject { get; }

        public SqlWorkflowState State { get; }

        public IAppMessage Description { get; }

        public bool OperationSucceeded { get; }
    }

    
    public class SqlWorkflowTable<P> : SqlWorkflowTable, ISqlWorkflowTable<P>
        where P : ISqlTabularProxy, new()
    {

        public static implicit operator P(SqlWorkflowTable<P> x)
            => x.Subject;

        public SqlWorkflowTable(P Proxy, SqlWorkflowState State = null, bool OperationSucceded = true, IAppMessage Description = null)
            : base(Proxy, State ?? SqlWorkflowStates.Populated, OperationSucceded, Description ?? AppMessage.Empty)
        {
        }

        public new P Subject
            => (P)base.Subject;

    }

}
