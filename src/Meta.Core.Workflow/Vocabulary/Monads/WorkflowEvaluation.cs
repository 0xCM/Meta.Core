//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;

using System;
using System.Linq;
using System.Collections.Generic;

public struct WorkflowEvaluation<W>
{

    public WorkflowEvaluation(WorkFlowed<W> flow)
    {

        if (flow.Succeeded)
        {
            try
            {
                this.Payload = flow.Payload.ToReadOnlyList();
                this.Evaluated = flow.StripPayload(inform("Evaluated"));
                this.Succeeded = true;
                this.Description = Evaluated.Description;

            }
            catch (Exception e)
            {
                this.Payload = rolist<W>();
                this.Description = error(e);
                this.Evaluated = flow;
                this.Succeeded = false;
            }
            
        }
        else
        {
            this.Evaluated = flow;
            this.Description = flow.Description;
            this.Payload = rolist<W>();
            this.Succeeded = false;
        }
        

    }

    public WorkFlowed<W> Evaluated { get; }

    public IAppMessage Description { get; }

    public bool Succeeded { get; }

    public IReadOnlyList<W> Payload { get; }

    public override string ToString()
        => Description.Format(false);
}
