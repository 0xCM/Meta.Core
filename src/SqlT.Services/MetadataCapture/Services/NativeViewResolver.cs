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

    using SqlT.Core;

    using static metacore;

    [ApplicationService(nameof(NativeViewResolver))]
    class NativeViewResolver : ApplicationService<NativeViewResolver, IDependencyResolver>, 
        IDependencyResolver<SqlConnectionString>
    {
        static HashSet<Type> Resolvables
            = new HashSet<Type>{typeof(INativeViewProvider)};

        public NativeViewResolver(IApplicationContext C)
            : base(C)
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
            => Try(() => cast<T>(new NativeViewProvider(connector, connector.QualifiedDatabaseName)));
    }
}