﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    public class ProjectEmissionOptions
    {
        public ProjectEmissionOptions()
        {
            ProjectRootLocation = $"$({nameof(ProjectRootLocation)})";
        }


        public FolderPath ProjectRootLocation { get; set; }

        public FilePath ResolveFilePath(FileName Filename)
            => ProjectRootLocation + Filename;

        public FilePath ResolveFilePath(RelativePath Path, FileName FileName)
            => ProjectRootLocation + Path + FileName;

    }


}