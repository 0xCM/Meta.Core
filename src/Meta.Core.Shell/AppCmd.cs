//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.ComponentModel;
    
    using Meta.Core.Commands;
    using Meta.Core.Messaging;
    using Meta.Core.Workflow;

    using static metacore;
    using static AppMessage;

    public sealed class AppCommands : LinkedSession<AppCommands>
    {
        protected override IReadOnlyList<SystemNode> AvailableNodes
            => metacore.rolist<SystemNode>();

        public AppCommands(IApplicationContext C)
            : base(C, SystemNode.Local)
        {
            Cmd = ProcessAdapter.ExecuteCmd(OnStandard, OnError, Inspect);
            CurrentDir = Environment.CurrentDirectory;

        }

        void OnError(MessagePacket packet)
        {
            NotifyError(packet.Payload);            
        }

        void OnStandard(MessagePacket packet)
        {
            NotifyStatus(packet.Payload);
        }

        IMessage Inspect(IMessage message)
        {

            return message;
        }

        public IProcess Cmd { get; }

        

        IAppMessage ArchivedFolder(FolderPath SrcFolder, FileArchiveDescription DstArchive)
            => Inform($"Archived @FolderPath to @ArchivePath", new
            {
                DstArchive.ArchivePath
            });

        [ShellCommand, Description("Creates a ZIP file from the contents of a directory")]
        public void zipDir(string SrcFolder, string DstArchive)
        {
            
            var dst = FilePath.Parse(DstArchive).DeleteIfExists().Require();
            var src = FolderPath.Parse(SrcFolder);
            var command = new CreateFileArchive(src, dst);
            CPS.Execute(command)
                .OnNone(Notify)
                .OnSome(archive => ArchivedFolder(src, archive));           
        }


        Seq<(string, string)> EnvVariables(EnvironmentVariableTarget target)
            => Environment.GetEnvironmentVariables(target).Tupelize<string, string>();

        void Print<T>(Seq<T> items, string header = null)
        {
            if (isNotBlank(header))
            {
                NotifyStatus(header);
                NotifyStatus(new string('-', 80));
            }
            iter(items.Stream(), item => NotifyStatus($"{item}"));
        }




        public void CopyFile(string srcFile, string dstFolder)
            => FilePath.Parse(srcFile).CopyTo(dstFolder, true, true).ToOption().OnMessage(Notify);


        IFileMonitor FileMonitor
            => C.SourceContext.Agent<IFileMonitor>(FileMonitorSettings.AgentId);

        void Listen(FileChangeDescription FileChange)
        {
            Notify(inform(FileChange.ToString()));                
        }

        public void MonitorPath(string path)
            => C.MonitorFilePath(path, Listen);

        public void StartFileMonitor()
            => FileMonitor.StartIfNotRunning().OnMessage(Notify);

        public void StopFileMonitor()
            => FileMonitor.StopIfRunning().OnMessage(Notify);

        public void CreateSymLink(string LinkPath, string TargetPath)
            => FolderPath.Parse(TargetPath).CreateSymLink(LinkPath,false).OnMessage(Notify);


        public void GenerateArtifacts()
        {
            C.IconStore().GenerateArtifacts()
                         .OnNone(Notify)
                         .OnSome(artifacts => Notify(inform($"Emitted artifacts: {list(artifacts)}")));
        }

        public class MessageA
        {
            public string Content { get; set; }
        }


        IQueueBroker QueueBroker
            => C.NodeContext(ExecutingNode).QueueBroker();


        public void msg()
        {
            QueueBroker.Subscribe<MessageA>(a => Notify(inform($"Received {a.Content}")));
            QueueBroker.Subscribe<MessageA>(a => Notify(inform($"Received {a.Content}")));
            QueueBroker.Publish(new MessageA { Content = "Hello" });
        }

        INodeContext HostContext
            => C.NodeContext(ExecutingNode);

        IWorkflowContext WorkflowContext
            => Workflow.WorkflowContext.Define(HostContext);
            
        public void tests()
        {
            iter(HostContext.WorkflowExecution().ExecuteWorkflows(Assembly.GetExecutingAssembly()),
                    result => Notify(result.Description));               
                 
        }

        Option<GhciRepl> _ghci;
        GhciConfig _ghciConfig = new GhciConfig(@"J:\Tools\stack\programs\x86_64-windows\ghc-8.4.3\bin\ghci.exe");

        public void ghci(string message)
        {
            if (_ghci.IsNone())
                _ghci = GhciRepl.Create(C, _ghciConfig).OnNone(Notify).OnSome(_ => Notify(inform($"Created ghci process")));

            _ghci.OnSome(adapter => adapter.Send(message));
                    
        }


    }



    
}