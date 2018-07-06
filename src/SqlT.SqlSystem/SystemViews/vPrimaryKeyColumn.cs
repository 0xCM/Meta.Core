//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;

    public class vPrimaryKeyColumn : vColumn, IIndexColumn
    {

        public vPrimaryKeyColumn
        (
            ISchema schema, 
            ISystemObject parent, 
            IIndex index,
            IColumn parentcol,
            vType coldataType,
            IIndexColumn indexcol, 
            IEnumerable<IExtendedProperty> properties
         )
            : base(schema, parent, parentcol, coldataType, properties)
        {
            this.PrimaryKeyName = new SqlObjectName(schema.name, index.name);
            this.IndexColumn = indexcol;
        }

        IIndexColumn IndexColumn { get; }

        public SqlObjectName PrimaryKeyName { get;}

        /// <summary>
        /// The position of the column relative to other key columns
        /// </summary>
        public int KeyColumnPosition
            => IndexColumn.key_ordinal;

        public override string ToString()
            => $"{PrimaryKeyName}([{ParentName}].[{Name}])";

        #region IIndexColumn
        int IIndexColumn.column_id => IndexColumn.column_id;

        int IIndexColumn.index_column_id => IndexColumn.index_column_id;

        int IIndexColumn.index_id => IndexColumn.index_id;

        bool? IIndexColumn.is_descending_key => IndexColumn.is_descending_key;

        bool? IIndexColumn.is_included_column => IndexColumn.is_included_column;

        byte IIndexColumn.key_ordinal => IndexColumn.key_ordinal;

        int IIndexColumn.object_id => IndexColumn.object_id;

        byte IIndexColumn.partition_ordinal => IndexColumn.partition_ordinal;
        #endregion IIndexColumn
    }

}
