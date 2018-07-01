//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using Meta.Core.Messaging;

    public interface IProcessResponseMessge : IMessage
    {
        IProcessCommand Command { get; }

        IProcessResponseMessge Response { get; }

    }

    public interface IProcessResponseMessage<P> : IProcessResponseMessge
        where P : IProcessCommand
    {
        new P Command { get; }
    }

    public interface IProcessResponseMessage<R,P> : IProcessResponseMessage<P>
        where P : IProcessCommand
        where R : IProcessResponseMessge
    {
        new P Command { get; }

        new R Response { get; }

    }


}