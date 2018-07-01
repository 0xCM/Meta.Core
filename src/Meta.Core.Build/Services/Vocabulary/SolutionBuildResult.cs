//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using static metacore;

    public class SolutionBuildResult
    {
        public SolutionBuildResult(SystemIdentifier OwningSystem, FilePath SolutionPath, Option<BuildSummary> Summary)
        {
            this.OwningSystem = OwningSystem;
            this.SolutionPath = SolutionPath;
            this.Summary = Summary;
        }

        public SystemIdentifier OwningSystem { get; }

        public FilePath SolutionPath { get; }

        public Option<BuildSummary> Summary { get; }

        public bool Succeeded
            => Summary.MapValueOrDefault(s => s.Succeeded, false);

        public override string ToString()
            => concat(OwningSystem, " build ", Succeeded ? "success" : "fail");
    }
}