//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Enumerates the available BCP commands
    /// </summary>
    public enum BcpToolAction
    {
        /// <summary>
        /// Specifies the data should be exported
        /// </summary>
        Export = 1,
        /// <summary>
        /// Specifies that a format file should be created
        /// </summary>
        Format = 2,
        /// <summary>
        /// Specifies that data should be imported
        /// </summary>
        Import = 3,
    }

}