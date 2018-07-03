//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using static metacore;

/// <summary>
/// Specifies an identifier
/// </summary>
public struct ClrItemIdentifier 
{
    public static readonly ClrItemIdentifier Empty = new ClrItemIdentifier(string.Empty);


    static readonly IReadOnlyDictionary<string, string> IdentifierReplacements
        = new Dictionary<string, string>
        {
            ["class"] = "@class",
            ["namespace"] = "@namespace",
            ["params"] = "@params",
            ["0"] = "_0",
            ["1"] = "_1",
            ["2"] = "_2",
            ["3"] = "_3",
            ["4"] = "_4",
            ["5"] = "_5",
            ["6"] = "_6",
            ["7"] = "_7",
            ["8"] = "_8",
            ["9"] = "_9",
            ["10"] = "_10",
            ["11"] = "_11",
            ["12"] = "_12",
            ["13"] = "_13",
            ["14"] = "_14",
            ["15"] = "_15",

        };

    static readonly IReadOnlyDictionary<char, char> CharacterReplacements
        = new Dictionary<char, char>
        {
            [' '] = '_',
            ['#'] = 'Ʌ',
            ['!'] = 'ȼ',
            ['$'] = 'ʂ',
            ['+'] = 'ɸ',
            ['-'] = 'ɱ',
        };


    static readonly HashSet<char> IllegalLeads
        = new HashSet<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public static readonly ClrItemIdentifier Missing 
        = new ClrItemIdentifier();

    public static implicit operator ClrItemIdentifier(string x) 
        => new ClrItemIdentifier(x);

    public static implicit operator string(ClrItemIdentifier x) 
        => x.Value;    

    public ClrItemIdentifier(string candidate)
    {
        if (isBlank(candidate))
            Value = string.Empty;
        else
        {
            var tmp =
                IdentifierReplacements.TryFind(candidate)
                                      .ValueOrElse(() => candidate.ReplaceAny(CharacterReplacements));
            this.Value = tmp.StartsWithAny(IllegalLeads) ? "_" + tmp : tmp;
        }
    }

    public string Value { get; }

    public bool IsEmpty
        => isBlank(Value);

    public override string ToString() 
        => Value;

}


