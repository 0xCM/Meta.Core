//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Characterizes parameter that can be supplied in an HTTP request
    /// </summary>
    public class HttpRequestParameter : ValueObject<HttpRequestParameter>
    {
        /// <summary>
        /// Then name of the parameter
        /// </summary>
        public readonly string ParameterName;

        /// <summary>
        /// The (escaped or unescaped) value of the parameter
        /// </summary>
        public readonly string ParameterValue;

        public HttpRequestParameter(HttpParameterSpec ParameterSpec, object ParameterValue)
        {
            this.ParameterName = ParameterSpec.ParameterName;
            this.ParameterValue = isBlank(ParameterSpec.FormatSpecifier) 
                                ? ParameterValue.ToString() 
                                : String.Format("{0:" + ParameterSpec.FormatSpecifier + "}", ParameterValue);
            
        }

        /// <summary>
        /// Renders a textual representation of the parameter that is suitable
        /// for diagnostic purposes but not for the purpose of formatting the
        /// request for submission
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
            => $"{ParameterName}={ParameterValue}";
    }
}
