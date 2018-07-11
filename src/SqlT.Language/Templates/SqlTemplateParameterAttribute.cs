//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
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
