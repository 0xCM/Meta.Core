//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

using static metacore;

using Meta.Core;

using A = MetaCoreClrSpec;

[assembly: AssemblyVersion(A.AssemblyVersion)]
[assembly: AssemblyTitle(A.Title)]
[assembly: AssemblyProduct(A.ProductName)]

public class MetaCoreClrSpec : CoreModule<A>
{
    public const string ProductName = "metacore/clrspec";
    public const string Title = nameof(MetaCoreClrSpec);
    

}

