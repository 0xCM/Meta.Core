//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    public class ToolInfo
    {
        public ToolInfo(FolderName Folder, FileName FileName, string Label, string Description)
        {
            this.Folder = Folder;
            this.FileName = FileName;
            this.Label = Label;
            this.Description = Description;
        }

        /// <summary>
        /// The folder in which the tool is installed
        /// </summary>
        public FolderName Folder { get; }

        /// <summary>
        /// The tool's filename
        /// </summary>
        public FileName FileName { get; }

        /// <summary>
        /// The display moniker
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Indicates the nature/purpose of the tool
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Specifies the tool's full-qualified file system path
        /// </summary>
        public FilePath Path
            => Folder + FileName;

        public override string ToString()
            => Path;


    }

    public class ToolSuite
    {
        public ToolSuite(FolderName RootFolder, Lst<ToolInfo> Tools, string Label, string Description)
        {
            this.RootFolder = RootFolder;
            this.Tools = Tools;
            this.Label = Label;
            this.Description = Description;
        }

        /// <summary>
        /// The top-most folder under which tools in the suite live
        /// </summary>
        public FolderName RootFolder { get; }

        /// <summary>
        /// The tools that belong to the suite
        /// </summary>
        public Lst<ToolInfo> Tools { get; }

        /// <summary>
        /// The display moniker
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Indicates the nature/purpose of the suite
        /// </summary>
        public string Description { get; }

    }
}