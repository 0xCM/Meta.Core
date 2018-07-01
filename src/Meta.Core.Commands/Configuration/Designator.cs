using static metacore;

using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyVersion(MetaCoreCommands.AssemblyVersion)]
[assembly: AssemblyTitle(MetaCoreCommands.Title)]
[assembly: AssemblyProduct(MetaCoreCommands.ProductName)]
[assembly: AssemblyClassifier(ComponentClassification.CommandDefinition)]

public class MetaCoreCommands : CoreModule<MetaCoreCommands>
{
    public const string ProductName = "metacore/commands";
    public const string Title = nameof(MetaCoreCommands);
        
    public override IReadOnlyList<Assembly> ModuleDependencies
        => new[]
        {
            MetaCoreCommands.Assembly,
            MetaCore.Assembly
        };


}

