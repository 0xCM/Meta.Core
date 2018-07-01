using static metacore;

using System.Collections.Generic;
using System.Reflection;

[assembly: AssemblyVersion(MetaCoreMessaging.AssemblyVersion)]
[assembly: AssemblyProduct(MetaCoreMessaging.ProductName)]
[assembly: AssemblyTitle(MetaCoreMessaging.Title)]

public class MetaCoreMessaging : CoreModule<MetaCoreMessaging>
{
    public const string ProductName = "metacore/messaging";
    public const string Title = nameof(MetaCoreMessaging);
        
}

