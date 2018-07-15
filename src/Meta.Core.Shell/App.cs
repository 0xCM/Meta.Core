//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using Meta.Core.Messaging;
    
    using static metacore;
    using static AppMessage;

    class MetaShell : MetaApp<MetaShell>, IShellCommandProvider
    {

        static int Main(string[] args)
            => HandleMain(args);        

        public MetaShell()
        {
            
        }

        void OnError(MessagePacket packet)
        {
            Notify(Error(packet.Payload));
        }

        void OnStandard(MessagePacket packet)
        {
            Status(packet.Payload);
        }

        protected override Seq<IShellSession> SupportedSessions
            => seq(new AppCommands(C) as IShellSession);
    }
}
