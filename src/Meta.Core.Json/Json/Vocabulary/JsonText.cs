//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Represents a block of uninterpreted JSON text
/// </summary>
class JsonText : ValueObject<JsonText>
{
    public static implicit operator string(JsonText x)
        => x.Text;

    public static implicit operator JsonText(string x)
        => new JsonText(x);

    /// <summary>
    /// The encapsulated text
    /// </summary>
    public readonly string Text;

    public JsonText(string Text)
    {
        this.Text = Text;
    }

    public override string ToString()
        => Text;
}
