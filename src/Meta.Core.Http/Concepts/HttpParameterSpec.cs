//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
        
    
    /// <summary>
    /// Codifies an association between a proxy/representation attribute and a request parameter
    /// </summary>
    public sealed class HttpParameterSpec : ValueObject<HttpParameterSpec> 
    {

        /// <summary>
        /// The name of the representation
        /// </summary>
        public readonly string EntityName;

        /// <summary>
        /// The name of the representation attribute
        /// </summary>
        public readonly string AttributeName;

        /// <summary>
        /// The name of the parameter
        /// </summary>
        public readonly string ParameterName;

        /// <summary>
        /// The format specifier applied to the attribute value when formatting a request, when applicable
        /// </summary>
        public readonly string FormatSpecifier;

        public HttpParameterSpec
            (
                string EntityName, 
                string AttributeName, 
                string ParameterName, 
                string FormatSpecifier = null,
                bool UriParameter = false
            )
        {

            this.EntityName = EntityName;
            this.AttributeName = AttributeName;
            this.ParameterName = ParameterName;
            this.FormatSpecifier = FormatSpecifier;
        }

        public override string ToString() 
            => $"{EntityName}.{AttributeName}=>{ParameterName}";

    }




}
