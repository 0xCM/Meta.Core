using System.Collections.Generic;
using static metacore;

using System.Reflection;
using System;


//[assembly: AssemblyTitle(SqlTServices.ComponentName)]
//[assembly: AssemblyProduct(SqlTServices.ProductName)]
//[assembly: AssemblyVersion(SqlTServices.AssemblyVersion)]


public partial class SqlTServices : SqlTModule<SqlTServices>
{
    public const string ComponentName = nameof(SqlTServices);
    public const string PackageIdentifier = "SqlT.Services";

    public static IReadOnlySet<Assembly> CoreDependencies
        => roset(
            //MetaCoreBuild.Assembly, 
            MetaCoreCommands.Assembly, 
            MetaCoreExecutors.Assembly, 
            MetaCoreServices.Assembly, 
            MetaCoreJson.Assembly, 
            MetaCoreWorkflow.Assembly,
            MetaFloor.Assembly,
            MetaCoreClrSpec.Assembly,
            MetaCoreCommand.Assembly
            );



    public static readonly Assembly ScriptResourceAssembly 
        = typeof(SqlTCore).Assembly;
    



}
