//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    using Meta.Core;
    using Meta.Core.Build;
    using Meta.Core.Shell;

    using MetaFlow.Core;

    using static metacore;


    class PlatformBuildService : ApplicationService<PlatformBuildService, IPlatformBuildService>, IPlatformBuildService
    {
        public PlatformBuildService(IApplicationContext C)
            : base(C)
        {

            this.MetaBuild = C.MetaBuild();
            this.cmd = new commands();
        }

        IMetaBuild MetaBuild { get; }

        Process StartProcess(string exe, string args)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = exe,
                    Arguments = args
                }
            };

            process.Start();

            return process;
        }

        commands cmd { get; }

        public Link<FilePath, Option<BuildSummary>> BuildSolution(FilePath SlnPath)
        {
            var logPath = PlatformVariables.BuildLogDir + SlnPath.FileName.ChangeExtension("binlog");
            var command = cmd.msbuild(SlnPath, logPath);
            var process = StartProcess(command.CommandName + ".exe", command.Format());
            process.WaitForExit();

            return link(SlnPath,MetaBuild.SummarizeStructuredLog(logPath));
        }

        public SolutionBuildResult BuildSystemSolution(SystemIdentifier System)
        {
            var segmentFolder = PlatformVariables.DevAreaDir + FolderName.Parse(System);
            var segmentSolution = segmentFolder + FileName.Parse($"MetaFlow.{System}.sln");
            Notify(inform($"Building {segmentSolution}"));
            var outcome = BuildSolution(segmentSolution);
            outcome.Target.OnNone(Notify).OnSome(summary =>
            {
                Notify(summary.Succeeded
                    ? inform($"Completed {segmentSolution} build")
                    : error($"The {segmentSolution} build failed")
                    );

            });            

            return new SolutionBuildResult(System, segmentSolution, outcome.Target);
        }

        IEnumerable<SystemIdentifier> Systems
           => new PlatformSystems().Where(s => s != PlatformSystems.None);
               

        public PlatformBuildResult BuildPlatform()
            => new PlatformBuildResult(map(Systems, s => BuildSystemSolution(s)));

    }



}