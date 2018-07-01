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
    /// Defines operations that emit message sequences of a specific type
    /// </summary>
    public interface IMessageOutputPipe<out O>
        where O : IMessage
    {
        /// <summary>
        /// Emits a typed message sequence
        /// </summary>
        IEnumerable<O> Emit();
    }



    /// <summary>
    /// Defines operations that emit both typed and untyped message sequences
    /// </summary>
    public interface IMessageOutputPipe
    {
        /// <summary>
        /// Emits an untyped message sequence
        /// </summary>
        IEnumerable<IMessage> Emit();

        /// <summary>
        /// Emits a typed message sequence
        /// </summary>
        /// <typeparam name="M">The output message type</typeparam>
        IEnumerable<M> Emit<M>()
            where M : IMessage;
    }


}
