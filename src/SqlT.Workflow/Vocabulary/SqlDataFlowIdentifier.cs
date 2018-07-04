//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;
    using Meta.Core.Resources;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using N = SystemNode;
    using DB = Core.SqlDatabaseName;



    public class SqlDataFlowIdentifier
    {
        public SqlDataFlowIdentifier(string DataFlowName, DB SourceDb, DB TargetDb)
        {
            this.SourceDb = SourceDb.TrimServer();
            this.TargetDb = TargetDb.TrimServer();
            this.DataFlowName = DataFlowName;

        }

        public string DataFlowName { get; }

        public DB SourceDb { get; }


        public DB TargetDb { get; }


        public override string ToString()
            => $"{DataFlowName}:{SourceDb}=>{TargetDb}";

    }


}