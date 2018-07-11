//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

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