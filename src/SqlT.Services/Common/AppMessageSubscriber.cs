//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{

    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using SqlT.Core;

    using static metacore;

    class AppMessageSubscriber : IDisposable
    {

        public AppMessageSubscriber(string MessageType, AppMessageObserver Observer, Action<string, AppMessageSubscriber> Quit)
        {
            this.MessageTypeName = MessageType;
            this.Observer = Observer;
            this.Quit = Quit;
        }

        Action<string, AppMessageSubscriber> Quit { get; }

        string MessageTypeName { get; }

        /// <summary>
        /// Gets the observer
        /// </summary>
        public AppMessageObserver Observer { get; }

        public void Dispose()
            => Quit(MessageTypeName, this);
        
    }
}