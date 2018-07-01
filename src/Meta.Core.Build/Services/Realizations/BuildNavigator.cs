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

    using static metacore;

    public class BuildNavigator : FileSystemNavigator<BuildNavigator>
    {
        public BuildNavigator(INodeContext C, FolderName Area)
            : base(C)
        {
            NavRoot = CommonFolders.DevAreaRoot + Area;            
        }

        public BuildNavigator(IApplicationContext C, SystemNode Host, FolderName Area)
            : this(C.NodeContext(Host), Area)
        {
            
        }

        public override NodeFolderPath NavRoot { get; }

        public virtual NodeFolderPath AreaConfigFolder
            => NavRoot + FolderName.Parse(".config");

        public IEnumerable<NodeFilePath> AreaConfigFiles(FileExtension x = null)
            => AreaConfigFolder.Files(x,true);

        public IEnumerable<NodeFilePath> AreaPropertyFiles
            => AreaConfigFolder.Files(CommonFileExtensions.Props, true);
    }
}