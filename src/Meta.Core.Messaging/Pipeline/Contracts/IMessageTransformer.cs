//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System.Collections.Generic;

    public interface IMessageTransformer<in I, out O>
        where I : new()
        where O : new()
    {
        IEnumerable<O> Transform(IEnumerable<I> messages);
    }

    public interface IMessageTransformer
    {
        IEnumerable<object> Transform(IEnumerable<object> messages);

        IEnumerable<O> Transform<I,O>(IEnumerable<I> messages)
            where I : new()
            where O : new();
    }


    partial class MessageDelegates
    {

        public delegate IEnumerable<IMessage> Transformer(IEnumerable<IMessage> messages);
        public delegate IEnumerable<O> Transformer<in I, out O>(IEnumerable<I> messages)
            where I : new()
            where O : new();

    }
}