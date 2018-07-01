//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    public sealed class ExecutableFileName : SemanticFileName<ExecutableFileName>
    {
        public ExecutableFileName()
            : base(string.Empty)
        {

        }

        public ExecutableFileName(string Text)
            : base(Text)
        {

        }

        public override FileExtension CanonicalExtension
            => CommonFileExtensions.Dll;

        protected override Func<string, ExecutableFileName> Reconstructor
            => text => new ExecutableFileName(text);

    }
}