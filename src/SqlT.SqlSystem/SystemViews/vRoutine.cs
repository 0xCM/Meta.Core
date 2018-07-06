//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;

    using static metacore;

    public abstract class vRoutine : vObject
    {
        protected vRoutine
            (
                ISchema schema, 
                ISystemObject routine, 
                IEnumerable<vParameter> parameters,
                IEnumerable<IExtendedProperty> properties
            )
            : base(schema, routine, properties)
        {
            this.Parameters = parameters.OrderBy(x => x.Position).ToList();
        }

        public IReadOnlyList<vParameter> Parameters { get; }

        public Option<SqlObjectName> ResultContractName 
            => GetResultContractName();
    }
}
