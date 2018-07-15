//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

using Meta.Core;

public delegate object JsonParser(Type t, Json json);
public delegate object JsonParser<T>(Json json);
public delegate IReadOnlyDictionary<string, object> JsonAttributeParser(Json json);

/// <summary>
/// Defines contract for accessing JSON-related services
/// </summary>
public interface IJsonSerializer
{
    /// <summary>
    /// Creates a dictionary lookup from json attributes
    /// </summary>
    /// <param name="json">The json to parse</param>
    /// <returns></returns>
    IReadOnlyDictionary<string, object> DeserializeAttributes(Json json);

    Json SerializeAttributes(IReadOnlyDictionary<string, object> attributes);

    /// <summary>
    /// Transforms an object to its JSON representation
    /// </summary>
    /// <param name="o">The object to transform</param>
    /// <param name="indented">Whether to use the indented output mode</param>
    /// <returns></returns>
    Json ObjectToJson(object o, bool indented = true);

    /// <summary>
    /// Transforms an object to JSON and emits the representation to a file
    /// </summary>
    /// <param name="o">The object to emit</param>
    /// <param name="path">The output path</param>
    /// <param name="indented">Whether to use the indented output mode</param>
    Option<IFilePath> ObjectToFile(object o, FilePath path, bool indented = true);

    /// <summary>
    /// Reconstitutes a value of type <typeparamref name="T"/> from its JSON representation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    T ObjectFromJson<T>(Json json);

    /// <summary>
    /// Reconstitutes a value of type <paramref name="t"/> from its JSON representation
    /// </summary>
    /// <param name="t">The type of value to reconsitute</param>
    /// <param name="json">The JSON representation</param>
    /// <returns></returns>
    object ObjectFromJson(Type t, Json json);

    T ObjectFromFile<T>(string path);

    object ObjectFromFile(Type t, string path);

    void RegisterConverter(IJsonConverter converter);

}


