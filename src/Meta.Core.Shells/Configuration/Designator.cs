using static metacore;

using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyTitle(MetaCoreShells.Title)]
[assembly: AssemblyVersion(MetaCoreShells.AssemblyVersion)]
[assembly: AssemblyProduct(MetaCoreShells.ProductName)]

public class MetaCoreShells : CoreModule<MetaCoreShells>
{
    public const string ProductName = "metacore/shells";
    public const string Title = nameof(MetaCoreShells);

    public override IReadOnlyList<Assembly> ModuleDependencies
        => rolist(MetaCore.Assembly, MetaCoreJson.Assembly);
        
    
}

