using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

using System.IO;

public static class FileSystem
{



    [SqlProcedure]
    public static void WriteTextToFile(string hostPath, string text)
    {
        File.WriteAllText(hostPath, text);
    }

    [SqlProcedure]
    public static void CopyFile(string SrcPath, string DstPath)
    {
        File.Copy(SrcPath, DstPath, true);
    }

    [SqlProcedure]
    public static void CopyFolder(string SrcPath, string DstPath)
    {
        try

        {
            var srcDir = new DirectoryInfo(SrcPath);
            if (!srcDir.Exists)
                Console.WriteLine($"The source path {SrcPath} does not exist");
            else
            {
                var dstDir =
                    !Directory.Exists(DstPath)
                    ? Directory.CreateDirectory(DstPath)
                    : new DirectoryInfo(DstPath);

                DeepCopy(srcDir, dstDir);
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Unexpected error:{e.Message}");
        }

    }


    [SqlFunction(FillRowMethodName = nameof(DrivesFill), TableDefinition = FileSystemDriveTableSql)]
    public static IEnumerable Drives()
    {
        foreach (var drive in Directory.GetLogicalDrives())
            yield return new FileSystemDrive
            {
                DrivePath = drive
            };
    }


    [SqlFunction(FillRowMethodName = nameof(dir_fill), TableDefinition = FileSystemEntryTableSql)]
    public static IEnumerable Dir(string SrcPath, string filter)
    {

        filter = filter ?? "*.*";
        var option =  SearchOption.TopDirectoryOnly;
        foreach (var path in Directory.EnumerateDirectories(SrcPath, filter, option))
        {
            var info = new DirectoryInfo(path);
            yield return new FileSystemEntry
            {
                IsDirectory = true,
                FilePath = path,
                CreationTime = info.CreationTime,
                LastWriteTime = info.LastWriteTime,
                Size = 0
            };
        }

        foreach (var path in Directory.EnumerateFiles(SrcPath, filter, option))
        {
            var info = new FileInfo(path);
            yield return new FileSystemEntry
            {
                IsDirectory = false,
                FilePath = path,
                CreationTime = info.CreationTime,
                LastWriteTime = info.LastWriteTime,
                Size = info.Length
            };
        }
    }

    static void DeepCopy(DirectoryInfo source, DirectoryInfo target)
    {
        foreach (DirectoryInfo dir in source.GetDirectories())
            DeepCopy(dir, target.CreateSubdirectory(dir.Name));

        foreach (FileInfo file in source.GetFiles())
            file.CopyTo(Path.Combine(target.FullName, file.Name), true);
    }

    public class FileSystemEntry
    {
        public string FilePath { get; set; }
        public bool IsDirectory { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public long Size { get; set; }
    }

    public class FileSystemDrive
    {
        public string DrivePath { get; set; }
    }
    const string FileSystemEntryTableSql
        = "FilePath nvarchar(4000), IsDirectory bit, CreationTime datetime, LastWriteTime datetime, Size bigint";

    public static void dir_fill(object o,
        out SqlString FilePath,
        out SqlBoolean IsDirectory,
        out SqlDateTime CreationTime,
        out SqlDateTime LastWriteTime,
        out SqlInt64 Size
        )
    {
        var entry = o as FileSystemEntry;
        FilePath = entry.FilePath;
        IsDirectory = entry.IsDirectory;
        CreationTime = entry.CreationTime;
        LastWriteTime = entry.LastWriteTime;
        Size = entry.Size;
    }

    const string FileSystemDriveTableSql
        = "DrivePath nvarchar(250)";

    public static void  DrivesFill(object o,
        out SqlString DrivePath)
    {
        var src = o as FileSystemDrive;
        DrivePath = src.DrivePath;
    }


}
