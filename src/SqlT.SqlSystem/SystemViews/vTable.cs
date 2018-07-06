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
    using SqlT.Models;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    public class vTable : vObject, IColumnProvider
    {

        public vTable
            (   
                ISchema schema, 
                ITable table, 
                IEnumerable<vColumn> columns, 
                IEnumerable<IExtendedProperty> properties
            )
            : base(schema, table,  properties)
        {
            this._Table = table;
            this._Columns = rolist(columns);
        }

        ITable _Table { get; }

        IReadOnlyList<vColumn> _Columns { get; }

        public bool IsFileTable 
            => _Table.is_filetable ?? false;

        public IReadOnlyList<vColumn> Columns 
            => _Columns;

        public Option<SqlObjectName> ResultContractName 
            => GetResultContractName();
       
        public SqlTableName TableName
             => new SqlTableName(SchemaName, Name);

        public override sxc.ISqlObjectName ObjectName
            => TableName;
    }

}