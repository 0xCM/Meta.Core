//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;

    using sxc = SqlT.Syntax.contracts;


    public class vProcedure : vRoutine, IProcedure
    {
        public vProcedure(ISchema schema, ISystemObject procedure, IEnumerable<vParameter> parameters,
            IEnumerable<IExtendedProperty> properties) : base(schema, procedure, parameters, properties)
        {

        }

        public SqlProcedureName ProcedureName
            => new SqlProcedureName(SchemaName, Name);

        public override sxc.ISqlObjectName ObjectName
            => ProcedureName;

    }

}