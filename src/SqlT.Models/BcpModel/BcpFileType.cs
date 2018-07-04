//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public enum BcpFileType
    {
        None = 0,
        DataFile = 1,
        FormatFile = 2,
        BcpExportScript = 3,
        BcpFormatScript = 4,
        BcpImportScript = 5,
        SqlInsertScript = 6
    }


}