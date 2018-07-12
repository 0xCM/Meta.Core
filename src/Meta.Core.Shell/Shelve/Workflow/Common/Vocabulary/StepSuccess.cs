//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using static metacore;
    public class StepSuccess<P> : StepResult<P>
    {
        public StepSuccess(P Payload, IAppMessage Message)
            : base(Payload, true, Message)
        {

        }
    }

    public abstract class StepSuccess : StepResult<object>
    {
        public StepSuccess(object Payload, IAppMessage Message = null)
            : base(Payload, true, Message)
        {
            if (isNull(Payload))
                throw new ArgumentNullException("No value was supplied for a successful workflow step");
        }
    }
}