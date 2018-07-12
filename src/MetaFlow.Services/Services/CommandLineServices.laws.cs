//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using CL = Meta.Core.Shell.commands_spec;
    using static metacore;

    public interface ICommandLineServices
    {
        CL.robocopy RoboCopy(Link<FolderPath> Path, FilePath LogDir, CorrelationToken? ct);

        CL.rmdir RmDir(FolderPath Folder);
    }

}