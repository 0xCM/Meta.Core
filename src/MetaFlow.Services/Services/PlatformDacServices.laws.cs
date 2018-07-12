//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Dac;
    using N = SystemNodeIdentifier;
    using S = SystemIdentifier;

    public interface IPlatformDacServices : INodeService
    {
        NodeFolderPath DacRepositoryLocation { get; }
        Option<NodeFilePath> DeployDacOld(SqlPackageName DACPAC, N Target);

        DacDeploymentSummary DeployDac(SqlPackageName DACPAC, N Target, CorrelationToken? CT = null);

        Option<int> CreateDacReport(SqlPackageName DACPAC, N Target);

        void DeploySystemDacs(S System, N Target, bool PLL);

        void DeploySystemDacs(S System, IEnumerable<N> Targets, bool PLL);

        IReadOnlySet<Option<NodeFilePath>> DeployDacs(SqlPackageDependencySet Packages, N TargetNode, bool PLL = true);

        Option<SqlPackageDescription> DescribeDac(SqlPackageName PackageName);

        IEnumerable<SqlPackageDescription> DescribeDacs();

        Option<SqlPackageProfile> DefaultProfile(N TargetNode, SqlDatabaseName TargetDb);

        Option<DacDeploymentSummary> DeployDatabase(SqlDatabaseName DatabaseName, N TargetNode);
    }
}