//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    using SqlT.Core;
    using Meta.Core;

    using SqlT.Types;

    public interface ISqlBackupServices : INodeService
    {
        Option<IReadOnlyList<BackupDescription>> DescribeBackup(FilePath HostPath);
    }

}