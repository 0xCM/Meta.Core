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

    public class vView : vObject, IColumnProvider
    {

        public vView(ISchema schema, IView view, IEnumerable<vColumn> columns, IEnumerable<IExtendedProperty> properties)
            : base(schema, view, properties)
        {
            this._view = view;
            this._columns = rolist(columns);
        }

        IView _view { get; }

        IReadOnlyList<vColumn> _columns { get; }

        public IReadOnlyList<vColumn> Columns 
            => _columns;

        public Option<SqlObjectName> ResultContractName 
            => GetResultContractName();

        public SqlViewName ViewName
            => new SqlViewName(SchemaName, Name);

        public override sxc.ISqlObjectName ObjectName
            => ViewName;
    }

}