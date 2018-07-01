//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

public enum HeaderAction : byte
{
    None = 0,
    Prefix = 1,
    Replace = 2
}

public class TextFileHeader : TextLine
{

    public static implicit operator TextFileHeader(string content)
        => new TextFileHeader(content);

    public static implicit operator string(TextFileHeader h)
        => toString(h);

    public TextFileHeader(string Content)
        : base(1, Content)
    {


    }
}
