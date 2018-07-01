using System;
using System.Runtime.Versioning;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using static metacore;
[assembly: AssemblyVersion(MetaShell.AssemblyVersion)]
[assembly: AssemblyProduct(MetaShell.ProductName)]
[assembly: AssemblyTitle(MetaShell.Title)]

public class MetaShell : CoreModule<MetaShell>
{
    public const string ProductName = "metacore/metashell";
    public const string Title = nameof(MetaShell);

    public override IReadOnlyList<Assembly> ModuleDependencies
        => map(MetaCoreOperations.SystemComponents, c => c.Load());

}