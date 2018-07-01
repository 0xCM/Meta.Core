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
/// Represents a drive letter
/// </summary>
public class DriveLetter : DomainPrimitive<DriveLetter,char>
{
    public static DriveLetter Parse(char c)
        => new DriveLetter(c);

    public static Option<DriveLetter> TryParse(char c)
        => IsValid(c) ? Parse(c) : none<DriveLetter>();

    public static implicit operator FolderPath(DriveLetter x)
        => FolderPath.Parse($"{x.Value}:\\");

    public static FolderPath operator +(DriveLetter x, FolderName f)
        => $"{x}:\\{f}";

    public static FolderPath operator +(FolderName f, DriveLetter x)
        => $"{x}:\\{f}";

    public static FilePath operator +(DriveLetter x, FileName f)
        => $"{x}:\\{f}";

    public static FilePath operator +(FileName f, DriveLetter x)
        => $"{x}:\\{f}";

    public static readonly DriveLetter Empty 
        = new DriveLetter();

    public static implicit operator DriveLetter(char c)
        => new DriveLetter(c);

    public static readonly DriveLetter A = 'A';
    public static readonly DriveLetter B = 'B';
    public static readonly DriveLetter C = 'C';
    public static readonly DriveLetter D = 'D';
    public static readonly DriveLetter E = 'E';
    public static readonly DriveLetter F = 'F';
    public static readonly DriveLetter G = 'G';
    public static readonly DriveLetter H = 'H';
    public static readonly DriveLetter I = 'I';
    public static readonly DriveLetter J = 'J';
    public static readonly DriveLetter K = 'K';
    public static readonly DriveLetter L = 'L';
    public static readonly DriveLetter M = 'M';
    public static readonly DriveLetter N = 'N';
    public static readonly DriveLetter O = 'O';
    public static readonly DriveLetter P = 'P';
    public static readonly DriveLetter Q = 'Q';
    public static readonly DriveLetter R = 'R';
    public static readonly DriveLetter S = 'S';
    public static readonly DriveLetter T = 'T';
    public static readonly DriveLetter U = 'U';
    public static readonly DriveLetter V = 'V';
    public static readonly DriveLetter W = 'W';
    public static readonly DriveLetter X = 'X';
    public static readonly DriveLetter Y = 'Y';
    public static readonly DriveLetter Z = 'Z';

    public bool IsEmpty
        => Value == '0';

    DriveLetter()
        : base('0')
    { }

    static bool IsValid(char letter)
        => char.ToUpperInvariant(letter) >= 'A' 
        && char.ToUpperInvariant(letter) <= 'Z';

    public DriveLetter(char letter)
        : base(IsValid(letter)? char.ToUpperInvariant(letter) : '0')
    {

    }

    public override string ToString()
        => $"{Value}:\\";
}
