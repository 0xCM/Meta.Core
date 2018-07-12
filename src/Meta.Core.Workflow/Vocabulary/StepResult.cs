//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using static metacore;

    /// <summary>
    /// Describes the outcome of a step in a workflow
    /// </summary>
    public sealed class StepResult : StepResult<object>
    {

        public StepResult(object Payload, bool Succeeded, IAppMessage Message = null)
            : base(Payload, Succeeded, Message)
        {
        }

        public StepResult(IAppMessage Error)
            : base(Error)
        {
        }
    }
}