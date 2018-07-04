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

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    public class vTableType : vType, IColumnProvider, ITableType
    {
        static IReadOnlyDictionary<string, IExtendedProperty> Index(ITableType subject, IEnumerable<IExtendedProperty> properties)
            => properties.Where(x => x.major_id == subject.user_type_id && x.minor_id == 0).ToDictionary(x => x.name);

        public vTableType
        (
            ISchema schema, 
            ITableType type, 
            IEnumerable<vTableTypeColumn> columns, 
            IEnumerable<IExtendedProperty> properties
        ) : base(schema, type, Index(type,properties))
        {
            this._type = type;
            this._columns = rolist(columns);
        }

        IReadOnlyList<vTableTypeColumn> _columns { get; }

        new ITableType _type { get; }

        internal int ObjectId
            => _type.type_table_object_id;

        public IReadOnlyList<vTableTypeColumn> Columns 
            => _columns;

        IReadOnlyList<vColumn> IColumnProvider.Columns 
            => _columns;

        public override bool IsTableType 
            => true;

        int ITableType.type_table_object_id
            => _type.type_table_object_id;

        public override sxc.type_name TypeName
            => new SqlTableTypeName(new SqlSchemaName(SchemaName), _type.name);
    }

}