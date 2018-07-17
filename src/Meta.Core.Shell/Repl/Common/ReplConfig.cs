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
    /// Common REPL configuration settings
    /// </summary>
    public class ReplConfig
    {
        
        public ReplConfig(FilePath ExePath, Lst<string>? Args = null, FolderPath WorkingFolder = null, FolderPath LogFolder = null)
        {
            this.ExePath = ExePath;
            this.Args = Args ?? Lst.zero<string>();
            this.WorkingFolder = WorkingFolder;
            this.LogFolder = LogFolder;
        }
        /// <summary>
        /// The path to the REPL provider
        /// </summary>
        public FilePath ExePath { get; }

        /// <summary>
        /// The arguments supplied to the adapted process when created
        /// </summary>
        public Lst<string> Args { get; }

        /// <summary>
        /// Specifies the working directory of the adapted process
        /// </summary>
        public Option<FolderPath> WorkingFolder { get; }

        /// <summary>
        /// The folder into which REPL session data is persisted
        /// </summary>
        public Option<FolderPath> LogFolder { get; }

    }

    /// <summary>
    /// Base type for REPL-specific configurations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ReplConfig<T> : ReplConfig
        where T : ReplConfig<T>
    {
        protected ReplConfig(FilePath ExePath, Lst<string>? Args = null, FolderPath WorkingFolder = null, FolderPath LogFolder = null)
            : base(ExePath,Args,WorkingFolder,LogFolder)
        {

        }
    }
}
