//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;

using static metacore;

/// <summary>
/// Specifies the name of a <see cref="ClrInterface"/>
/// </summary>
public class ClrInterfaceName : ClrTypeName<ClrInterfaceName>
{
    public static readonly ClrInterfaceName Anonymous = new ClrInterfaceName();

    public static ClrInterfaceName Define(string Name)
        => Name;

    public static implicit operator ClrInterfaceName(string x) 
        => new ClrInterfaceName(x);

    public ClrInterfaceName(params ClrItemIdentifier[] Components)

        : base(Components)
    { }

    public ClrInterfaceName(IEnumerable<ClrTypeParameterName> ParameterNames, params ClrItemIdentifier[] Components)
        : base(ParameterNames, Components)
    { }

    public ClrInterfaceName Rename(string NewName)
        => new ClrInterfaceName(array(ParentComponents, new ClrItemIdentifier(NewName)));
}