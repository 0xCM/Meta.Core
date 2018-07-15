//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    using static metacore;

    using N = SystemNode;

    using Modules;

    /// <summary>
    /// Defines extensions related to the file system
    /// </summary>
    public static class FileX
    {
        /// <summary>
        /// Gets the name of a file relative to a folder
        /// </summary>
        /// <param name="File">The path to the file</param>
        /// <param name="Folder">The folder to which a relative path should be constructed</param>
        /// <returns></returns>
        public static RelativePath RelativeTo(this FilePath File, FolderPath Folder)
        {
            var srcUri = new Uri(File);
            var rootUri = new Uri(Folder);
            var relUri = rootUri.MakeRelativeUri(srcUri);
            return relUri.ToString();
        }

        /// <summary>
        /// Writes text to a file
        /// </summary>
        /// <param name="path">The target path</param>
        /// <param name="text">The text to write</param>
        /// <param name="createDir">Specifies whether to create the target directory if it doesn't exist</param>
        /// <param name="overwrite">Specifies whether to overwrite an existing file</param>
        /// <returns></returns>
        public static FileWriteResult Write(this FilePath path, string text, bool createDir = true, bool overwrite = true)
        {
            try
            {
                //The path may just be a filename and the intent is
                //to emit to the current directory
                if (isBlank(Path.GetDirectoryName(path.FileSystemPath)))
                {
                    File.WriteAllText(path, text);
                    return FileWriteResult.Success(path);
                }
                else
                {
                    if (createDir)
                        path.Folder.CreateIfMissing().Require();

                    if (!overwrite)
                    {
                        if (path.Exists())
                            return FileWriteResult.Failure(path,
                                AppMessage.Error($"The file {path} exists and the {nameof(overwrite)} option is false"));
                    }
                    else        
                        File.WriteAllText(path, text);

                    return FileWriteResult.Success(path);
                }

            }
            catch (Exception e)
            {
                return FileWriteResult.Failure(path, e);
            }
        }

        /// <summary>
        /// Moves a file from A to B
        /// </summary>
        /// <param name="Flow">The source/target</param>
        /// <returns></returns>
        public static Option<Link<FilePath>> Move(this Link<FilePath> Flow, bool overwrite = true, bool createFolder = true)
            => Flow.Source.MoveTo(Flow.Target, x => new FilePath(x), overwrite, createFolder).Map(dst => new Link<FilePath>(Flow.Source, dst));

        /// <summary>
        /// Copies the file to a specified destination path
        /// </summary>
        /// <param name="dst">The destination path</param>
        /// <param name="overwrite">Whether to overwrite the destination path if it exists</param>
        /// <returns></returns>
        public static Option<FilePath> CopyTo(this FilePath src, FilePath dst, bool overwrite = true)
            => Try(() =>
            {
                File.Copy(src, dst, overwrite);
                return dst;

            });

        /// <summary>
        /// Moves a file from A to B
        /// </summary>
        /// <param name="Flow">The source/target</param>
        /// <returns></returns>
        public static Option<FilePath> Copy(this Link<FilePath> Flow, bool overwrite = true)
            => Flow.Source.CopyTo(Flow.Target, overwrite);

        /// <summary>
        /// Moves a collection of files from A to B
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<FileCopyResult> CopyTo(this IEnumerable<FilePath> SrcFiles, FolderPath DstFolder, bool overwrite = true)
            => from file in SrcFiles
               select file.CopyTo(DstFolder, overwrite);

        public static Option<FilePath> TryFindPath(this FileName filename, params FolderPath[] SearchFolders)
        {
            var folders = unionize(stream(new FolderPath(Environment.CurrentDirectory)), SearchFolders,
                Environment.GetEnvironmentVariable("path").Split(';').Select(d => new FolderPath(d)));
            foreach (var folder in folders)
            {
                var path = folder + filename;
                if (path.Exists())
                    return path;
            }
            return none<FilePath>();
        }

        public static Option<FilePath> TryFindPath(this FileName filename, IEnumerable<FolderPath> SearchFolders)
            => filename.TryFindPath(SearchFolders.ToArray());

        /// <summary>
        /// Creates a symbolic link to a file
        /// </summary>
        /// <param name="SrcFile">The file to which the link will point</param>
        /// <param name="DstLink">The name of the link</param>
        /// <returns></returns>
        public static Option<FileSymLink> CreateSymLink(this FilePath SrcFile, string DstLink)
            => SymbolicLinks.CreateSymbolicLink(DstLink, SrcFile, SymbolicLinkKind.File) ?
                    some(new FileSymLink(SrcFile, DstLink))
                  : none<FileSymLink>(error($"The {nameof(CreateSymLink)} call failed"));

        static readonly Regex Datestamp
            = new Regex("(?<Datestamp>[0-9]{4}-[0-9]{2}-[0-9]{2})", RegexOptions.Compiled);

        /// <summary>
        /// Attempts to extract a convention-based timestamp from a filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static DateTime? FileNameDatestamp(this FileName filename)
        {
            var m = Datestamp.Match(filename);
            if (m.Success && m.Groups.Count != 0 && m.Groups[0].Success)
                return DateTime.ParseExact(m.Groups[0].Value, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
            else
                return null;
        }

        /// <summary>
        /// Appends a <see cref="FileExtension"/> to a <see cref="FileName"/>
        /// </summary>
        /// <param name="x">The extension to append</param>
        /// <param name="name">The filename</param>
        /// <returns></returns>
        public static FileName AppendTo(this FileExtension x, FileName name)
            => name.Append(x);

        /// <summary>
        /// Appends a <see cref="FileExtension"/> to a <see cref="FilePath"/>
        /// </summary>
        /// <param name="x">The extension to append</param>
        /// <param name="path">The path</param>
        /// <returns></returns>
        public static FilePath AppendTo(this FileExtension x, FilePath path)
        {
            var folder = path.Folder;
            var filename = path.FileName.Append(x);
            var newPath = folder + filename;
            return newPath;
        }

        /// <summary>
        /// Classifies a file change symbolically
        /// </summary>
        /// <param name="ChangeType"></param>
        /// <returns></returns>
        public static string ToSymbol(this FileChangeKind ChangeType)
        {
            switch (ChangeType)
            {
                case FileChangeKind.Added:
                    return "+";
                case FileChangeKind.Modifed:
                    return "Δ";
                case FileChangeKind.Removed:
                    return "-";
                default:
                    return "?";
            }
        }

        /// <summary>
        /// Constructs a unique filename using the extension of the current file
        /// </summary>
        /// <returns></returns>
        public static FilePath UniqueName(this FilePath path)
        {
            var ext = $"{guid().ToString("N")}.{path.Extension}";
            return path.ChangeExtension(ext);
        }

        /// <summary>
        /// Sets the object's <see cref="FileAttributes"/>
        /// </summary>
        /// <param name="fso">The object to modify</param>
        /// <param name="attributes"></param>
        public static void SetAttributes(this IFileSystemObject fso, FileAttributes attributes)
            => File.SetAttributes(fso.FileSystemPath, attributes);

        /// <summary>
        /// Reads the object's <see cref="FileAttributeSet"/> 
        /// </summary>
        /// <param name="fso">The object to examine</param>
        /// <returns></returns>
        public static FileAttributeSet GetAttributes(this IFileSystemObject fso)
            => new FileAttributeSet(File.GetAttributes(fso.FileSystemPath));


        /// <summary>
        /// Determines whether the object is hidden
        /// </summary>
        /// <param name="fso">The object to examine</param>
        /// <returns></returns>
        public static bool IsHidden(this IFileSystemObject fso)
            => fso.GetAttributes().Hidden;

        /// <summary>
        /// Modifies the Hidden flag on the object
        /// </summary>
        /// <param name="fso">The object to modify</param>
        /// <param name="value">The flag value</param>
        public static void SetHiddenFlag(this IFileSystemObject fso, bool value)
        {
            if (value)
            {
                if (!fso.GetAttributes().Hidden)
                    fso.SetAttributes(File.GetAttributes(fso.FileSystemPath) | FileAttributes.Hidden);
            }
            else
            {
                if (fso.GetAttributes().Hidden)
                    fso.SetAttributes(File.GetAttributes(fso.FileSystemPath) ^ ~FileAttributes.Hidden);
            }

        }

        /// <summary>
        /// Determines the value of the object's System flag
        /// </summary>
        /// <param name="fso">The object to examine</param>
        /// <returns></returns>
        public static bool IsSystem(this IFileSystemObject fso)
            => fso.GetAttributes().Hidden;

        /// <summary>
        /// Modifies the System flag on the object
        /// </summary>
        /// <param name="fso">The objectg to modify</param>
        /// <param name="value">The flag value</param>
        public static void SetSystemFlag(this IFileSystemObject fso, bool value)
        {
            if (value)
            {
                if (!fso.GetAttributes().System)
                    fso.SetAttributes(File.GetAttributes(fso.FileSystemPath) | FileAttributes.System);
            }
            else
            {
                if (fso.GetAttributes().System)
                    fso.SetAttributes(File.GetAttributes(fso.FileSystemPath) ^ ~FileAttributes.System);
            }
        }

        /// <summary>
        /// Gets the object's creation timestamp
        /// </summary>
        /// <param name="fso">The objet to examine</param>
        /// <returns></returns>
        public static DateTime CreatedTS(this IFileSystemObject fso)
            => File.GetCreationTime(fso.FileSystemPath);

        /// <summary>
        /// Sets the object's creation time
        /// </summary>
        /// <param name="fso">The objet to modify</param>
        /// <param name="ts">The new timestamp</param>
        public static void CreatedTS(this IFileSystemObject fso, DateTime ts)
            => File.SetCreationTime(fso.FileSystemPath, ts);

        /// <summary>
        /// Gets the object's last write timestamp
        /// </summary>
        /// <param name="fso">The objet to examine</param>
        /// <returns></returns>
        public static DateTime UpdatedTS(this IFileSystemObject fso)
            => File.GetLastWriteTime(fso.FileSystemPath);

        /// <summary>
        /// Sets the object's last write timestamp
        /// </summary>
        /// <param name="fso">The objet to modify</param>
        /// <param name="ts">The new timestamp</param>
        public static void UpdatedTS(this IFileSystemObject fso, DateTime ts)
            => File.SetLastWriteTime(fso.FileSystemPath, ts);

        /// <summary>
        /// Gets the maxmimum of updated/created timestamps
        /// </summary>
        /// <param name="fso"></param>
        /// <returns></returns>
        public static DateTime ChangedTS(this IFileSystemObject fso)
            => max(fso.UpdatedTS(), fso.CreatedTS());

        /// <summary>
        /// Gets the drive on which the file lives, if applicable
        /// </summary>
        public static Option<DriveLetter> HostDrive(this IFilePath path)
            => from p in some(path.FileSystemPath)
               let uri = new FilePath(path.FileSystemPath).AsUri()
               let letter = uri.LocalPath.Length != 0 ? uri.LocalPath[0] : '0'
               from d in DriveLetter.TryParse(letter)
               select d;

        /// <summary>
        /// Determines whether the path representation has an empty value
        /// </summary>
        /// <param name="path">The path to examine</param>
        /// <returns></returns>
        public static bool IsUnspecified(this IFilePath path)
            => isBlank(path.FileSystemPath);

        /// <summary>
        /// Presuming the represented file is a text file, reads and returns the contained text
        /// </summary>
        public static string ReadAllText(this IFilePath path)
            => path.IsUnspecified() ? String.Empty : File.ReadAllText(path.FileSystemPath);

        /// <summary>
        /// Presuming the represented file is a text file, reads and returns the contained text
        /// </summary>
        public static string ReadAllText(this IFilePath path, Encoding encoding)
            => path.IsUnspecified() ? String.Empty : File.ReadAllText(path.FileSystemPath, encoding);

        /// <summary>
        /// Interprets the file as a text file
        /// </summary>
        /// <returns></returns>
        public static TextFile AsTextFile(this IFilePath path)
            => path.IsUnspecified() ? TextFile.Empty : new TextFile(path.FileSystemPath);

        /// <summary>
        /// Determines whether the physical file exists
        /// </summary>
        /// <param name="path">The path to examine</param>
        /// <returns></returns>
        public static bool Exists(this IFilePath path)
            => File.Exists(path.FileSystemPath);

        /// <summary>
        /// Copies the represented file to a specified folder
        /// </summary>
        /// <param name="dstfolder">The target folder</param>
        /// <param name="overwrite"></param>
        /// <param name="createFolder">Specifies whether to create the folder if it doesn't exist</param>
        /// <returns></returns>
        public static FileCopyResult CopyTo(this IFilePath path, FolderPath dstfolder, bool overwrite = true, bool createFolder = true)
        {
            if (createFolder)
                dstfolder.CreateIfMissing();

            var dstpath = dstfolder + path.FileName;
            try
            {
                var exists = path.Exists();
                File.Copy(path.FileSystemPath, dstpath, overwrite);
                return new FileCopyResult(path.FileSystemPath, dstpath, exists && overwrite);
            }
            catch (Exception e)
            {
                return new FileCopyResult(path.FileSystemPath, dstpath, e.Message);
            }
        }

        /// <summary>
        /// Attempts to read the text contained in the file
        /// </summary>
        /// <returns></returns>
        public static Option<string> TryReadAllText(this IFilePath path)
            => path.IsUnspecified() ? some("") : Try(() =>
            {
                if (path.Exists())
                    return path.ReadAllText();

                throw new FileNotFoundException($"The file {path.FileSystemPath} could not be found");
            });

        /// <summary>
        /// Writes text to the file, overwriting the file if it exists
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="createDir"></param>
        /// <returns></returns>
        public static Option<T> WriteLines<T>(this T path, IEnumerable<string> lines, bool createDir = true)
            where T : IFilePath
            => Try(() =>
            {
                if (createDir)
                    path.Folder.CreateIfMissing();

                File.WriteAllLines(path.FileSystemPath, lines);
                return  path;
            });

        /// <summary>
        /// Renames a file
        /// </summary>
        /// <param name="newName">The new filename</param>
        /// <returns></returns>
        public static T Rename<T>(this T path, FileName newName, Func<string, T> Reconstructor)
            where T : IFilePath
        {
            var newPath = path.Folder + newName;
            File.Move(path.FileSystemPath, newPath);
            return Reconstructor(newPath);
        }

        public static FilePath Rename(this FilePath path, FileName newName)
            => path.Rename(newName, p => new FilePath(p));

        /// <summary>
        /// Replaces the content of a specified line in the file
        /// </summary>
        /// <param name="lineNumber">The number of the line to replace</param>
        /// <param name="replacement">The replacement text</param>
        /// <returns></returns>
        public static Option<T> ReplaceLine<T>(this T path, int lineNumber, string replacement)
            where T : IFilePath
            => from r in new TextFile(path.FileSystemPath).ReplaceLine(lineNumber, replacement)
               select path;

        /// <summary>
        /// Appends text to the file
        /// </summary>
        /// <param name="text">The text to append</param>
        /// <returns></returns>
        public static Option<Unit> Append<T>(this T path, string text)
            where T : IFilePath
            => Try(() => {
                File.AppendAllText(path.FileSystemPath, text);
                return Unit.Value;
            });

        /// <summary>
        /// Appends a line of text to the file
        /// </summary>
        /// <param name="text">The text to append</param>
        /// <returns></returns>
        public static Option<Unit> AppendLine<T>(this T path, string text)
            where T : IFilePath
            => Try(() => {
                File.AppendAllLines(path.FileSystemPath, stream(text));
                return Unit.Value;
            });

        /// <summary>
        /// Replaces the content of a specified line in the file and emits the result to a new location
        /// </summary>
        /// <param name="lineNumber">The number of the line to replace</param>
        /// <param name="replacement">The replacement text</param>
        /// <param name="DstPath">The result path</param>
        /// <returns></returns>
        public static Option<T> ReplaceLine<T>(this T path, int lineNumber, string replacement, FilePath DstPath)
            where T : IFilePath
            => from r in new TextFile(path.FileSystemPath).ReplaceLine(lineNumber, replacement, DstPath)
               select path;

        /// <summary>
        /// Creates a shortcut the file
        /// </summary>
        /// <param name="shortcutPath">The location of the shortcut</param>
        /// <param name="shortcutTitle">The name of the shortcut</param>
        /// <param name="iconPath">The path to the icon displayed by the icon, if specied</param>
        /// <returns></returns>
        public static Option<FilePath> CreateShortcut<T>(T path, FilePath shortcutPath, string shortcutTitle = null, FilePath iconPath = null)
            where T : IFilePath
                => Shortcut.Create(path.FileSystemPath, shortcutPath, shortcutTitle, iconPath);
      
        /// <summary>
        /// Deletes the file if it exists, returning true if a file was deleted and false otherwise
        /// </summary>
        /// <returns></returns>
        public static Option<T> DeleteIfExists<T>(this T path)
            where T : IFilePath
        {
            try
            {
                if (File.Exists(path.FileSystemPath))
                    File.Delete(path.FileSystemPath);
                return path;
            }
            catch(Exception e)
            {
                return none<T>(e);
            }
        }

        /// <summary>
        /// Moves the file to a new location
        /// </summary>
        /// <param name="dst">The target path</param>
        /// <param name="overwrite">True if any existing file should be ovewritten</param>
        /// <returns></returns>
        public static Option<T> MoveTo<T>(this T path, FilePath dst, Func<string,T> construct, bool overwrite = true, bool createFolder = true)
            where T : IFilePath
            => Try(() =>
            {
                if (overwrite)
                    dst.DeleteIfExists();

                if (createFolder)
                    dst.Folder.CreateIfMissing();

                File.Move(path.FileSystemPath, dst);
                return construct(dst);
            });


        /// <summary>
        /// Moves the file to a new location
        /// </summary>
        /// <param name="dst">The target path</param>
        /// <param name="overwrite">True if any existing file should be ovewritten</param>
        /// <returns></returns>
        public static Option<FilePath> MoveTo(this FilePath src, FilePath dst, bool overwrite = true, bool createFolder = true)
            => src.MoveTo(dst, p => new FilePath(p), overwrite, createFolder);

        /// <summary>
        /// Reads all lines of text from the file
        /// </summary>
        /// <returns></returns>
        public static Lst<string> ReadAllLines(this IFilePath path)
            => path.IsUnspecified() ? list<string>() : Lst.make(File.ReadAllLines(path.FileSystemPath));

        /// <summary>
        /// Reads all lines of text from the file
        /// </summary>
        /// <returns></returns>
        public static Lst<string> ReadAllLines(this IFilePath path, Encoding encoding)
            => path.IsUnspecified() ? list<string>() : Lst.make(File.ReadAllLines(path.FileSystemPath, encoding));

        /// <summary>
        /// Reads the file into memory as an array of bytes
        /// </summary>
        /// <returns></returns>
        public static byte[] ReadAllBytes(this IFilePath path)
            => path.IsUnspecified() ? new byte[] { } : File.ReadAllBytes(path.FileSystemPath);

        /// <summary>
        /// Reads all bytes from a stream and returns the result
        /// </summary>
        /// <param name="Src">The stream to read</param>
        /// <returns></returns>
        public static Option<byte[]> ReadAllBytes(this Stream Src)
            => Use(new MemoryStream(), stream =>
            {
                Src.CopyTo(stream);
                return stream.ToArray();
            });

        /// <summary>
        /// Reads all the text available from a stream and returns the result
        /// </summary>
        /// <param name="Src">The stream to read</param>
        /// <returns></returns>
        public static string ReadAllText(this Stream Src)
        {
            using (var reader = new StreamReader(Src))
                return reader.ReadToEnd();
        }

        /// <summary>
        /// Reads all lines of text from a file and returns the result
        /// </summary>
        /// <param name="Src">The file to read</param>
        /// <returns></returns>
        public static IReadOnlyList<TextLine> ReadAllLines(this ITextFile Src)
            => mapi(File.ReadAllLines(Src.SourcePath), (i, s) => new TextLine(i + 1, s));


    }

}