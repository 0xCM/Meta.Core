//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.ComponentModel;


    [Description("Classifies SQL-related artifacts")]
    public enum SqlArtifactKind : int
    {
        [Description("Indicates the absence of a classification")]
        None = 0,
        [Description("A SQL DAC package")]
        DacPac = 1,
        [Description("A SQL BAC package")]
        BacPac = 2,
        [Description("A SQL script file")]
        Script = 3,
        [Description("A SQL database backup file")]
        Backup = 4,
        [Description("A SQL RDL file")]
        Rdl = 5,
        [Description("A BCP data file")]
        BcpData = 6,
        [Description("A BCP format file")]
        BcpFormat = 7
    }


}