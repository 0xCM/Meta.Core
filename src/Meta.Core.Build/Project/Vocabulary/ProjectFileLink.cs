//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    /// <summary>
    /// Repepresents a link to a file
    /// </summary>
    public class ProjectFileLink : ProjectFile
    {
        public ProjectFileLink()
        {

        }

        public ProjectFileLink(RelativePath FileLocation, FileName FileName)
            : base(FileLocation, FileName)
        {
            this.FileLocation = FileLocation;
            this.FileName = FileName;
       }


        public override string ToString()
            => FileLocation + FileName;
    }
}
