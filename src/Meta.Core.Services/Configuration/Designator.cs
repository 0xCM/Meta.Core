using static metacore;

using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyTitle(MetaCoreServices.Title)]
[assembly: AssemblyVersion(MetaCoreServices.AssemblyVersion)]
[assembly: AssemblyProduct(MetaCoreServices.ProductName)]

public class MetaCoreServices : CoreModule<MetaCoreServices>
{
    public const string ProductName = "metacore/services";
    public const string Title = nameof(MetaCoreServices);

    public override IReadOnlyList<Assembly> ModuleDependencies
        => rolist(MetaCore.Assembly, MetaCoreJson.Assembly);
        
    
}

