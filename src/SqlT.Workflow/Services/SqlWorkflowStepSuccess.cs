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

    public class SqlWorkflowStepSuccess<P> : SqlWorkflowStepResult<P>
    {

        public SqlWorkflowStepSuccess(P Payload, IAppMessage Message)
            : base(Payload, true, Message)
        {
        }

    }


    public class SqlWorkflowStepSuccess : SqlWorkflowStepResult
    {
        public static SqlWorkflowStepSuccess<P> Create<P>(P Payload, IAppMessage Message = null)
            => new SqlWorkflowStepSuccess<P>(Payload, Message);

        public static SqlWorkflowStepSuccess Create(object Payload, IAppMessage Message)
            => new SqlWorkflowStepSuccess(Payload, Message);

        protected object UntypedPayload { get; }

        public SqlWorkflowStepSuccess(object Payload, IAppMessage Message = null)
             : base(Payload, true, Message)
        {

            this.UntypedPayload = Payload;
        }


    }



}