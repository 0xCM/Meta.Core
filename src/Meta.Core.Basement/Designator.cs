using System.Reflection;

[assembly: AssemblyVersion(MetaBase.Version)]
[assembly: AssemblyProduct(MetaBase.ProductName)]
[assembly: AssemblyTitle(MetaBase.Title)]
[assembly: AssemblyClassifier(ComponentClassification.Library)]

public sealed class MetaBase 
{
    public const string Version = Constants.AssemblyVersion;
    public const string ProductName = Constants.ProductRoot + "basement";
    public const string Title = nameof(MetaBase);
}