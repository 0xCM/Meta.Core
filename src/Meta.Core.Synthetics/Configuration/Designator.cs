using System.Collections.Generic;
using System.Reflection;

using static metacore;


[assembly: AssemblyTitle(MetaCoreSynthetics.Title)]
[assembly: AssemblyProduct(MetaCoreSynthetics.ProductName)]
[assembly: AssemblyVersion(MetaCoreSynthetics.AssemblyVersion)]

public class MetaCoreSynthetics : CoreModule<MetaCoreSynthetics>
{
    public const string ProductName = "metacore/synthetics";
    public const string Title = nameof(MetaCoreSynthetics);
    

    

}
