//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

public sealed class JsonPrimitiveValue : JsonValue<JsonPrimitiveValue>, IJsonPrimitiveValue
{
    public static implicit operator JsonPrimitiveValue(string x) 
        => new JsonPrimitiveValue(string.Empty, x);

    public static implicit operator string(JsonPrimitiveValue x) 
        => toString(x.Value);

    public static implicit operator int(JsonPrimitiveValue x) 
        => convert<int>(x.Value);

    public static implicit operator DateTime(JsonPrimitiveValue x) 
        => convert<DateTime>(x.Value);

    public JsonPrimitiveValue(string Name, object Value)
        : base(Name, Value)
    {

    }

    public override string ToString() 
        => isBlank(Name) ? toString(Value) : $"{Name}: {Value}";

}
