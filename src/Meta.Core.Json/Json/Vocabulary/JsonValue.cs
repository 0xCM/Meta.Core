//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

/// <summary>
/// Defines utilities for querying/manipulating JSON 
/// </summary>
static class JsonValue
{
    static Option<IJsonValue> TryFindChild(IJsonValue value, string name)
    {

        var composite = value as IJsonCompositeValue;
        if (composite != null)
        {
            foreach (var child in composite.Items)
            {
                if (child.Name == name)
                    return some(child);
            }
        }
        return none<IJsonValue>();
    }

    internal static Option<IJsonValue> TryFindValue(IJsonValue start, string path)
    {
        var current = start;
        foreach (var name in path.Split('.'))
        {
            var child = TryFindChild(current, name);
            if (!child)
            {
                current = null;
                break;
            }

            current = child.ValueOrDefault();
        }
        return new Option<IJsonValue>(current);
    }

    internal static Option<JsonPrimitiveValue> TryFindPrimitiveValue(IJsonValue start, string path)
    {
        var v = JsonValue.TryFindValue(start, path);
        return v ? new Option<JsonPrimitiveValue>((v.ValueOrDefault() as JsonPrimtivePropertyValue).PrimitiveValue)
                    : none<JsonPrimitiveValue>();
    }

    internal static Option<JsonArrayValue> TryFindArrayValue(IJsonValue start, string path)
    {
        var v = JsonValue.TryFindValue(start, path);
        if (v)
            return cast<JsonArrayPropertyValue>(v.ValueOrDefault()).ArrayValue;

        return none<JsonArrayValue>();
    }
}

/// <summary>
/// Base type for JSON values
/// </summary>
/// <typeparam name="T">The derived subtype</typeparam>
public abstract class JsonValue<T> : JsonComponent<T>, IJsonValue
    where T : JsonValue<T>
{
    public readonly string Name;
    public readonly object Value;

    protected JsonValue(object Value)
    {
        this.Name = String.Empty;
        this.Value = Value;
    }

    protected JsonValue(string Name, object Value)
    {
        this.Name = Name;
        this.Value = Value;
    }

    string IJsonValue.Name 
        => Name;

    object IJsonValue.Value 
        => Value;

    Option<IJsonValue> IJsonValue.TryFindValue(string path) 
        => JsonValue.TryFindValue(this, path);

    public Option<JsonPrimitiveValue> TryFindPrimitiveValue(string path) 
        => JsonValue.TryFindPrimitiveValue(this, path);

    public Option<JsonArrayValue> TryFindArrayValue(string path) 
        => JsonValue.TryFindArrayValue(this, path);

    public override string ToString() 
        => $"{Name} : {Value}";
}
