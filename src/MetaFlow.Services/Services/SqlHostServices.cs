//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Services;

    using Store = SqlT.Store;
    using Types = SqlT.Types;

    class SqlHostServices : NodeService<SqlHostServices, ISqlHostServices>, ISqlHostServices
    {

        public SqlHostServices(INodeContext C)
            : base(C)
        {

        }

        ISqlProxyBroker HostBroker
            => C.PlatformBroker(Host);
        
        public IEnumerable<NodeVariable> NodeVariables
            => from src in HostBroker.Get(new Store.NodeVars()).OnNone(Notify).Items()
               select new NodeVariable(Host, src.VarName, src.VarValue);

        public Option<int> SetNodeVariable(string Name, string Value)
            => HostBroker.Call(new Store.SetVar(Name, Value));

        public Option<IReadOnlyList<Types.BackupDescription>> DescribeBackup(FilePath SrcPath)
            => HostBroker.Get(new Store.DescribeBackup(SrcPath));
    }
}