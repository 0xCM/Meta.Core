//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SqlNameEmissionProfile
    {
        readonly SqlProxyGenerationProfile gp;

        public SqlNameEmissionProfile(SqlProxyGenerationProfile gp)
            => this.gp = gp;

        public bool EmitTableTypeNames
            => gp.AlwaysEmitNames ? true 
            : (gp.EmitTableTypes ? gp.EmitTableTypeNames : false);

        public bool EmitPrimaryKeyNames
            => gp.AlwaysEmitNames ? true
            : ((gp.EmitTables && gp.EmitPrimaryKeys) ? gp.EmitPrimaryKeyNames : false);


        public bool EmitTableNames
            => gp.AlwaysEmitNames ? true
            : (gp.EmitTables ? gp.EmitTableTypeNames : false);


        public bool EmitIndexNames
            => gp.AlwaysEmitNames ? true
            : ((gp.EmitTables && gp.EmitIndexes) ? gp.EmitIndexNames : false);

        public bool EmitSequenceNames
            => gp.AlwaysEmitNames ? true
            : (gp.EmitSequences ? gp.EmitSequenceNames : false);

        public bool EmitViewNames
            => gp.AlwaysEmitNames ? true
            : (gp.EmitViews ? gp.EmitViewNames : false);

        public bool EmitServiceBrokerTypeNames
            => gp.AlwaysEmitNames ? true : gp.EmitServiceBrokerTypes;

        public bool EmitStoredProcedureNames
            => gp.AlwaysEmitNames ? true
            : (gp.EmitStoredProcedures ? gp.EmitStoredProcedureNames : false);

        public bool EmitTableFunctionNames
            => gp.AlwaysEmitNames ? true : gp.EmitTableFunctions;


    }

}
