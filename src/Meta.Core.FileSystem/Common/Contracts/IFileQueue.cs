//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using static metacore;

public interface IFileQueue
{
    Task Move(IFileQueue TargetQueue, Action<(FilePath SourceFile, Option<FilePath> TargetFile)> moved);
    IEnumerable<(FilePath SourceFile, Option<FilePath> TargetFile)> Move(IFileQueue TargetQueue);

    Task Copy(IFileQueue TargetQueue, Action<(FilePath SourceFile, Option<FilePath> TargetFile)> copied);

    IEnumerable<(FilePath SourceFile, Option<FilePath> TargetFile)> Copy(IFileQueue TargetQueue);

}
