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

/// <summary>
/// Represents a line in a text file
/// </summary>
public class TextLine : DataFileSegment<string>
{
    public static IReadOnlyList<TextLine> ReadAll(string text)
    {
        var lines = MutableList.Create<TextLine>();
        var lineNumber = 0;
        using (var reader = new StringReader(text))
        {
            var next = reader.ReadLine();
            while (next != null)
            {
                lines.Add(new TextLine(++lineNumber, next));
            }
        }
        return lines;
    }

    public static explicit operator TextLine(string text) 
        =>  new TextLine(0, text);

    public static implicit operator string(TextLine line) 
        => line.Data;

    public TextLine(int rowNumber, string lineText)
        : base(lineText)
    {
        this.RowNumber = rowNumber;
    }

    public int RowNumber { get; private set; }

    public override string ToString() 
        =>  $"{RowNumber.ToString().PadLeft(10, '0')}:{Data}";

    public string this[int startpos, int endpos] 
        => Data.Substring(startpos, endpos - startpos + 1);

    public bool IsEmpty 
        => String.IsNullOrWhiteSpace(Data);
}

