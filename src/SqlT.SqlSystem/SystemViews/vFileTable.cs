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

    public class vFileTable : vTable, IColumnProvider, IFileTable
    {
        IFileTable _FileTable { get; }

        public vFileTable
            (
                ISchema schema,
                IFileTable filetable,
                ITable table,
                IEnumerable<vColumn> columns,
                IEnumerable<IExtendedProperty> properties

            )
            : base(schema, table, columns, properties)
            {
                this._FileTable = filetable;    
            }

        public FolderName DirectoryName
            => _FileTable.directory_name;

        public bool IsEnabled
            => _FileTable.is_enabled;

        #region IFileTable

        bool IFileTable.is_enabled
            => _FileTable.is_enabled;
        int IFileTable.object_id
            => _FileTable.object_id;

        string IFileTable.directory_name
            => _FileTable.directory_name;

        int IFileTable.filename_collation_id
            => _FileTable.filename_collation_id;

        string IFileTable.filename_collation_name
            => _FileTable.filename_collation_name;
        
        #endregion
    }
}