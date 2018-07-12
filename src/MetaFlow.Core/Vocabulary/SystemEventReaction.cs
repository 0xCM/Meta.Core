//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using MetaFlow.WF;

    public class SystemEventReaction : ISystemEventReaction
    {

        public SystemEventReaction(ISystemEventCapture Initiator, bool Succeeded, IAppMessage Consequence)
        {
            this.Initiator = Initiator;
            this.Succeeded = Succeeded;
            this.Consequence = Consequence;
        }

        public bool Succeeded { get; }

        public ISystemEventCapture Initiator { get; }


        public IAppMessage Consequence { get; }
    }



}