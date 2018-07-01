﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;

[assembly: AssemblyVersion(MetaFloor.AssemblyVersion)]
[assembly: AssemblyTitle(MetaFloor.Title)]
[assembly: AssemblyProduct(MetaFloor.ProductName)]
[assembly: AssemblyClassifier(ComponentClassification.Library)]

public sealed class MetaFloor : CoreModule<MetaFloor>
{
    public const string SubordinateAssemblyVersion = AssemblyVersion;
    public const string ProductName = Constants.ProductRoot + "floor";
    public const string Title = nameof(MetaFloor);
}