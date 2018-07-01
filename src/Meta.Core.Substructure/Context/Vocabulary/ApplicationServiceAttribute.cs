//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class ApplicationServiceAttribute : Attribute
{

    public ApplicationServiceAttribute(string ImplementorName = null)
    {
        this.ImplementationName = ImplementorName ?? "Default";
    }

    public string ImplementationName { get; }

    public override string ToString()
        => ImplementationName;
}
