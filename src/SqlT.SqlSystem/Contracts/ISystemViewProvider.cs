//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
