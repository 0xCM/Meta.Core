//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{

    using SqlT.Dom;

    public static class ServiceFactory
    {
        public static ISqlDomServices SqlDomServices(this IApplicationContext C)
            => C.Service<ISqlDomServices>();

        public static ISqlDomReader SqlDomReader(this IApplicationContext C)
            => C.Service<ISqlDomReader>();

        public static ISqlDomRepository SqlDomRepository(this IApplicationContext C)
            => C.Service<ISqlDomRepository>();

        public static ISqlTDomProjectSpecifier SqlTDomProjectSpecifier(this IApplicationContext C)
            => C.Service<ISqlTDomProjectSpecifier>();

        public static ISqlMetamodelServices SqlMetamodelSevices(this IApplicationContext C)
            => C.Service<ISqlMetamodelServices>();

        public static ISqlXmlSyntaxFormatter SqlXmlSyntaxFormatter(this IApplicationContext C)
            => SqlT.Services.SqlXmlSyntaxFormatter.Create(C);


        internal static FolderPath Resolve(this FolderPath path, params (string name, object value)[] variables)
        {
            var script = new Script(path.Value);
            var resolvedPath = FolderPath.Parse(script.SpecifyParameters(variables, false));
            return resolvedPath;          
        }
    }
}
