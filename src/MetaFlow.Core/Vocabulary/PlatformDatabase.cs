//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using SqlT.Core;

    using N = SystemNodeIdentifier;
    
    public class PlatformDatabase
    {
        public PlatformDatabase(SqlDatabaseName Name,  Core.PlatformDatabaseKind DatabaseType, 
            N Host, N SqlNode, bool IsPrimary, bool IsEnabled, bool IsModel, bool IsRestore)
        {
            this.Name = Name;
            this.DatabaseType = DatabaseType;
            this.Host = Host;
            this.SqlNode = SqlNode;
            this.IsPrimary = IsPrimary;
            this.IsEnabled = IsEnabled;
            this.IsModel = IsModel;
            this.IsRestore = IsRestore;
        }

        public SqlDatabaseName Name { get; }

        public Core.PlatformDatabaseKind DatabaseType { get; }

        public N Host { get; }

        public N SqlNode { get; }

        public bool IsPrimary { get; }

        public bool IsEnabled { get; }
        public bool IsModel { get; }

        public bool IsRestore { get; }

        public override string ToString()
            => $"metaflow.sqldb://{SqlNode}/{DatabaseType}/{Name.UnquotedLocalName}";
    }
}