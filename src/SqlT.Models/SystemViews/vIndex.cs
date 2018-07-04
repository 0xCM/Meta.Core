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

    public class vIndex : vSystemElement, IIndex
    {
        readonly ISchema _schema;
        readonly ITable _table;
        readonly IIndex _index;
        readonly IReadOnlyList<vIndexColumn> _indexcols;

        static IReadOnlyDictionary<string, IExtendedProperty> IndexProperties(ISchema schema, 
                ITable table, IIndex index, IEnumerable<IExtendedProperty> properties)
                    => properties.ToDictionary(p => $"[{schema.name}].[{table.name}].[{index.name}].[{p.name}]");

        public vIndex
        (
            ISchema schema, 
            ITable table, 
            IIndex index, 
            IEnumerable<vIndexColumn> indexcols, 
            IEnumerable<IExtendedProperty> properties
        ) : base(index.name, IndexProperties(schema, table, index, properties), table.is_user_defined)
        {
            this._schema = schema;
            this._table = table;
            this._index = index;
            this._indexcols = rolist(indexcols);
        }

        public IEnumerable<vIndexColumn> PrimaryColumns
            => _indexcols.Where(c => c.Included == false).OrderBy(c => c.IndexColumnPosition);

        public IEnumerable<vIndexColumn> IncludedColumns
            => _indexcols.Where(c => c.Included).OrderBy(c => c.IndexColumnPosition);

        public SqlObjectName ParentName
            => new SqlObjectName(_schema.name, _table.name);

        public SqlIndexName IndexName
            => new SqlIndexName(_index.name);

        public bool IsPrimaryKey
            => _index.is_primary_key == true;

        public bool IsUniqueConstraint
            => _index.is_unique_constraint == true;

        public bool IsUniqueIndex
            => _index.is_unique == true;

        #region IIndex
        int IIndex.object_id => _index.object_id;
        int IIndex.index_id => _index.index_id;
        byte IIndex.type => _index.type;
        string IIndex.type_desc => _index.type_desc;
        bool? IIndex.is_unique => _index.is_unique;
        int? IIndex.data_space_id => _index.data_space_id;
        bool? IIndex.ignore_dup_key => _index.ignore_dup_key;
        bool? IIndex.is_primary_key => _index.is_primary_key;
        bool? IIndex.is_unique_constraint => _index.is_unique_constraint;
        byte IIndex.fill_factor => _index.fill_factor;
        bool? IIndex.is_padded => _index.is_padded;
        bool? IIndex.is_disabled => _index.is_disabled;
        bool? IIndex.is_hypothetical => _index.is_hypothetical;
        bool? IIndex.allow_row_locks => _index.allow_row_locks;
        bool? IIndex.allow_page_locks => _index.allow_page_locks;
        bool? IIndex.has_filter => _index.has_filter;
        string IIndex.filter_definition => _index.filter_definition;
        int? IIndex.compression_delay => _index.compression_delay;
        #endregion

    }
}
