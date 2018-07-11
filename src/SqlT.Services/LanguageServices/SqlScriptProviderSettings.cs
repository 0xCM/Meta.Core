//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using Meta.Core;

    public abstract class SqlScriptProviderSettings<T> : ProvidedConfiguration<T>
        where T : SqlScriptProviderSettings<T>
    {
        protected SqlScriptProviderSettings(IConfigurationProvider configuration)
            : base(configuration)
        { }
    }

    public class SqlScriptProviderSettings : SqlScriptProviderSettings<SqlScriptProviderSettings>
    {
        public SqlScriptProviderSettings(IConfigurationProvider configuration, NodeFolderPath DacLib)
            : base(configuration)
        {
            this.DacLib = DacLib;   
        }

        
        public NodeFolderPath DacLib { get; }
        
    }
}
