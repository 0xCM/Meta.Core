//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System;
    using static metacore;

    /// <summary>
    /// Encapsulates a collection of projects whose targets comprise a Component Group
    /// </summary>
    public class SolutionModule
    {    
        public static SolutionModule Create(SolutionName Name, FilePath SolutionPath = null)
            => new SolutionModule(Name);

        DevSolutionState State { get; }

        public SolutionModule(SolutionName SolutionName, FilePath SolutionPath = null)
        {
            this.SolutionName = SolutionName;
            this.SolutionPath = SolutionPath ?? FilePath.Empty;
            this.State = new DevSolutionState
            {
                SolutionName = SolutionName
            };
        }
    
        public SolutionName SolutionName { get; }

        public FilePath SolutionPath { get; }

        public override string ToString()
            => SolutionName.ToString();

        public FileWriteResult Save(FilePath outpath = null)
        {
            var text = State.ToString();
            if (outpath != null && not(outpath.IsEmpty))
                return outpath.Write(text);
            else if (not(SolutionPath.IsEmpty))
                return SolutionPath.Write(text);
            else
                return (FolderPath.Parse(Environment.CurrentDirectory) + FileName.Parse($"{SolutionName.ToString()}.sln")).Write(text);
        }
    }
}
