//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using SqlT.Core;

    using static metacore;

    public class LocalDatabaseSettings
    {
        public string ServerInstanceName { get; } 
            = "Workspaces";

        public string ServerCreate 
            => $"sqllocaldb create \"{ServerInstanceName}\" -s";

        public string UnquotedDatabaseName 
            => $"MetaFlow.SqlShell";

        public string LocalFileName
            => $"{UnquotedDatabaseName}.mdf";

        public string RootServerName = "(localdb)";

        public SqlServerName FullServerName
            => $"{RootServerName}\\{ServerInstanceName}";

        public SqlDatabaseName QuotedDatabaseName
            => SqlDatabaseName.Parse($"[{UnquotedDatabaseName}]");

        public FileName DatabaseFileName
            => FileName.Parse(LocalFileName);

        public FolderPath DatabaseLocation
            => FolderPath.Parse($"{Environment.CurrentDirectory}");

        public SqlDatabaseName FullDatabaseName
            => FullServerName + QuotedDatabaseName;
    }

}