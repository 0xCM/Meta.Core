﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using SqlT.Core;

    /// <summary>
    /// Specifies the type of BCP data source
    /// </summary>
    public enum BcpSourceType
    {

        /// <summary>
        /// Data comes from a table/view
        /// </summary>
        TableOrView = 1,

        /// <summary>
        /// Data comes from a query
        /// </summary>
        Query = 2,
    }
}