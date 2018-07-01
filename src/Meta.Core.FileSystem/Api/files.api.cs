//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Meta.Core;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using N = SystemNode;

public static class files
{
    /// <summary>
    /// Searches the folder according to specified filter and recursion options
    /// </summary>
    /// <param name="folder">The folder to search</param>
    /// <param name="match">The pattern to match, if any</param>
    /// <param name="recursive">Whether the search should be recursive</param>
    /// <returns></returns>
    public static IEnumerable<FilePath> search(FolderPath folder, string match = null, bool recursive = false)
        => folder.Files(match, recursive);

    /// <summary>
    /// Assigns an icon to a folder
    /// </summary>
    /// <param name="folder">The target folder</param>
    /// <param name="icon">The icon</param>
    /// <param name="tooltip">Optional hint text</param>
    /// <returns></returns>
    public static Option<Link<FolderPath, FilePath>> iconify(FolderPath folder, FilePath icon, string tooltip = null)
        => folder.AssignIcon(icon, tooltip);

    /// <summary>
    /// Defines a symbolic link for a directory
    /// </summary>
    /// <param name="source">The folder to which a link will be created</param>
    /// <param name="link">The link that will reference the source folder</param>
    /// <param name="overwrite"></param>
    /// <returns></returns>
    public static Option<FolderSymLink> link(FolderPath link, FolderPath source, bool overwrite = true)
        => source.CreateSymLink(link, overwrite);

    /// <summary>
    /// Defines a <see cref="FolderName"/> representation via the <see cref="FolderPath.Parse(string)"/> constructor function
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FolderName folderName(string name)
        => FolderName.Parse(name);

    /// <summary>
    /// Defines a <see cref="FolderPath"/> representation via the <see cref="FolderPath.Parse(string)"/> constructor function
    /// </summary>
    /// <param name="path">The folder path</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FolderPath folder(string path)
        => FolderPath.Parse(path);

    /// <summary>
    /// Defines a node-relative path to a folder
    /// </summary>
    /// <param name="node">The node to which the path is relative</param>
    /// <param name="path">The folder path</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static NodeFolderPath folder(N node, string path)
        => new NodeFolderPath(node, FolderPath.Parse(path));

    /// <summary>
    /// Defines a <see cref="FileName"/>representation via the <see cref="FileName.Parse(string[])"/> constructor function
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FileName filename(string name)
        => FileName.Parse(name);

    /// <summary>
    /// Defines a <see cref="FileExtension"/> representation via the <see cref="FileExtension.Parse(string)"/> constructor function
    /// </summary>
    /// <param name="name">The extension name with or without the leading '.'</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FileExtension extension(string name)
        => FileExtension.Parse(name);

    /// <summary>
    /// Defines a <see cref="FilePath"/> representation
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FilePath file(string path)
        => FilePath.Parse(path);

    /// <summary>
    /// Defines a node-relative path to a file
    /// </summary>
    /// <param name="node">The node to which the path is relative</param>
    /// <param name="path">The folder path</param>
    /// <returns></returns>
    [DebuggerStepperBoundary, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static NodeFilePath file(N node, string path)
        => new NodeFilePath(node, path);

}
