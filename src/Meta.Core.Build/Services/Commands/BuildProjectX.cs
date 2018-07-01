//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Build.Framework;
    using Microsoft.Build.Execution;
    using Microsoft.Build.Logging;

    using static metacore;

    using C = BuildProject;
    using X = BuildProjectX;
    using R = Meta.Core.Commands.ToolResult;

    [CommandPattern]
    class BuildProjectX : CommandExecutionService<X, C, R>
    {
        public BuildProjectX(IApplicationContext context)
            : base(context)
        { }
        protected override Option<R> TryExecute(C spec)
        {
            var name = typeof(BuildManager).AssemblyQualifiedName;

            var bm = BuildManager.DefaultBuildManager;            
            var logger = new ConsoleLogger();
            var console = SystemConsole.Get();
            var loggers = new List<ILogger> { new ConsoleLogger() };
            var bg = console.BackgroundColor;
            console.BackgroundColor = ConsoleColor.Black;
            console.Clear();
            var props = spec.Properties.Map(p => (p.Name, p.Value)).ToDictionary(x => x.Item1, x => toString(x.Item2));
            var request = new BuildRequestData(spec.ProjectFile, props, null, spec.Targets.ToArray(), null);

            //var request = new BuildRequestData(spec.ProjectFile,
            //    new Dictionary<string, string>
            //    {
            //        { "Configuration", "Debug" },
            //        { "Platform", "Any CPU" }
            //    }, null, new[] { "Rebuild" }, null);


            var parms = new BuildParameters();
            parms.Loggers = loggers;

            var result = bm.Build(parms, request);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            console.BackgroundColor = bg;

            return new R(
                result.OverallResult == BuildResultCode.Success, 
                result.ResultsByTarget.Values.Where(
                    x => x.Exception != null).Select(x => x.Exception.Message)
                    );

        }
    }




}
