//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using SqlT.Models;
    using SqlT.Core;

    [Service(typeof(ISqlExecutor))]
    class SqlExecutor : Service<ISqlExecutor>, ISqlExecutor
    {
        ISqlScriptProvider ScriptProvider 
            => Service<ISqlScriptProvider>();

        ISqlGenerator SqlGenerator 
            => Service<ISqlGenerator>();

        public SqlExecutor(IApplicationContext C)
            : base(C)
        {
          
        }

        public IEnumerable<TResult> Execute<TResult>(SqlConnectionString cs, ISqlAction action, Func<object[], TResult> converter)
            => cs.Select(SqlGenerator.GenerateScript(action).ScriptText, converter);

        public IEnumerable<C0> Execute<C0>(SqlConnectionString cs, ISqlAction action)
            => cs.GetClientBroker().SelectColumn<C0>(SqlGenerator.GenerateScript(action).ScriptText);

        public IEnumerable<DataFrameRow<C0,C1>> Execute<C0,C1>(SqlConnectionString cs, ISqlAction action)
            => cs.GetClientBroker().SelectColumns<C0,C1>(SqlGenerator.GenerateScript(action).ScriptText);

        public IEnumerable<DataFrameRow<C0, C1, C2>> Execute<C0, C1, C2>(SqlConnectionString cs, ISqlAction action)
            => cs.GetClientBroker().SelectColumns<C0, C1, C2>(SqlGenerator.GenerateScript(action).ScriptText);

        public IEnumerable<DataFrameRow<C0, C1, C2, C3>> Execute<C0, C1, C2, C3>(SqlConnectionString cs, ISqlAction action)
            => cs.GetClientBroker().SelectColumns<C0, C1, C2, C3>(SqlGenerator.GenerateScript(action).ScriptText);

        public void CreateElement(SqlConnectionString cs, ISqlElement element)
            => cs.ExecuteCommand(SqlGenerator.GenerateScript(element).ScriptText);
    }
}
