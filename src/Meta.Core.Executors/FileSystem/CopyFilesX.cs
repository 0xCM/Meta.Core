//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using static metacore;

    using C = CopyFiles;
    using R = FileCopyResults;
    using X = CopyFilesX;


    [CommandPattern]
    class CopyFilesX : CommandExecutionService<X, C, R>
    {
        public CopyFilesX(IApplicationContext context)
            : base(context)
        { }

        protected override Option<R> TryExecute(C command)
        {
            var copied = new List<FileCopyResult>();
            try
            {
                if (command.CreateFolder)
                    command.TargetFolder.CreateIfMissing();

                foreach (var src in command.SourceFiles)
                {
                    var result= src.CopyTo(command.TargetFolder, command.Overwrite);
                    if (result.Succeeded)
                        copied.Add(result);
                    else
                        return none<R>(result.Message);

                }
                return R.Create(copied);
            }
            catch(Exception e)
            {
                return none<R>(e);
            }

        }
    }
}