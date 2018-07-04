//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    /// <summary>
    /// Records the association between a proxy type and an applied identifying attribute
    /// </summary>
    class SqlProxyAttribution
    {
        public SqlProxyAttribution(Type ProxyType, SqlProxyAttribute Attribute)
        {
            this.ProxyType = ProxyType;
            this.Attribute = Attribute;
        }

        public Type ProxyType { get; }

        public SqlProxyAttribute Attribute { get; }

        public override string ToString()
            => $"{ProxyType.Name}: {Attribute}";

    }

}