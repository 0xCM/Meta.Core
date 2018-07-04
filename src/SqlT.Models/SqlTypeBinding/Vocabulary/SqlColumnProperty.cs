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
    using SqlT.Core;
    using SqlT.Types;

    /// <summary>
    /// Binds a column to a property
    /// </summary>
    public class SqlColumnProperty
    {
        public SqlColumnProperty(SqlColumnIdentifier Column, ClrProperty Property)
        {
            this.Column = Column;
            this.Property = Property;
        }
        public SqlColumnIdentifier Column { get; }

        public ClrProperty Property { get; }

        public Type DeclaringType
            => Property.DeclaringType;

    }
}



