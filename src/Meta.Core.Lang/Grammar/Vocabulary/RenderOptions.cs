//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using static metacore;

    using System;
    using System.Linq;

    /// <summary>
    /// Defines syntax specification rendering options
    /// </summary>
    public class RenderOptions
    {

        public RenderOptions(string Prefix = null, string Postfix = null)
        {
            this.Prefix = ifBlank(Prefix, string.Empty);
            this.Postfix = ifBlank(Postfix, string.Empty);
        }

        /// <summary>
        /// Text that immediately precedes emitted syntax representation
        /// </summary>
        public string Prefix { get; }

        /// <summary>
        /// Text that immediately follows emitted syntax representation
        /// </summary>
        public string Postfix { get; }
        
    }

}