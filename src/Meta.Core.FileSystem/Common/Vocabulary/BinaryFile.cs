//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/// <summary>
/// Represents a binary file
/// </summary>
public class BinaryFile : DataFile<BinaryFileSegment>, IBinaryFile
{
    public static byte[] ReadAllBytes(FilePath path)
        => File.ReadAllBytes(path.FileSystemPath);


    public BinaryFile(FilePath SourcePath)
        : base(SourcePath, MimeTypes.Binary)
    {
            
    }

    public BinaryFile(FilePath SourcePath, IDataFile Ancestor)
        : base(SourcePath, MimeTypes.Binary, Ancestor)
    {

    }

    FilePath SourcePath
        => (this as IDataFile).SourcePath;

    public bool IsSpecified
        => true;

    public override IEnumerable<BinaryFileSegment> Read() 
        => new[] { new BinaryFileSegment(File.ReadAllBytes(SourcePath)) };  

    public override IDataFile Emit(FilePath path)
    {
        if (path == SourcePath)
            return this;

        File.Copy(SourcePath, path, true);
        return new BinaryFile(path, this);
    }

    /// <summary>
    /// Streams arrays of bytes to the caller
    /// </summary>
    /// <param name="maxlen">The maximum length of a yielded array</param>
    /// <returns></returns>
    public IEnumerable<BinaryFileSegment> Read(int maxlen)
    {
        using(var reader = new BinaryReader(File.Open(SourcePath, FileMode.Open)))
        {
            byte[] data = reader.ReadBytes(maxlen);
            while(data.Length > 0)
            {
                yield return new BinaryFileSegment(data);
                data = reader.ReadBytes(maxlen);
            }
        }   
    }
}

