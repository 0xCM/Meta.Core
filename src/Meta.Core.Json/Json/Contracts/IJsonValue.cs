//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public interface IJsonValue : IValueObject
{
    string Name { get; }

    object Value { get; }

    Option<IJsonValue> TryFindValue(string path);

    Option<JsonPrimitiveValue> TryFindPrimitiveValue(string path);

    Option<JsonArrayValue> TryFindArrayValue(string path);
}
