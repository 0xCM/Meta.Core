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
    using SqlT.Types;

    using N = SystemNode;

    public interface ISqlHostServices : INodeService
    {
        IEnumerable<NodeVariable> NodeVariables { get; }

        Option<int> SetNodeVariable(string Name, string Value);

        Option<IReadOnlyList<BackupDescription>> DescribeBackup(FilePath SrcPath);
    }



}