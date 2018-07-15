//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

using System;
using Meta.Core;

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

