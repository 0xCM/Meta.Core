﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    public sealed class ProcessCommandResponseAdapter : ProcessCommandResponse<ProcessCommandAdapter>
    {
        public ProcessCommandResponseAdapter(ProcessCommandAdapter command, IProcessResponseMessge adapted_response)
            : base(command,adapted_response)
        {
            
        }


    }


}