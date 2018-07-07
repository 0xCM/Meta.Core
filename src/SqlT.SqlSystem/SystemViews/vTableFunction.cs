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


    public class vTableFunction : vRoutine, IColumnProvider
    {
        readonly IReadOnlyList<vColumn> _Columns;


        public vTableFunction
            (
                ISchema schema, 
                ISystemObject function, 
                IEnumerable<vParameter> parameters,
                IEnumerable<vColumn> columns,
                IEnumerable<IExtendedProperty> properties
            )
            : base(schema, function, parameters, properties)
        {
            this._Columns = rolist(columns);
        }

        public IReadOnlyList<vColumn> Columns
            => _Columns;

        public SqlFunctionName FunctionName
            => new SqlFunctionName(SchemaName, Name);

        public override sxc.ISqlObjectName ObjectName
            => FunctionName;

    }

}