//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Base type for custom JSON translation
/// </summary>
/// <typeparam name="T">The translation type</typeparam>
public abstract class JsonConverter<T> : IJsonConverter<T>
{
    private readonly IJsonSerializer serializer;
    protected IJsonSerializer Serializer 
            => serializer;

    protected JsonConverter(IJsonSerializer serializer)
    {
        this.serializer = serializer;
    }

    public virtual T FromJson(Json j) 
        => Serializer.ObjectFromJson<T>(j);

    public virtual Json ToJson(T r) 
        => Serializer.ObjectToJson(r);

    Json IJsonConverter.ToJson(object r) 
        => ToJson((T)r);

    object IJsonConverter.FromJson(Json j) 
        => FromJson(j);


    bool IJsonConverter.Supports(Type t)
        => typeof(T) == t;
}

