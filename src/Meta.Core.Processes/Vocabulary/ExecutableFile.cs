//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    using static metacore;

    public class ExecutableFile : SemanticFilePath<ExecutableFile,ExecutableFileName>
    {

        public ExecutableFile()
        {

        }

        protected override Func<string, ExecutableFile> Reconstructor
            => path => new ExecutableFile(path);

        public static ExecutableFile FromFileName(FileName FileName)
            => new ExecutableFile(FileName.ToString());

        public static ExecutableFile FromPath(FilePath FileName)
            => new ExecutableFile(FileName);

        public ExecutableFile(FilePath Path)
            : base(Path)
        {

        }

        Process StartProcess(string args, bool createWindow)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = not(createWindow),
                    UseShellExecute = createWindow,
                    FileName = this,
                    Arguments = args
                }
            };

            process.Start();

            return process;

        }


        public Process Execute(string args, bool createWindow = false)
            => StartProcess(args, createWindow);

        public Option<FilePath> SaveBatchScript(string args, FilePath DstPath)
            => DstPath.Write($"{this} {args}").ToFileOption();

    }
}