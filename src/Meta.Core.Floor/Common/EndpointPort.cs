//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{



    public enum EndpointPort
    {
        None = 0,

        /// <summary>
        /// Indicates the endpoint is the target
        /// </summary>
        Incoming = 1,

        /// <summary>
        /// Indicates the endpoint is the source
        /// </summary>
        Outgoing = 2
    }



}