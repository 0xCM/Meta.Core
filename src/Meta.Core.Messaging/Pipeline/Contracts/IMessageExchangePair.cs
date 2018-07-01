//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;


    public interface IMessageExchangePair
    {
        IMessage Input { get; }
        IMessage Output { get; }
    }

    public interface IMessageExchangePair<out I, out O> : IMessageExchangePair
        where I : IMessage
        where O : IMessage
    {
        new I Input { get; }
        new O Output { get; }
    }


    public interface IMessageExchangePair<out I, out O, C> : IMessageExchangePair
        where I : IMessage<C>
        where O : IMessage<C>
    {
        new I Input { get; }
        new O Output { get; }
    }


    public interface IMessageExchangePair<out I, out O, CI, CO> : IMessageExchangePair
        where I : IMessage<CI>
        where O : IMessage<CO>
    {
        new I Input { get; }
        new O Output { get; }
    }




}