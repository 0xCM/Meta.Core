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
    using static metacore;
    
    public abstract class SqlWorkflowAgentSettings<S> : ServiceAgentSettings<S>
        where S : SqlWorkflowAgentSettings<S>
    {
        readonly AgentIdentifier AgentIdentifier;

        public SqlWorkflowAgentSettings(IConfigurationProvider Configuration, AgentIdentifier AgentIdentifier)
            : base(Configuration, AgentIdentifier)
        {
            
            this.AgentIdentifier = AgentIdentifier;
        }

        [ComponentSetting("Specifies whether query is being executed for validation or diagnostic purposes")]
        public bool DiagnosticMode
            => GetThisSetting(true, true);


        [ComponentSetting("Storage for JSON block that, if present, resolves to an query-specific option type")]
        public string OptionJson
        {
            get { return GetThisSetting(string.Empty, false); }
            set { PutThisSetting(value); }
        }

        [ComponentSetting("Specifies the default batch size to use for bulk operations")]
        public int DefaultBatchSize
            => GetThisSetting(10000, true);

      

        protected override string AlternateGroupName
            => AgentIdentifier;

    }

    public sealed class SqlWorkflowAgentSettings : SqlWorkflowAgentSettings<SqlWorkflowAgentSettings>
    {
        public SqlWorkflowAgentSettings(IConfigurationProvider config, AgentIdentifier AgentId)
            : base(config, AgentId)
        {


        }

    }
}
