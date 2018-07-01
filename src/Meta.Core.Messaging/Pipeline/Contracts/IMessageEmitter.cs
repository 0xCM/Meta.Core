//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines contract for a source that can emit untyped messages
    /// </summary>
    public interface IMessageEmitter
    {
        IEnumerable<IMessage> Emit();
    }

    /// <summary>
    /// Defines contract for a source that can emit typed messages
    /// </summary>
    public interface IMessageEmitter<out M>
        where M: new()
        
    {
        IEnumerable<M> Emit(Func<bool> Cancel = null);
    }


    partial class MessageDelegates
    {
       
        public delegate IEnumerable<M> Emitter<out M>()
            where M : new();
            

    }
}