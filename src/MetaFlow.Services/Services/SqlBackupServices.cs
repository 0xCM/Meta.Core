//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
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

        
    class SqlBackupServices : PlatformService<SqlBackupServices,ISqlBackupServices>, ISqlBackupServices
    {

        ISqlHostServices HostServices { get; }

        public SqlBackupServices(INodeContext C)
            : base(C)
        {
            HostServices = C.SqlHostServices();   
        }

        public Option<IReadOnlyList<BackupDescription>> DescribeBackup(FilePath SrcPath)
            => HostServices.DescribeBackup(SrcPath);

    }



}