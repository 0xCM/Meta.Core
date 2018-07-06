//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;

    public class SqlMessageFormatBinding<P> : SqlProxyTypeBinding<P>
        where P : class, ISqlProxy, new()
    {
        public SqlMessageFormatBinding(TypedMessageFormat Format)
            : base(typeof(P))
            
        {
            this.Format = Format;
        }

        public TypedMessageFormat Format { get; }
    }
}