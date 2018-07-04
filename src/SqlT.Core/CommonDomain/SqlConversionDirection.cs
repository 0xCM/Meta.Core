//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Classifes data flow direction with respect to proxies
    /// </summary>
    public enum SqlConversionDirection : byte
    {
        /// <summary>
        /// Indicates that a converter produces a value that is compatible with
        /// the standard transport types supported by ADO.NET
        /// </summary>
        ToTransport = 1,
        /// <summary>
        /// Indicates that a converter produces a value that is compatible with
        /// a CLR runtime type
        /// </summary>
        ToProxy = 2
    }

}