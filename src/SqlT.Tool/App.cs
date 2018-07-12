//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Tool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using static metacore;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.CSharp;

    class App
    {
        static IReadOnlyList<string> StandardProfiles
            = list("sys.13", "msdb.13").AsReadOnlyList();        

        static FolderPath GetTempProxyDir(string profileId)
            => (FolderPath.Parse(@"C:\Temp\ProxyGen") + FolderName.Parse(profileId))
                    .CreateIfMissing().Require();

        static FolderPath ProjectOutputFolder
            = FolderPath.Parse(@"C:\Temp\Proxies");

        static SqlProxyGenerationProfile MsDbProfile(string version)
            => new SqlProxyGenerationProfile
            {
                Name = $"msdb.{version}",
                OutputDirectory = ProjectOutputFolder,
                ProjectName = $"SqlT.SqlSystem.Msdb.{version}",
                AssemblyDesignatorName = $"SqlMsdbProxies{version}",
                EmitProject = true,
                BuildProject = true,
                EmitGenerationSpec = true,
                ConnectionString = SqlConnectionString.Build().LocalConnection(SqlDatabaseName.Msdb()),
                Schemas = array
                    (new SqlProxySchemaSelection("sys", true),
                        new SqlProxySchemaSelection("dbo", true)
                    ),
                RootNamespace = $"SqlT.SqlSystem.Msdb{version}",
                ExcludeSystemObjects = false,
                DefaultUsings = array("System", "System.Collections.Generic"),
                EmitSingleFile = true,
                EmitViews = true,
                EmitTables = true,
                EmitStoredProcedures = true,
                EmitTableFunctions = true,
                AlwaysEmitNames = false,
                EmitPrimaryKeys = false,
                EmitTypeContracts = false
            };


        static SqlProxyGenerationProfile MasterProfile(string version)
            => new SqlProxyGenerationProfile
            {
                Name = $"sys.{version}",
                OutputDirectory = ProjectOutputFolder,
                ProjectName = $"SqlT.SqlSystem.Sys.{version}",
                AssemblyDesignatorName = $"SqlSystemProxies{version}",
                EmitProject = true,
                BuildProject = true,
                EmitGenerationSpec = true,
                ConnectionString = SqlConnectionString.Build().LocalConnection(SqlDatabaseName.Master()),
                Schemas = array
                    (new SqlProxySchemaSelection("sys", true)),
                RootNamespace = $"SqlT.SqlSystem.Sys{version}",
                ExcludeSystemObjects = false,
                DefaultUsings = array("System", "System.Collections.Generic"),
                EmitSingleFile = true,
                EmitViews = true,
                EmitTables = true,
                EmitStoredProcedures = true,
                EmitTableFunctions = true,
                AlwaysEmitNames = false,
                EmitPrimaryKeys = false,
                EmitTypeContracts = false
            };

        static Option<SqlProxyGenerationProfile> GetStandardProfile(string identifier)
            => StandardProfiles.TryGetFirst(x => x == identifier).Map(x =>
            {
                switch(x)
                {
                    case "sys.13":
                        return MasterProfile("13");
                    case "msdb.13":
                        return MsDbProfile("13");
                    default:
                        return null;
                }

            });



        static App()
        {
        }



        public static IApplicationContext ComposeContext()
        {
            

            var context = ApplicationContext.Create
                (
                    configuration: ConfigurationProvider.Default(),
                    broker: TransientMessageBroker.Create(m => SystemConsole.Get().Write(m)),
                    assemblies: array
                    (                        
                        SqlTServices.Assembly,
                        SqlTSharp.Assembly,
                        MetaCoreJson.Assembly
                    )                
                );
            
            return context;
        }

        static void GenerateBaseline(IApplicationContext context, ISqlProxyGenerator g)
            => g.GenerateProxies(LoadProfile(context, "SqlT.Baseline.sqlt"));

        static SqlProxyGenerationProfile LoadProfile(IApplicationContext context, string path)
            => JsonServices.FromObjectFile<SqlProxyGenerationProfile>(path).Expand();

        //static Option<IReadOnlyList<FilePath>> GenerateProxies(IApplicationContext C, CodeGenerationProfile profile)
        //{
        //    var g = C.Service<ISqlProxyGenerator>();
        //    switch (profile.ProfileType)
        //    {
        //        case CodeGenerationProfileKind.Default:
        //            return some(g.GenerateProxies(profile as SqlProxyGenerationProfile));
        //        case CodeGenerationProfileKind.FieldList:
        //            return some(g.GenerateFieldLists(profile as SqlFieldListGenerationProfile));
        //        default:
        //            return none<IReadOnlyList<FilePath>>(error($"The type {profile.GetType()} is not supported"));

        //    }
        //}

        //static Option<IReadOnlyList<FilePath>> Generate(IApplicationContext C, FilePath Path)
        //        => from profile in C.SqlProxyProfileManager().LoadProfile(Path)
        //           from emissions in GenerateProxies(C, profile)
        //           select emissions;

         
        static Option<bool> Run(IApplicationContext context, IReadOnlyDictionary<string,string> args)
        {
            var g = context.Service<ISqlProxyGenerator>();
            foreach (var arg in args.Values)
            {
                if (StandardProfiles.Contains(arg))
                {
                    var result = GetStandardProfile(arg)
                        .Map(profile => g.GenerateProxies(profile));
                    if (!result)
                        return none<bool>(result.Message);
                        
                }
                else
                {                    
                    var file = FilePath.Parse(arg);
                    if (!file.Exists())
                        return none<bool>(error($"The file {file} could not be found"));
                    context.GenerateCode(file);
                }
            }
            return some(true);

        }

        static void DisplayLogo()
            => Console.WriteLine($"SqlT Proxy Generator v{SqlTCore.Assembly.GetName().Version}");

        static void DisplayUsage()
        {
            Console.WriteLine("Usage:SqlT <profile-1>...<profile-n>");
            Console.WriteLine("Hit <enter> to exit");
            Console.ReadLine();
        }

        static void DisplayError(IAppMessage message)
        {
            Console.Write(message);
            Console.WriteLine("Press <enter> to exit");
            Console.ReadLine();
        }

        static int Main(string[] args)
        {
            SystemConsole.InitSettings.Reset();
            DisplayLogo();    
            if(args.Length == 0)
            {
                DisplayUsage();
                return 0;
            }

            
            foreach(var arg in args)
            {
                if (!StandardProfiles.Contains(arg))
                {
                    if (!FilePath.Parse(arg).Exists())
                    {
                        Console.Error.WriteLine(
                            AppMessage.Error($"The input file ${arg} could not be found").Format());
                        return -1;
                    }
                }
            }
            var argindex = (mapi(args, (i, arg) => ($"{i}", arg))).ToReadOnlyDictionary();

            using (var context = ComposeContext())
            {
                var result = Run(context,argindex);
                result.OnNone(DisplayError);
                return result.IsNone() ? -1 : 0;
            }

        }
    }
}
