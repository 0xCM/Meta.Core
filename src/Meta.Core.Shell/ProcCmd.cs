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
    using Meta.Core.Shell;
    using Meta.Core.Messaging;
    using Meta.Core.Workflow;
    using Meta.Core.Build;

    using static metacore;
    using static AppMessage;
    using CL = Shell.commands_spec;


    public sealed class ProcCmd : LinkedSession<ProcCmd>
    {

        public ProcCmd(IApplicationContext C)
            : base(C, SystemNode.Local)
        {
            Cmd = ProcessAdapter.ExecuteCmd(OnStandard, OnError, Inspect);


        }
        public IProcess Cmd { get; }

        void OnError(MessagePacket packet)
        {
            NotifyError(packet.Payload);


        }

        void OnStandard(MessagePacket packet)
        {
            NotifyStatus(packet.Payload);
        }

        //public Option<SolutionDescription> ParseSolution(string path)
        //    => C.MetaBuild().DescribeSolution(path).OnNone(Notify);

        public void BuildSolutions(params string[] SolutionPaths)
           => iter(SolutionPaths, BuildSolution);

        public void BuildSolution(string SolutionPath)
        {
            var result = Cmd.msbuild(new MsBuildTool(new commands_spec.msbuild()
            {
                project = FilePath.Parse(SolutionPath)
            }));

            Print(result);
        }

        [ShellCommand, Description("Removes a directory")]
        public CL.rmdir rmdir(string target)
            => Cmd.rmdir(new RmDir(new CL.rmdir(target)));

        public CL.robocopy robocopy(string src, string dst, string log, bool E = true, string XF = null)
            => Cmd.robocopy(new Robocopy(new CL.robocopy()
            {
                source = src,
                target = dst,
                E = E,
                XF = isBlank(XF) ? array<string>() : array(XF),
                log = log
            }));

        void RoboFlow(Link<FolderPath> flow)
        {
            var result = Cmd.robocopy(new Robocopy(new CL.robocopy()
            {
                source = flow.Source,
                target = flow.Target,
                E = true
            }));

        }


        public void SendMeThere(string Where)
        {
            var dstFolder = FolderPath.Parse(Where);
            var exePath = FilePath.Parse(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            var configPath = exePath.AddExtension("config");
            var srcLibFolder = exePath.Folder.Subfolder("lib");
            var dstLibFolder = dstFolder.Subfolder("lib");

            exePath.CopyTo(dstFolder);
            configPath.CopyTo(dstFolder);
            RoboFlow(new Link<FolderPath>(srcLibFolder, dstLibFolder));
        }

        public void Distribute(string srcDistId, string dstNodeId, string dstDir)
        {
            var srcDir = CommonFolders.DistRootDir + FolderName.Parse(srcDistId);
            var log = FilePath.Parse($@"C:Temp\logs\{srcDistId}.dist.log");
            var flow = new Link<FolderPath>(srcDir, dstDir);
            var result = Cmd.robocopy(new Robocopy(new CL.robocopy()
            {
                source = flow.Source,
                target = flow.Target,
                E = true,
                log = log
            }));

            Print(result);

        }

    }
}