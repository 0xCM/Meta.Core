//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;
    using System.Text;
    using SqlT.Core;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;


    /// <summary>
    /// Defines contract for script that represents a query over a single database object
    /// </summary>
    public interface ISqlObjectQueryScript : ISqlScript
    {
        /// <summary>
        /// The database in which the source object is defined
        /// </summary>
        Option<SqlDatabaseName> SourceDatabase { get; }

        /// <summary>
        /// The schema-qualified object name
        /// </summary>
        Option<sxc.ISqlObjectName> SourceObject { get; }

    }
}
