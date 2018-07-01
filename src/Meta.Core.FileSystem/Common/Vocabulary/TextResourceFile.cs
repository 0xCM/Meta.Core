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


/// <summary>
/// Represents and provides access to a text file that has been embedded into an assembly as a resource
/// </summary>
public class TextResourceFile : DataFile<TextLine>, ITextFile
{
    readonly Assembly a;
    readonly string resname;

    public TextResourceFile(Assembly a, string resname)
        : base($"assembly://{a.GetName().Name}/{resname}", MimeTypes.Text)
    {
        this.a = a;
        this.resname = resname;
    }

    public override IEnumerable<TextLine> Read()
    {
        int count = 0;
        using (var stream = a.GetManifestResourceStream(resname))
        {
            using (var r = new StreamReader(stream))
            {
                while (!r.EndOfStream)
                    yield return new TextLine(++count, r.ReadLine());
            }

        }
    }

    public override IDataFile Emit(FilePath path)
    {
        File.WriteAllLines(path, Read().Select(x => x.Data));
        return new TextFile(path, this);
    }

    public IEnumerable<TextLine> ReadFirst(int count)
        => Read().Take(count);

    public Option<FilePath> Overwrite(IEnumerable<TextLine> lines)
        => throw new NotSupportedException();


    public bool IsSpecified
        => true;

}


