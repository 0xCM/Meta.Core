using System.Reflection;

[assembly: AssemblyVersion(MetaCore.AssemblyVersion)]
[assembly: AssemblyTitle(MetaCore.Title)]
[assembly: AssemblyProduct(MetaCore.ProductName)]
[assembly: AssemblyClassifier(ComponentClassification.Service)]

public sealed class MetaCore : CoreModule<MetaCore>
{    
    public const string SubordinateAssemblyVersion = AssemblyVersion;
    public const string ProductName = "metacore/foundation";
    public const string Title = nameof(MetaCore);    

}