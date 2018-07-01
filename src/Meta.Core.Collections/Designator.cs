//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;

[assembly: AssemblyVersion(CoreCollections.AssemblyVersion)]
[assembly: AssemblyTitle(CoreCollections.Title)]
[assembly: AssemblyProduct(CoreCollections.ProductName)]
[assembly: AssemblyClassifier(ComponentClassification.Library)]

public sealed class CoreCollections : CoreModule<CoreCollections>
{
    public const string ProductName = Constants.ProductRoot + "collections";
    public const string Title = nameof(CoreCollections);
}