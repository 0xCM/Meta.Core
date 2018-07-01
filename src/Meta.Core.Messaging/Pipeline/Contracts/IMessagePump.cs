//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.Concurrent;    
    using System.Threading;
    using System.Threading.Tasks;


    public interface IMessagePump 
    {
        void EnlistTarget(IMessageReceiver target);

        void EnlistSource(IMessageEmitter source);
    }
    

    public interface IMessagePump<in I, out O> 
        where I : new()
        where O : new()
    {
        void EnlistTarget(IMessageReceiver<O> target);

        void EnlistSource(IMessageEmitter<I> source);

    }

 
    partial class MessageDelegates
    {
        public delegate void TargetEnlister(IMessageReceiver target);
        public delegate void SourceEnlister(IMessageEmitter source);

        public delegate void TargetEnlister<out M>(IMessageReceiver<M> target)
            where M : new();

        public delegate void SourceEnlister<in M>(IMessageEmitter<M> target)
            where M : new();

    }

}