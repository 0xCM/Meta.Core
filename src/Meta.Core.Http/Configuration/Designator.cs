using System;
using System.Runtime.Versioning;
using System.Reflection;

[assembly: AssemblyVersion(MetaCoreHttp.AssemblyVersion)]
[assembly: AssemblyProduct(MetaCoreHttp.ProductName)]
[assembly: AssemblyTitle(MetaCoreHttp.Title)]

public class MetaCoreHttp : CoreModule<MetaCoreHttp>
{    
    public const string ProductName = "metacore/http";
    public const string Title = nameof(MetaCoreHttp);
}