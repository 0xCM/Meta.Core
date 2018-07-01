//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    /// <summary>
    /// Repepresents a file within a <see cref="DevProject"/> 
    /// </summary>
    public class ProjectContentFile : ProjectFile
    {
        public ProjectContentFile()
        {

        }

        public ProjectContentFile(RelativePath FileLocation, FileName FileName, string Content)
            : base(FileLocation, FileName)
        {
            this.Content = Content;
        }


        public string Content { get; set; }

        public override string ToString()
            => Content;
    }
}
