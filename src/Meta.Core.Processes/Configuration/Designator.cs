using static metacore;

using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyVersion(MetaCoreProcesses.AssemblyVersion)]
[assembly: AssemblyProduct(MetaCoreProcesses.ProductName)]
[assembly: AssemblyTitle(MetaCoreProcesses.Title)]

public class MetaCoreProcesses : CoreModule<MetaCoreProcesses>
{
    public const string ProductName = "metacore/processes";
    public const string Title = nameof(MetaCoreProcesses);


    public override IReadOnlyList<Assembly> ModuleDependencies
        => array(MetaCore.Assembly);

    
}

