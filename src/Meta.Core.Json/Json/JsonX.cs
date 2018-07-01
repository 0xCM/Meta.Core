﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;


public static class JsonX
{
    /// <summary>
    /// Obtains a reference to the JSON serialization service
    /// </summary>
    /// <param name="C">The extended context</param>
    /// <returns></returns>
    public static IJsonSerializer JsonSerializer(this IApplicationContext C)
        => C.Service<IJsonSerializer>();


    /// <summary>
    /// Hydrates an object from a JSON representation
    /// </summary>
    /// <typeparam name="T">The type of object to hydrate</typeparam>
    /// <param name="C">The extended context</param>
    /// <param name="J">A JSON block representing an object of type <typeparamref name="T"/></param>
    /// <returns></returns>
    public static T ObjectFromJson<T>(this IApplicationContext C, Json J)
        => C.JsonSerializer().ObjectFromJson<T>(J);

    public static JsonParser GetParser(this IJsonSerializer s)
        => (type, json) => s.ObjectFromJson(type, json);

    public static JsonAttributeParser GetAttributeParser(this IJsonSerializer s)
        => json => s.DeserializeAttributes(json);

    public static JsonParser<T> GetParser<T>(this IJsonSerializer s)
        => json => s.ObjectFromJson<T>(json);


}