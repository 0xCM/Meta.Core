//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System.IO;
    using System.ComponentModel;
    
    using Meta.Core.Commands;
    using Meta.Core.Messaging;
    using Meta.Core.Workflow;

    using static metacore;
    using static ApplicationMessage;

    public sealed class AppCommands : LinkedSession<AppCommands>
    {
        protected override IReadOnlyList<SystemNode> AvailableNodes
            => metacore.rolist<SystemNode>();

        public AppCommands(IApplicationContext C)
            : base(C, SystemNode.Local)
        {
            Cmd = ProcessAdapter.ExecuteCmd(OnStandard, OnError, Inspect);
            CurrentDir = Environment.CurrentDirectory;
            AppCmdX.Init(C);

            var results = HostContext.WorkflowExecution().ExecuteWorkflows(GetType().Assembly).ToList();

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

        

        IApplicationMessage ArchivedFolder(FolderPath SrcFolder, FileArchiveDescription DstArchive)
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

        public void Env()
        {
            Print(EnvVariables(EnvironmentVariableTarget.Process), "Process variables");
            Print(EnvVariables(EnvironmentVariableTarget.User), "User variables");
            Print(EnvVariables(EnvironmentVariableTarget.Machine), "Machine variables");

            var wf = from x in some(1)
                     where x != 0
                     select x;

        }








        public void type(string path)
            => Print((CurrentDir + FileName.Parse(path)).ReadAllLines());


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

        Option<ShellAdapter> _ghci;
        public void ghci(string input)
        {
            void OnData(string data)
            {
                Notify(inform(data));
            }

            void OnError(string data)
            {
                Notify(error(data));
            }

            void Send(ShellAdapter adapter, string data)
            {
                adapter.Send(data);
            }

            _ghci.OnNone(() =>
                _ghci = ShellAdapter.Adapt(@"C:\Dev\Tools\Scoop\apps\haskell\8.4.2\bin\ghci.exe", string.Empty, OnData, OnError)
                                    .OnNone(Notify)
                );

            if(isNotBlank(input))
                _ghci.OnSome(x => Send(x,input));
        }
    }
}