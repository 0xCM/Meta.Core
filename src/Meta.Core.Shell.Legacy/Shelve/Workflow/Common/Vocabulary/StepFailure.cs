//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using static metacore;

    public class StepFailure<P> : StepResult<P>
    {
        public StepFailure(IAppMessage Reason)
            : base(default(P), false, Reason)
        {

        }
    }

    public abstract class StepFailure : StepFailure<object>
    {
        protected StepFailure(IAppMessage Reason)
            : base(Reason)
        {

        }      
    }
}