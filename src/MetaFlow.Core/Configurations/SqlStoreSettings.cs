//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using SqlT.Core;
    using SqlT.Services;
    using System.IO;

    using SqlT.Models;

    public sealed class PlatformSqlSettings : SqlStoreSettings<PlatformSqlSettings>
    {
        public static SqlUserCredentials MetaFlowOperatorCredentials
            => new SqlUserCredentials(MetaFlowOperator, MetaFlowOperatorPass);

        public static readonly SqlDatabaseName PlatformDatabase
            = "MetaFlow";

        public static string MetaFlowOperator { get; }
            = System.Environment.GetEnvironmentVariable("MetaFlowOperatorName");

        public static string MetaFlowOperatorPass{ get; } 
            = System.Environment.GetEnvironmentVariable("MetaFlowOperatorPass");

        public static SqlConnectionString PlatformConnector
            => SqlConnectionString.Build(SystemNode.Local.NodeName, PlatformDatabase)
                                  .UsingCredentials(MetaFlowOperatorCredentials);

        public PlatformSqlSettings(IConfigurationProvider Configuration)
            : base(Configuration)
        {

        }
                     
    }

 
}