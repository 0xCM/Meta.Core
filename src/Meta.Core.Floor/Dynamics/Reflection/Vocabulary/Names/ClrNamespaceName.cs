//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

/// <summary>
/// Specifies the name of a namespace
/// </summary>
public sealed class ClrNamespaceName : ClrElementName<ClrNamespaceName>
{
    public static implicit operator ClrNamespaceName(string x)
        => new ClrNamespaceName(x);


    public ClrNamespaceName(params ClrItemIdentifier[] Components)
        : base(Components)
    {

    }

    public ClrNamespaceName(string Text)
        : base(Text)
    {

    }

    public ClrNamespaceName(params string[] components)
        : base(string.Join(".", components.Where(c => isNotBlank(c))))
    {

    }


}
