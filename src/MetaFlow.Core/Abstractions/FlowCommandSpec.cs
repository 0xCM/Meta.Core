//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using static metacore;


    public abstract class FlowCommandSpec<TSpec,TPayload> : CommandSpec<TSpec,TPayload>, ICorrelated
        where TSpec : FlowCommandSpec<TSpec,TPayload>, new()

    {
        protected FlowCommandSpec()
        {
            SpecName = GetType().Name;
        }

        [CommandParameter]
        public CorrelationToken? CT { get; set; }


        protected FlowCommandSpec(CorrelationToken CT)
        {
            this.CT = CT;
            SpecName = $"{GetType().Name}/{CT}";
        }
    }
}
