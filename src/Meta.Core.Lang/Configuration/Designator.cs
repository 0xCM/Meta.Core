using static metacore;

using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyVersion(MetaCoreSyntax.AssemblyVersion)]
[assembly: AssemblyProduct(MetaCoreSyntax.ProductName)]
[assembly: AssemblyTitle(MetaCoreSyntax.Title)]

public class MetaCoreSyntax : CoreModule<MetaCoreSyntax>
{
    public const string ProductName = "metacore/syntax";
    public const string Title = nameof(MetaCoreSyntax);
    

    
}

