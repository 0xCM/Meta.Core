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
    using System.ComponentModel;

    public enum ExternalDatabaseKind : int
    {

        [Description("Signifies the absence of an external database classification"), Label("Uncategorized")]
        None,

        [Description("SQL Server master database")]
        MsMaster,

        [Description("SQL Server model database")]
        MsModel,

        [Description("SQL Server msdb database")]
        MsDb,

        [Description("SQL Server Reporting Services database")]
        MsRs,

        [Description("SQL Server Reporting Services Temp database")]
        MsRsT

    }


}