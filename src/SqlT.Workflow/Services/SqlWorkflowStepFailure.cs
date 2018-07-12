//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Meta.Core.Workflow;
    using SqlT.Core;
    using static metacore;

    public class SqlWorkflowStepFailure : SqlWorkflowStepResult
    {
        public static SqlWorkflowStepFailure Create(IAppMessage Reason)
            => new SqlWorkflowStepFailure(Reason);

        public static SqlWorkflowStepFailure<P> Create<P>(IAppMessage Reason)
            => new SqlWorkflowStepFailure<P>(Reason);

        public SqlWorkflowStepFailure(IAppMessage Reason)
             : base(Reason)
        {


        }


    }

    public class SqlWorkflowStepFailure<P> : SqlWorkflowStepResult<P>
    {

        public SqlWorkflowStepFailure(IAppMessage Reason)
            : base(Reason)
        {

        }


    }
}
