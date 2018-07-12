//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Meta.Core.Workflow;
    using SqlT.Core;
    using static metacore;

    

    public class SqlWorkflowStepResult<P> : StepResult<P>, ISqlStepResult<P>
    {

        public SqlWorkflowStepResult(P Payload, bool Succeeded, IAppMessage Message = null)
            : base(Payload, Succeeded, Message)
        {

        }

        public SqlWorkflowStepResult(IAppMessage Error)
            : base(Error)
        {

        }

    }

    public abstract class SqlWorkflowStepResult : StepResult<object>, ISqlStepResult
    {



        protected SqlWorkflowStepResult(object Payload, bool Succeeded, IAppMessage Message = null)
            : base(Payload, Succeeded, Message)
        { }

        protected SqlWorkflowStepResult(IAppMessage Error)
            : base(Error)
        { }

    }





}