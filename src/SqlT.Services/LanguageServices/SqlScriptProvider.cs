//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.IO;
    using System.Reflection;

    using static metacore;

    using Meta.Core;

    using SqlT.Models;
    using SqlT.Core;

    [Service(typeof(ISqlScriptProvider))]
    class SqlScriptProvider : Service<ISqlScriptProvider,SqlScriptProviderSettings>, ISqlScriptProvider
    {
        readonly SqlScriptSource DefaultScriptSource;
        readonly Dictionary<SqlScriptSource, IReadOnlyDictionary<SqlScriptName, SqlParameterizedScript>> ScriptIndex
            = new Dictionary<SqlScriptSource, IReadOnlyDictionary<SqlScriptName, SqlParameterizedScript>>();


        public SqlScriptProvider(IApplicationContext context)
            : base(context)
        {
            DefaultScriptSource = new SqlScriptSource
                (
                    SqlScriptSourceType.Package,
                    SqlScriptIdentifiers.DefiningPackageName
                );
        }

        public SqlScriptProvider(IApplicationContext context, Assembly assembly)
            : base(context)
        {
            DefaultScriptSource = new SqlScriptSource
                (
                    SqlScriptSourceType.EmbeddedResource,
                    assembly.GetSimpleName()
                );
        }
                         
        public static IReadOnlyDictionary<SqlScriptName, SqlParameterizedScript> LoadScriptResources(string assemblyPath)
        {
            var assemblies = array(Assembly.ReflectionOnlyLoadFrom(assemblyPath), SqlTServices.ScriptResourceAssembly);
            return assemblies.LoadSqlResources();
        }

        SqlParameterizedScript ISqlScriptProvider.FindScript(SqlScriptName identifer) 
            => Contract.FindScript(DefaultScriptSource, identifer);

        IReadOnlyDictionary<SqlScriptName, SqlParameterizedScript> ISqlScriptProvider.FindScripts(SqlScriptSource source)
        {
            source = source ?? DefaultScriptSource;
            if (!ScriptIndex.ContainsKey(source))
            {
                switch (source.SourceType)
                {
                    case SqlScriptSourceType.Package:
                        if (source.FileSystemLocation.IsNone())
                            throw new ArgumentNullException("No location specified for dac repository");

                        var path = source.FileSystemLocation.ValueOrDefault() + FileName.Parse($"{source.SourceIdentifier}.dacpac");
                        if(!path.Exists())
                            throw new FileNotFoundException($"The file {path} could not be found", path.AbsolutePath);                        
                        ScriptIndex[source] = C.SqlPackageManager().LoadScripts(path).GetIndex();
                        break;
                    case SqlScriptSourceType.EmbeddedResource:
                        ScriptIndex[source] = LoadScriptResources(source.SourceIdentifier);
                        break;
                    case SqlScriptSourceType.DataStore:
                    default:
                        throw new NotImplementedException();
                }
            }

            return ScriptIndex[source];
        }

        SqlParameterizedScript ISqlScriptProvider.FindScript(SqlScriptSource source, SqlScriptName identifier)
        {
            var scripts = Contract.FindScripts(source);
            return scripts[identifier];
        }
    }
}
