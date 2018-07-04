//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Encapsulates a complete model definition, insofar as such a definition
    /// is supported by the infrastructure
    /// </summary>
    public partial class SqlModelSet
    {
        
        public IReadOnlyList<SqlScalarFunction> ScalarFunctions;
        public IReadOnlyList<SqlProjector> Projectors;
        public IReadOnlyList<SqlTable> Tables;
        public IReadOnlyList<SqlTableType> TableTypes;
        public IReadOnlyList<SqlProcedure> Procedures;
        public IReadOnlyList<SqlTableFunction> TableFunctions;
        public SqlPropertyIndex ExtendedProperties;

        public SqlModelSetDescriptor ModelDescriptor;


        public SqlModelSet
            (
                SqlModelSetDescriptor ModelDescriptor,
                SqlPropertyIndex ExtendedProperties,
                IEnumerable<SqlScalarFunction> ScalarFunctions = null,
                IEnumerable<SqlProjector> Projectors = null,
                IEnumerable<SqlTable> Tables = null,
                IEnumerable<SqlTableType> TableTypes = null,
                IEnumerable<SqlProcedure> Procedures = null,
                IEnumerable<SqlTableFunction> TableFunctions = null
            )
        {
            this.ModelDescriptor = ModelDescriptor;
            this.ExtendedProperties = ExtendedProperties;
            this.ScalarFunctions = rolist(ScalarFunctions);
            this.Projectors = rolist(Projectors);
            this.Tables = rolist(Tables);
            this.TableTypes = rolist(TableTypes);
            this.Procedures = rolist(Procedures);
            this.TableFunctions = rolist(TableFunctions);
        }


        public IEnumerable<SqlProjector> ChangeProjectors
            => Projectors.Where(p => p.IsChangeProjector);


        public IEnumerable<SqlProjector> SequentialProjectors
            => Projectors.Where(p => p.IsSequentialProjector);

    }
}
