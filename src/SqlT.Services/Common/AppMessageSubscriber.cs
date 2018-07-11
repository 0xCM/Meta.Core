//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

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