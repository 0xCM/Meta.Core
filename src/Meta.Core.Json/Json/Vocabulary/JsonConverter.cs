//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

/// <summary>
/// Base type for custom JSON translation
/// </summary>
/// <typeparam name="T">The translation type</typeparam>
public abstract class JsonConverter<T> : IJsonConverter<T>
{
    IJsonSerializer serializer { get; }

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

