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
    /// Identifies an HTTP Content/MIME type
    /// </summary>
    public class HttpMediaType : ValueObject<HttpMediaType>
    {
        public static implicit operator string(HttpMediaType x) => x.Name;

        /// <summary>
        /// The name of the media type
        /// </summary>
        public readonly string Name;

        public HttpMediaType(string Name)
        {
            this.Name = Name;
        }
    }
}
