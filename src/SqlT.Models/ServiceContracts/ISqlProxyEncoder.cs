//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines contract for proxy serialization and reconstitution
    /// </summary>
    public interface ISqlProxyEncoder
    {
        Option<int> EncodeDelimitedText(Type ProxyType, IEnumerable<ISqlTabularProxy> Input, FilePath Output, SqlProxyEncodingOptions Options = null);

        Option<int> EncodeDelimitedText<P>(IEnumerable<P> InputProxies, FilePath OutputFile, SqlProxyEncodingOptions Options = null)
            where P : class, ISqlTabularProxy, new();

        IEnumerable<P> DecodeDelimitedText<P>(FilePath InputFile, Action<IApplicationMessage> error, SqlProxyEncodingOptions Options = null)
            where P : class, ISqlTabularProxy, new();

        IEnumerable<T> DecodeDelimitedText<T>(string InputData, Action<IApplicationMessage> ErrorHandler, SqlProxyEncodingOptions Options)
            where T : class, ISqlTabularProxy, new();


    }



}
