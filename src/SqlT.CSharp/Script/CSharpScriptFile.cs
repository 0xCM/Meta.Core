//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using Meta.Core;

    using static metacore;


    public class CSharpScriptFile : FilePath<CSharpScriptFile>
    {
        public CSharpScriptFile()
        {

        }

        public CSharpScriptFile(FilePath Path)
            : base(Path)
        {

        }

        public string Body
            => this.ReadAllText();

        protected override Func<string, CSharpScriptFile> Reconstructor
            => filename => new CSharpScriptFile(filename);
    }

}