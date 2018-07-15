using System;
using System.IO;

using Meta.Core;
using static minicore;

public static class FileSystemUtilities
{    
    
    /// <summary>
    /// Attempts to read the text contained in the file
    /// </summary>
    /// <returns></returns>
    public static Option<string> TryReadAllText(this IFilePath path)
        => Try(() =>
        {
            if (path.Exists())
                return File.ReadAllText(path.FileSystemPath);

            throw new FileNotFoundException($"The file {path.FileSystemPath} could not be found");
        });

    /// <summary>
    /// Attempts to read the text contained in the file
    /// </summary>
    /// <returns></returns>
    public static Option<IFilePath> TryWriteAllText(this IFilePath path, string text)
        => Try(() =>
        {
            File.WriteAllText(path.FileSystemPath, text);
            return path;
        });

}

