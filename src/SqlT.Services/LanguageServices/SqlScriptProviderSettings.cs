//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    public abstract class SqlScriptProviderSettings<T> : ProvidedConfiguration<T>
        where T : SqlScriptProviderSettings<T>
    {
        protected SqlScriptProviderSettings(IConfigurationProvider configuration)
            : base(configuration)
        { }
    }

    public class SqlScriptProviderSettings : SqlScriptProviderSettings<SqlScriptProviderSettings>
    {
        public SqlScriptProviderSettings(IConfigurationProvider configuration)
            : base(configuration)
        {

        }

        public string DacLib
            => GetThisSetting(Environment.GetEnvironmentVariable("DMDacLibDir"), true);
    }
}
