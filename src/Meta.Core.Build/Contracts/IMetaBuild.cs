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
    using System.Reflection;

    using Meta.Core.Project;
    using Meta.Core.Build;
    

    public interface IMetaBuild : IApplicationService
    {
        Option<SolutionDescription> DescribeSolution(FilePath SrcPath);

        Option<string> BuildSolution(FilePath SolutionPath);

        IReadOnlyList<FilePath> GetProjectFiles(FilePath ProjectFile);

        Option<ProjectDataset> ProjectDataset(FilePath ProjectFile);
        
        IEnumerable<PropertyEvaluation> EvaluateProjectProperties(FilePath ProjectFile);

        IEnumerable<object> EvaluateProjectItems(FilePath ProjectFile);

        IEnumerable<Option<BuildSummary>> SummarizeStructuredLogs(FolderPath SrcDir, FileExtension ext = null);

        Option<BuildSummary> SummarizeStructuredLog(FilePath SrcFile);

        void AddProjectFiles(FilePath ProjectFile, IReadOnlyList<FilePath> files, bool build = false);
    }
}
