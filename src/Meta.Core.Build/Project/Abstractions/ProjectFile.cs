//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    /// <summary>
    /// Repepresents a file in a project
    /// </summary>
    public abstract class ProjectFile
    {
        protected ProjectFile()
        {

        }

        protected ProjectFile(RelativePath FileLocation, FileName FileName)
        {
            this.FileLocation = FileLocation;
            this.FileName = FileName;
        }

        public RelativePath FileLocation { get; set; }

        public FileName FileName { get; set; }


        public override string ToString()
            => FileLocation + FileName;
    }
}
