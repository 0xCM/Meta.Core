//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public interface IFilePath : IFileSystemObject
{

    /// <summary>
    /// Specifies the name of the file
    /// </summary>
    FileName FileName { get; }

    /// <summary>
    /// Specifies the folder in which the file lives
    /// </summary>
    IFolderPath Folder { get; }

    /// <summary>
    /// Determines whether the represented object exists in the file system
    /// </summary>
    /// <returns></returns>
    bool Exists();
}