//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

using System;

public interface IJsonConverter
{
    Json ToJson(object o);

    object FromJson(Json j);

    bool Supports(Type t);
}

public interface IJsonConverter<T> : IJsonConverter
{
    Json ToJson(T r);

    new T FromJson(Json j);

}

