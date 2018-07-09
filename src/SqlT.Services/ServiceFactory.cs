//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;    
    using System.Collections.Generic;
    using System.IO;
    using SqlT.Models;
    using SqlT.Core;
    using System.Reflection;

    using static metacore;

    public static class ServiceFactory
    {
        public static ISqlProxyParser SqlProxyParser(this IApplicationContext C)
            => C.Service<ISqlProxyParser>();

        public static ISqlProxyFormatter SqlProxyFormatter(this IApplicationContext C)
            => C.Service<ISqlProxyFormatter>();

        public static ISqlProxyEmitter<F, TResult> SqlProxyEmitter<F, TResult>(this IApplicationContext C, SqlEmissionConfig<F, TResult> Config)
                    where F : class, ISqlTableFunctionProxy<F, TResult>, new()
            where TResult : class, ISqlTabularProxy, new()
                => new SqlProxyEmitter<F, TResult>(C, Config);

        public static SqlEmissionConfig<F, TResult> ConfigureExport<F, TResult>(this SqlConnectionString Connector)
            where F : class, ISqlTableFunctionProxy<F, TResult>, new()
            where TResult : class, ISqlTabularProxy, new()
                => new SqlEmissionConfig<F, TResult>(Connector);

        public static ISqlSpaceServices SqlSpaceServices(this IApplicationContext C)
            => C.Service<ISqlSpaceServices>();

        public static ISqlResourceLocator SqlResources(this IApplicationContext C)
            => C.Service<ISqlResourceLocator>();

        public static IMessageBroker SqlLogMessageBroker(this SqlConnectionString Connector, AppMessageObserver Sentinel = null)
            => new SqlLogMessageBroker(Connector, Sentinel);

        public static ISqlRuntimeProvider SqlRuntimeProvider(this IApplicationContext C)
            => C.Service<ISqlRuntimeProvider>();

        public static ISqlResourceProvider SqlResourceProvider(this IApplicationContext C)
           => C.Service<ISqlResourceProvider>();

        public static ISqlScriptProvider SqlScriptProvider(this IApplicationContext C)
            => C.Service<ISqlScriptProvider>();

        public static ISqlProxyEncoder SqlProxyEncoder(this IApplicationContext C)
            => C.Service<ISqlProxyEncoder>();
        
        public static ISqlTypeTableManager SqlTypeTableManager(this IApplicationContext C)
           => C.Service<ISqlTypeTableManager>();

        public static ISqlGenerator SqlGenerator(this IApplicationContext C)
            => C.Service<ISqlGenerator>();

        public static ISqlParser SqlParser(this IApplicationContext C)
            => C.Service<ISqlParser>();

        public static ISqlMetadataProvider SqlMetadataProvider(this IApplicationContext C)
            => C.Service<ISqlMetadataProvider>();

        public static ISqlMetadataStore SqlMetadataStore(this IApplicationContext C)
            => C.Service<ISqlMetadataStore>();


        public static IEnumerable<SqlProxyGenerationProfile> GetEmbeddedProfiles(this ISqlProxyAssembly pa)
            => from resource in ClrAssembly.Get(pa.DefininingAssembly).TextResources(".sqlt")
               let profile =  JsonServices.ToObject<SqlProxyGenerationProfile>(resource.Text)
               where profile != null
               select profile;

        public static Option<ISqlProxyBroker> DefaultBroker(this ISqlProxyAssembly pa)        
            => from profile in pa.GetEmbeddedProfiles().TryGetFirst()
                let broker = pa.CreateBroker(profile.ConnectionString)
                select broker;
        
        public static IEnumerable<SqlParameterizedScript> LoadSqlResources(this Assembly assembly)
        {
            var resnames = rolist(assembly.GetManifestResourceNames().Where(name => name.EndsWith(".sql")));
            foreach (var resname in resnames)
            {
                var identifier = Path.GetFileNameWithoutExtension(resname).RightOfLast(".");
                using (var stream = assembly.GetManifestResourceStream(resname))
                    using (var reader = new StreamReader(stream))
                        yield return new SqlParameterizedScript(identifier, reader.ReadToEnd());
            }
        }

        public static IReadOnlyDictionary<SqlScriptName, SqlParameterizedScript> LoadSqlResources(this IEnumerable<Assembly> assemblies)
        {
            var scripts = new Dictionary<SqlScriptName, SqlParameterizedScript>();
            iter(assemblies, assembly => iter(assembly.LoadSqlResources(), script => scripts[script.ScriptName] = script));
            return scripts;
        }
    }
}
