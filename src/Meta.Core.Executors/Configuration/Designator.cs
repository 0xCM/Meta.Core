using static metacore;

using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyVersion(MetaCoreExecutors.AssemblyVersion)]
[assembly: AssemblyProduct(MetaCoreExecutors.ProductName)]
[assembly: AssemblyTitle(MetaCoreExecutors.Title)]

public class MetaCoreExecutors : CoreModule<MetaCoreExecutors>
{
    public const string ProductName = "metacore/executors";
    public const string Title = nameof(MetaCoreExecutors);


    public override IReadOnlyList<Assembly> ModuleDependencies
        => new[]
        {
            
            MetaCore.Assembly
        };

    
}

