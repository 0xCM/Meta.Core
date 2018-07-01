using static metacore;

using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyVersion(MetaCoreWorkflow.AssemblyVersion)]
[assembly: AssemblyProduct(MetaCoreWorkflow.ProductName)]
[assembly: AssemblyTitle(MetaCoreWorkflow.Title)]


public class MetaCoreWorkflow : CoreModule<MetaCoreWorkflow>
{    
    public const string ProductName = "metacore/workflow";
    public const string Title = nameof(MetaCoreWorkflow);

    
}

