//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;



    using static metacore;

    /// <summary>
    /// Encapsulates parameter validation error descriptions
    /// </summary>
    public sealed class ParameterValidationError 
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValidationError"/> type
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="ParameterValue"></param>
        /// <param name="ErrorDescription"></param>
        public ParameterValidationError(string ParameterName, string ParameterValue, string ErrorDescription)
        {
            this.ParameterName = ParameterName;
            this.ParameterValue = ParameterValue;
            this.ErrorDescription = ErrorDescription;
        }

        /// <summary>
        /// The name of the attribute that failed validation
        /// </summary>
        public string ParameterName { get; }

        /// <summary>
        /// The invalid attribute value
        /// </summary>
        public string ParameterValue { get; }

        /// <summary>
        /// Describes the nature of the error
        /// </summary>
        public string ErrorDescription { get; }

        public override string ToString() 
            => $"The value '{ParameterValue}' of {ParameterName} failed validation: {ErrorDescription}";
    }
}
