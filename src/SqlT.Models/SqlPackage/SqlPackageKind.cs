//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.ComponentModel;


    [Description("Classifies SQL DAC package")]
    public enum SqlPackageKind : byte
    {
        [Description("Indicates the absence of a classification")]
        None = 0,
        [Description("A SQL DAC package")]
        DacPac = 1,
        [Description("A SQL BAC package")]
        BacPac = 2
    }



}