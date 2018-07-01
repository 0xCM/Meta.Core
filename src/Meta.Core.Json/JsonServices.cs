//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using Newtonsoft.Json.Linq;

using static metacore;

/// <summary>
/// Provides access to context-free JSON services
/// </summary>
public static class JsonServices
{
    static Lazy<IJsonSerializer> _JsonSerializer
        = defer(() => (IJsonSerializer)new JsonSerializer());

    public static IJsonSerializer Serializer
        => _JsonSerializer.Value;

    public static Json ToJson<T>(T o)
        => Serializer.ObjectToJson(o);

    public static void ToObjectFile(object o, string path)
        => Serializer.ObjectToFile(o, path);

    public static object ToObject(Type t, Json j)
        => Serializer.ObjectFromJson(t, j);

    public static T ToObject<T>(this Json j)
        => Serializer.ObjectFromJson<T>(j);

    public static T FromObjectFile<T>(string path)
        => Serializer.ObjectFromFile<T>(path);

    public static bool SameAs(this Json j1, Json j2)
        => JToken.DeepEquals(JToken.FromObject(j1.Text), JToken.FromObject(j2.Text));
}
