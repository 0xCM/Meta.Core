//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    using MetaFlow.WF;

    using static metacore;

    public interface ISystemEventReaction
    {
        ISystemEventCapture Initiator { get; }

        bool Succeeded { get; }

        IAppMessage Consequence { get; }

    }


}