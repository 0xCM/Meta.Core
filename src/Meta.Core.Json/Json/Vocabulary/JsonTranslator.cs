//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Facilitates functional extensibility for the JSOn serializer
/// </summary>
public class JsonTranslator : IJsonConverter
{
    readonly Func<Type, bool> CanTranslate;
    readonly Func<object, Json> ObjectToJson;
    readonly Func<Json, object> JsonToObject;

    public JsonTranslator(Func<Type, bool> CanTranslate, Func<object, Json> ObjectToJson, Func<Json, object> JsonToObject)
    {
        this.CanTranslate = CanTranslate;
        this.ObjectToJson = ObjectToJson;
        this.JsonToObject = JsonToObject;
    }

    public Json Translate(object o)
        => ObjectToJson(o);

    public object Translate(Json j)
        => JsonToObject(j);

    public bool Supports(Type t)
        => CanTranslate(t);

    Json IJsonConverter.ToJson(object o)
        => Translate(o);

    object IJsonConverter.FromJson(Json j)
        => Translate(j);
}
