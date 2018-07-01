//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core.Messaging;
    
    using static metacore;
    using static ApplicationMessage;

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

        protected override IEnumerable<IShellSession> SupportedSessions
            => stream(new AppCommands(C));
    }
}
