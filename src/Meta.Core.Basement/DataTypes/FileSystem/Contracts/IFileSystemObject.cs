//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

public interface IFileSystemObject
{
    /// <summary>
    /// The represented path
    /// </summary>
    string FileSystemPath { get; }

}