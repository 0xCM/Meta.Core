//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

using Meta.Core;

using static metacore;

/// <summary>
/// Represents a text file
/// </summary>
public class TextFile : DataFile<TextLine>, ITextFile
{
    /// <summary>
    /// Creates a temporary file with or without data
    /// </summary>
    /// <param name="data">If specified, the data with which to populate the file</param>
    /// <returns></returns>
    public static FilePath CreateTempFile(string data = null)
    {
        FilePath path = Path.GetTempFileName();
        if (data != null)
            path.Write(data);
        return path;
    }

    /// <summary>
    /// Specifies the canonical empty value
    /// </summary>
    public static TextFile Empty 
        = new TextFile(FilePath.Empty);

    public static implicit operator TextFile(string path) 
        => new TextFile(path);

    public static implicit operator TextFile(FilePath path)
        => new TextFile(path);

    /// <summary>
    /// Initializes a new <see cref="TextFile"/> instance
    /// </summary>
    /// <param name="path">The path to the file</param>
    public TextFile(FilePath path)
        : base(path, MimeTypes.Text)
    {

    }

    /// <summary>
    /// Initializes a new <see cref="TextFile"/> instance
    /// </summary>
    /// <param name="path">The path to the file within a given context</param>
    /// <param name="ancestor">The file from which the new file is derived via an emit operation</param>
    [DebuggerStepThrough]
    internal TextFile(FilePath path, IDataFile ancestor)
        : base(path, MimeTypes.Text, ancestor)
    {

    }

    FilePath SourcePath
        => (this as IDataFile).SourcePath;

    protected virtual string ReadLine(StreamReader reader)
        => reader.ReadLine();

    public override IEnumerable<TextLine> Read()
    {
        using (var reader = new StreamReader(SourcePath))
        {
            var count = 0;
            while(!reader.EndOfStream)
                yield return new TextLine(++count, ReadLine(reader));
        }
    }

    IEnumerable<TextLine> ReadPrepend(TextLine Prepended)
    {
        yield return Prepended;
        var count = 1;
        using (var reader = new StreamReader(SourcePath))
        {
            while (!reader.EndOfStream)
                yield return new TextLine(++count, ReadLine(reader));
        }
    }

    public bool IsSpecified
        => SourcePath.IsEmpty;

    public virtual string ReadAllText()
        => File.ReadAllText(SourcePath);

    public override IDataFile Emit(FilePath path)
    {
        if (path == SourcePath)
            return this;

        File.Copy(SourcePath, path, true);
        return new TextFile(path,this);
    }

    public Option<FilePath> CopyTo(FilePath DstPath, bool Overwrite = true)
        => this.SourcePath.CopyTo(DstPath, Overwrite);

    public Option<FilePath> ReplaceLine(int lineNumber, string replacement, FilePath DstPath)
    {
        try
        {
            using (var reader = new StreamReader(SourcePath))
            {
                using (var writer = new StreamWriter(DstPath))
                {

                    var currentLineNumber = 1;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (currentLineNumber == lineNumber)
                            writer.WriteLine(replacement);
                        else
                            writer.WriteLine(line);
                        currentLineNumber++;
                    }
                }
            }

            return DstPath;
        }
        catch (Exception e)
        {
            return none<FilePath>(e);
        }
    }

    public Option<FilePath> Overwrite(IEnumerable<TextLine> lines)
    {        
        try
        {
            var tmpPath = CreateTempFile();
            using (var writer = new StreamWriter(tmpPath))
                foreach(var line in lines)
                    writer.WriteLine(line.Data);

            var oldTempPath = SourcePath.Rename(SourcePath.FileName.AddExtension("rename"), FilePath.Parse);
            var replacedPath = tmpPath.MoveTo(SourcePath, FilePath.Parse);
            oldTempPath.DeleteIfExists();
            return replacedPath;                        
        }
        catch (Exception e)
        {
            return none<FilePath>(e);
        }
    }

    public Option<FilePath> PrependLine(TextLine line)
        => Overwrite(ReadPrepend(line));

    public Option<FilePath> ReplaceLine(int lineNumber, string replacement)
    => Try(() =>
           {
               var dstPath = CreateTempFile();
               return (from replaced in ReplaceLine(lineNumber, replacement)
                       from overwrite in dstPath.MoveTo(SourcePath,FilePath.Parse)
                       select overwrite);
           });
    
    public IEnumerable<TextLine> ReadFirst(int count)
        => Read().Take(count);
}