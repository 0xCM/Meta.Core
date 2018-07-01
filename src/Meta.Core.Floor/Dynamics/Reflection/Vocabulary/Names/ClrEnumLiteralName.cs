//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;



/// <summary>
/// Specifies the name of a <see cref="ClrEnumLiteral"/>
/// </summary>
public class ClrEnumLiteralName : ClrMemberName<ClrEnumLiteralName>
{

    public static implicit operator ClrEnumLiteralName(ClrItemIdentifier x)
        => new ClrEnumLiteralName(x);

    public static implicit operator ClrEnumLiteralName(string x)
        => new ClrEnumLiteralName(x);

    public ClrEnumLiteralName(ClrItemIdentifier Identifier)
        : base(Identifier)
    { }
}







