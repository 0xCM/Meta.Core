//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;

    public class vTableTypeColumn : vColumn
    {
        static IReadOnlyDictionary<string,IExtendedProperty> Index(ITableType type, IColumn column, IEnumerable<IExtendedProperty> properties)
            => properties.Where(p => p.major_id == type.user_type_id && p.minor_id == column.column_id).ToDictionary(x => x.name);

        public vTableTypeColumn(ISchema schema, ITableType type, IColumn column, vType dataType, IEnumerable<IExtendedProperty> properties)
            : base(schema, type, column, dataType, Index(type, column, properties))
        {

        }

        public SqlTypeName TableTypeName
            => ParentName.AsTypeName();

    }

}