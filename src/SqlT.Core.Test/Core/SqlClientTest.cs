//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Test
{
    using System;

    using Meta.Core;
    using Meta.Core.Workflow;

    using SqlT.Core;

    public readonly struct SqlTestOutcome
    {
        public static implicit operator SqlTestOutcome(bool success)
            => new SqlTestOutcome(success);

        

        public SqlTestOutcome(bool Succeeded)
        {
            this.Success = Succeeded;
        }
        public bool Success { get; }


    }


    [WorkflowNode]
    public class SqlClientTest : WorkflowNode<SqlTestOutcome>
    {

        protected SqlContext SqlTestContext(string database = null)
            => new SqlContext(this.WorkflowContext, SqlConnectionString.Local.ChangeDatabase(database ?? "SqlT.Syntax"));

        protected ISqlClientOptionBroker ClientBroker(string database = null)
            => SqlTestContext(database).SqlClientBroker();

        protected static SqlTestOutcome success()
            => true;

        public SqlClientTest(IWorkflowContext C)
            : base(C)
        {

        }


        public WorkFlowed<SqlTestOutcome> Test01()
        {

            var broker = ClientBroker();
            var results = broker.Select("select * from [Syntax].[Keyword]");



            return success();
         
        }
    }


}