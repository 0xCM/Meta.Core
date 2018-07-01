//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public interface IJsonValue : IValueObject
{
    string Name { get; }

    object Value { get; }

    Option<IJsonValue> TryFindValue(string path);

    Option<JsonPrimitiveValue> TryFindPrimitiveValue(string path);

    Option<JsonArrayValue> TryFindArrayValue(string path);
}
