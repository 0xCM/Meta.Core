//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public static class SqlScriptIdentifiers
    {
        public const string DefiningPackageName = "SqlT.Schemas.Scripts";

        public const string ObjectExists = "[SqlT].[ObjectExists]";
        public const string GetBackupDescription = "[SqlT].[GetBackupDescription]";
        public const string GetServerPathDefaults = "[SqlT].[GetServerPathDefaults]";
        public const string GetTableColumns = "[SqlT].[GetTableColumns]";
        public const string GetRowCounts = "[SqlT].[GetRowCounts]";

        public const string ConfigureServer = "[SqlT].[ConfigureServer]";
        public const string CreateDmlUpdateTrigger = "[SqlT].[CreateDmlUpdateTrigger]";

        public const string DropDatabase = "[SqlT].[DropDatabase]";

        public const string ObjectDoesNotExist = "[SqlT].[ObjectDoesNotExist]";

    }
}
