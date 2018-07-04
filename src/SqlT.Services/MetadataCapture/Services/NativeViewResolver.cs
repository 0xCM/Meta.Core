//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Reflection;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;
    using SqlT.Models.Proxies;

    using static metacore;

    [ApplicationService(nameof(NativeViewResolver))]
    class NativeViewResolver : ApplicationService<NativeViewResolver, IDependencyResolver>, 
        IDependencyResolver<SqlConnectionString>
    {
        static HashSet<Type> Resolvables;


        static NativeViewResolver()
        {
            Resolvables = new HashSet<Type>
            {
                typeof(INativeViewProvider)
            };
        }

        public NativeViewResolver(IApplicationContext context)
            : base(context)
        { }

        public IReadOnlyList<Type> GetResolvableConracts(IAssemblyRegistrar registrar)
            => Resolvables.ToList();

        public T ResolveService<T>(string ImplementationName)
        {
            var db = SqlDatabaseName.Master(SqlServerName.LocalHost);
            var connector = SqlConnectionString.Build().Database(db).UsingIntegratedSecurity();
            return ResolveService<T>(ImplementationName, connector).Require();
        }

        public Option<T> ResolveService<T>(string ImplementationName, SqlConnectionString connector)
        {
            try
            {
                var db = connector.QualifiedDatabaseName;
                return cast<T>(new NativeViewProvider(connector, db));
            }
            catch(Exception e)
            {
                return none<T>(e);
            }
        }
    }
}