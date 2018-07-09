//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;

    /// <summary>
    /// Defines contract for proxy serialization and reconstitution
    /// </summary>
    public interface ISqlProxyEncoder
    {
        Option<int> EncodeDelimitedText(Type ProxyType, IEnumerable<ISqlTabularProxy> sourceProxies, 
            FilePath targetFile, SqlProxyEncodingOptions options = null);

        Option<int> EncodeDelimitedText<P>(IEnumerable<P> sourceProxies, FilePath targetFile, 
            SqlProxyEncodingOptions options = null)
                where P : class, ISqlTabularProxy, new();

        IEnumerable<P> DecodeDelimitedText<P>(FilePath sourceFile, Action<IApplicationMessage> onError, 
            SqlProxyEncodingOptions options = null)
                where P : class, ISqlTabularProxy, new();

        IEnumerable<T> DecodeDelimitedText<T>(string sourceText, Action<IApplicationMessage> onError, 
            SqlProxyEncodingOptions options)
                where T : class, ISqlTabularProxy, new();
    }
}
