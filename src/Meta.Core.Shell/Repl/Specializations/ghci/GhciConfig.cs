//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    /// <summary>
    /// Defines settings that are specific to the <see cref="GhciRepl"/> adapter
    /// </summary>
    public sealed class GhciConfig : ReplConfig<GhciConfig>
    {
        public GhciConfig(FilePath ExePath, Lst<string>? Args = null, FolderPath WorkingFolder = null, FolderPath LogFolder = null)
            : base(ExePath, Args, WorkingFolder, LogFolder)
        {


        }


    }
}