//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using SqlT.Core;



    /// <summary>
    /// Represents a database index
    /// </summary>
    public interface ISqlIndexRuntime : ISqlElementRuntime
    {
        /// <summary>
        /// Determines whether the represented index exists
        /// </summary>
        /// <returns></returns>
        Option<SqlBooleanValue> Exists();

        Option<SqlBooleanValue> IsClustered();

        Option<SqlBooleanValue> IsUnique();
       
        Option<SqlBooleanValue> IsDisabled();

        Option<SqlBooleanValue> IsEnabled();

        Option<int> Disable();

        Option<int> Rebuild();

        Option<int> Drop(bool IfExists = true);

        Option<int> Create(IEnumerable<SqlColumnName> columns, bool clustered = false, bool unique = false);

        Option<int> Create(IEnumerable<SqlColumnName> columns, IEnumerable<SqlColumnName> includes, bool clustered = false, bool unique = false);

    }

}