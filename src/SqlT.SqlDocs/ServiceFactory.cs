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

    using Meta.Core;

    using SqlT.Core;
    using SqlT.SqlDocs;
    using SqlT.SqlDocs.Proxies;

    using static metacore;


    public static class ServiceFactory
    {
        public static ISqlDocs SqlDocs(this IApplicationContext C)
            => C.Service<ISqlDocs>();

        public static ISqlDocsNavigator SqlDocsNavigator(this INodeContext C)
            => C.Service<ISqlDocsNavigator>();

        public static ISqlDocStore SqlDocStore(this INodeContext C)
            => C.Service<ISqlDocStore>();


        public static ISqlProxyBroker SqlDocsBroker(this INodeContext C)
            => SqlTDocsProxies.Assembly.ProxyBroker(SqlConnectionString.Build().LocalConnection("SqlT.SqlDocs").UsingIntegratedSecurity());

        public static Configuration SqlDocsConfig(this INodeContext C, string ConfigName = null)
            => C.SqlDocsBroker().Select(new Configurations()).OnNone(message => C.Notify(message)).Items()
                   .Where(config => config.ConfigurationName == ifBlank(ConfigName, "Default"))
                    .Single();

        public static Option<TextFileDescription> LoadTextFile(this NodeFilePath SrcPath)
        {
            try
            {
                var text = SrcPath.AbsolutePath.ReadAllText();
                return new TextFileDescription
                {
                    FileContent = text,
                    FileSize = SrcPath.AbsolutePath.FileSize ?? 0,
                    ModifiedDate = SrcPath.UpdatedTS,
                    SegmentName = SrcPath.Folder.FolderName,
                    SourcePath = SrcPath.AbsolutePath
                };
            }
            catch(Exception e)
            {
                return none<TextFileDescription>(e);
            }
            
        }
            


    }




}