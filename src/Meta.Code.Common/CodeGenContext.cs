//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class GenContext
    {


        public GenContext()
        {
            this.InputPath = string.Empty;
            this.InputContent = string.Empty;
            this.TargetNamespace = string.Empty;
        }

        public GenContext(string InputPath, string InputContent, string DefaultNamespace)
        {
            this.InputPath = InputPath;
            this.InputContent = InputContent;
            this.TargetNamespace = DefaultNamespace;
        }

        /// <summary>
        /// The path to the file that drives the generation process
        /// </summary>
        public string InputPath { get; }

        /// <summary>
        /// The content of file at <see cref="InputPath"/>
        /// </summary>
        public string InputContent { get; }

        /// <summary>
        /// The default namespace into which generated artifacts are
        /// emitted
        /// </summary>
        public string TargetNamespace { get; }

    }
}
