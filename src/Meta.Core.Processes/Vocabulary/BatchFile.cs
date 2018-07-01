//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Shell
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;


    public class BatchFile : FilePath<BatchFile>
    {

        public BatchFile()
        { }


        public BatchFile(string Path)
            : base(Path)
        { }

        public BatchScript ReadScript()
            => new BatchScript(this.ReadAllText());

        protected override Func<string, BatchFile> Reconstructor
            => path => new BatchFile(path);

    }


}