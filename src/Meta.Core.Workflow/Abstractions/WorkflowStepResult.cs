//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using static metacore;

    public abstract class StepResult<P>:  IStepResult<P>
    {
        public StepResult(P Payload, bool Succeeded, IApplicationMessage Message = null)
        {
            this.Payload = Payload;
            this.Succeeded = Succeeded;
            this.Message
                = (isNull(Message) || Message.IsEmpty)
                ? (Succeeded ? inform($"Workflow step {GetType().Name} succeeded") : error($"Workflow step {GetType().Name} failed"))
                : Message;
        }

        public StepResult(IApplicationMessage Error)
        {
            this.Payload = default(P);
            this.Succeeded = false;
            this.Message
                = (isNull(Message) || Message.IsEmpty)
                ? (Succeeded ? inform($"Workflow step {GetType().Name} succeeded") : error($"Workflow step {GetType().Name} failed"))
                : Message;
        }

        public P Payload { get; }

        public bool Succeeded { get; }

        public IApplicationMessage Message { get; }

        object IStepResult.Payload
            => Payload;

        public override string ToString()
            => Message.Format(false);
    }




}