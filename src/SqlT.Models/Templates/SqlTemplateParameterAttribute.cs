//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Templates
{
    using System;

    /// <summary>
    /// Applied to a model item property or field to identify it as a parameter
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class SqlTemplateParameterAttribute : Attribute
    {
        public SqlTemplateParameterAttribute()
        {

        }

        public SqlTemplateParameterAttribute(object DefaultValue, string ParameterName = null)
        {
            this.DefaultValue = DefaultValue;
            this.ParameterName = ParameterName;
        }


        public string ParameterName { get; }

        public object DefaultValue { get; }
    }
}
