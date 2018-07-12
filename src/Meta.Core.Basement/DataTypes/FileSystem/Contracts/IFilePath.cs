//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public interface IFilePath : IFileSystemObject
{

    FileName FileName { get; }

    IFolderPath Folder { get; }
}