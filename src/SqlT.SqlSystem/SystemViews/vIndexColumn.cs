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

    public class vIndexColumn : vColumn, IIndexColumn
    {
        public vIndexColumn
        (
            ISchema schema, 
            ITable parent, 
            IIndex index, 
            IColumn parentcol, 
            vType colDataType,  
            IIndexColumn indexcol,
            IEnumerable<IExtendedProperty> properties
         )
            : base(schema, parent, parentcol, colDataType, properties)
        {
            this.index = index;
            this.indexcol = indexcol;
        }

        IIndexColumn indexcol { get; }

        public IIndex index { get; }

        public int ObjectId 
            => indexcol.object_id;

        public int IndexId 
            => index.index_id;

        public SqlName IndexName 
            => index.name;

        public byte IndexColumnPosition
            => indexcol.key_ordinal;

        public bool Descending 
            => indexcol.is_descending_key ?? false;

        public bool Included
            => indexcol.is_included_column ?? false;

        #region #IIndexColumn

        int IIndexColumn.object_id  
            => indexcol.object_id;

        int IIndexColumn.index_id  
            => indexcol.index_id;

        int IIndexColumn.index_column_id 
            => indexcol.index_column_id;

        int IIndexColumn.column_id 
            => indexcol.column_id;

        byte IIndexColumn.key_ordinal 
              => indexcol.key_ordinal;
        byte IIndexColumn.partition_ordinal 
            => indexcol.partition_ordinal;
        bool? IIndexColumn.is_descending_key 
            => indexcol.is_descending_key;
        bool? IIndexColumn.is_included_column 
            => indexcol.is_included_column;
        
        #endregion
    }
}
