using System;
using System.Runtime.Versioning;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public class MetaShell : CoreModule<MetaShell>
{
    public override IReadOnlyList<Assembly> ModuleDependencies
        => map(MetaCorePlatform.SystemComponents, c => c.Load());

}