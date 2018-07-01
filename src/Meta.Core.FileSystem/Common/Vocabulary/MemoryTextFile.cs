//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static metacore;

/// <summary>
/// Represents a text file stored in memory
/// </summary>
public class MemoryTextFile : MemoryFile<TextLine>, ITextFile
{
    public MemoryTextFile(byte[] data)
        : base(data, MimeTypes.Binary)
    {

    }

    /// <summary>
    /// Streams the file content from memory
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<TextLine> Read()
    {
        using (var stream = CreateStream())
        {
            using (var reader = new StreamReader(stream))
            {
                int count = 0;
                while (!reader.EndOfStream)
                    yield return new TextLine(++count, reader.ReadLine());
            }
        }
    }

    public override IDataFile Emit(FilePath path)
    {
        File.WriteAllBytes(path, data);
        return new TextFile(path, this);
    }

    public IEnumerable<TextLine> ReadFirst(int count)
        => Read().Take(count);

    public Option<FilePath> Overwrite(IEnumerable<TextLine> lines)
        => throw new NotSupportedException();

    public bool IsSpecified
        => true;
}

