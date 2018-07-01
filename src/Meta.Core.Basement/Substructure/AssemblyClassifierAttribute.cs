//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
public class AssemblyClassifierAttribute : Attribute
{

    public AssemblyClassifierAttribute(params ComponentClassification[] Classifications)
    {
        this.Classifications = Classifications;

    }

    public IReadOnlyList<ComponentClassification> Classifications { get; }

    public override string ToString()
        => string.Join(",", Classifications);

}