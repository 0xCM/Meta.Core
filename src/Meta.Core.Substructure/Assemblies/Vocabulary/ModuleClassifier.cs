//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;


[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
public class ModuleClassifierAttribute : Attribute
{

    public ModuleClassifierAttribute(ModuleKind Classification)
    {
        this.Classification = Classification;

    }

    public ModuleKind Classification { get; }

    public override string ToString()
        => Classification.ToString();

}



