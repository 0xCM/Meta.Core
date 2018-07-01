﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.DTO
{
    public interface IDtoValueFormatter
    {
        string FormatValue(object value);

    }

    public interface IDtoValueFormatter<V> : IDtoValueFormatter
        where V : ITypeValue
    {
        string FormatValue(V value);
    }

}
