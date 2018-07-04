using System;
using System.Reflection;
using System.Collections.Generic;

using static metacore;


//[assembly: AssemblyVersion(SqlTDomServices.AssemblyVersion)]

public class SqlTDomServices : SqlTModule<SqlTDomServices>
{

    public const string ServiceName = nameof(SqlTDomServices);

    public static ClrAssembly ClrAssembly
        => global::ClrAssembly.Get(Assembly);

    public SqlTDomServices()
    {
        
    }

    /// <summary>
    /// Specifies the dependencies on which the shell depends for services
    /// </summary>
    public override IReadOnlyList<Assembly> ModuleDependencies
        => stream
            (
                //MetaCore.Assembly,
                MetaCoreCommands.Assembly,
                MetaCoreJson.Assembly,
                //SqlTServices.Assembly,
                SqlTModels.Assembly,
                //SqlTSharp.Assembly,
                SqlTDomServices.Assembly,
                SqlTLanguage.Assembly
            ).ToReadOnlyList();
}
