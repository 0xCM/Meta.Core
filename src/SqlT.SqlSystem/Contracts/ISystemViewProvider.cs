//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;


    public interface ISystemViewProvider : INativeViewProvider, IVirtualViewProvider
    {
        /// <summary>
        /// The server to which the provider is connected
        /// </summary>
        string HostServerName { get; }

        /// <summary>
        /// The database for which metadata is being provided
        /// </summary>
        string HostDatabaseName { get; }
        
    }


}
