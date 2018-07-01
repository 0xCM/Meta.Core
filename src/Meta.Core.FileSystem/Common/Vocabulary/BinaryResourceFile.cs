//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;

using Meta.Core;

/// <summary>
/// Represents a file embedded as a binary resource
/// </summary>
public class BinaryResourceFile : DataFile<BinaryFileSegment>, IBinaryFile
{

    public BinaryResourceFile(Assembly a, string resname)
        : base($"assembly://{a.GetName().Name}/{resname}", MimeTypes.Binary)
    {
        this.a = a;
        this.resname = resname;
    }


    Assembly a { get; }

    string resname { get; }

    Stream GetResourceStream()
        => a.GetManifestResourceStream(resname);

    public override IEnumerable<BinaryFileSegment> Read()
    {
        using (var stream = GetResourceStream())
            yield return new BinaryFileSegment(stream.ReadAllBytes().Require());
    }

    public override IDataFile Emit(FilePath path)
    {
        using (var stream = GetResourceStream())
        {
            File.WriteAllBytes(path, stream.ReadAllBytes().Require());
            return new BinaryFile(path, this);
        }

    }

    public IEnumerable<BinaryFileSegment> Read(int maxlen)
    {
        using (var stream = GetResourceStream())
        {
            using (var reader = new BinaryReader(stream))
            {
                byte[] data = reader.ReadBytes(maxlen);
                while (data.Length > 0)
                {
                    yield return new BinaryFileSegment(data);
                    data = reader.ReadBytes(maxlen);
                }

            }
        }
    }
}
