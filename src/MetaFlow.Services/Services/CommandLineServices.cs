//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using Meta.Core.Shell;
    using Meta.Core.Messaging;

    using CL = Meta.Core.Shell.commands_spec;
    using N = SystemNode;

    class CommandLineServices : ApplicationService<CommandLineServices, ICommandLineServices>, ICommandLineServices
    {
        void OnError(MessagePacket packet)
        {
            NotifyError(packet.Payload);
        }

        void OnStandard(MessagePacket packet)
        {
            NotifyStatus(packet.Payload);
        }

        public IProcess Cmd { get; }

        IShellCommandController CommandController { get; }

        N ActiveNode { get; }

        public CommandLineServices(IApplicationContext C)
            : base(C)
        {

            Cmd = ProcessAdapter.ExecuteCmd(OnStandard, OnError, Inspect);
            this.ActiveNode = N.Local;
            this.CommandController = C.Service<IShellCommandController>();          
        }

        IOption SubmitCommand(ICommandSpec command, N CmdNode, CorrelationToken? ct)
            => CommandController.SubmitCommand(command, CmdNode, ct.HasValue ? ct.Value : CorrelationToken.Create());

        public CL.robocopy RoboCopy(Link<FolderPath> Path, FilePath LogDir, CorrelationToken? ct)
            => Cmd.robocopy(new Robocopy(new CL.robocopy()
            {
                source = Path.Source,
                target = Path.Target,
                E = true,
                XF = new string[] { },
                log = LogDir              
            }));

        public CL.rmdir RmDir(FolderPath Folder)
            => Cmd.rmdir(new RmDir(new CL.rmdir(Folder)));
    }
}