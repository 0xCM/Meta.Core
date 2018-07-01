//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines operations that asynchronously emit messages of a specific type
    /// </summary>
    public interface IMessageOutputPipeAsync<out M>
        where M : IMessage
    {
        /// <summary>
        /// Emits a typed message sequence
        /// </summary>
        void Emit(Action<M> observer);

    }

    /// <summary>
    /// Defines operations that emit both typed and untyped message sequences
    /// </summary>
    public interface IMessageOutputPipeAsync
    {
        /// <summary>
        /// Emits an untyped message sequence
        /// </summary>
        void Emit(Action<IMessage> observer);

        /// <summary>
        /// Emits a typed message sequence
        /// </summary>
        /// <typeparam name="O">The output message type</typeparam>
        void Emit<O>(Action<O> observer)
            where O : IMessage;
    }



}