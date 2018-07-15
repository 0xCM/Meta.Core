//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static metacore;

public class JsonDocument : JsonComponent<JsonDocument>, IJsonCompositeValue
{
    public IReadOnlyList<IJsonValue> Content;
    public readonly string Name;
    public readonly string SourceText;

    public JsonDocument(params IJsonValue[] Content)
    {
        this.Content = rovalues(Content);
        this.Name = String.Empty;
        this.SourceText = String.Empty;
    }

    public JsonDocument(IEnumerable<IJsonValue> Content, string Name = null, string SourceText = null)
    {
        this.Content = rovalues(Content);
        this.Name = Name ?? String.Empty;
        this.SourceText = SourceText ?? String.Empty;
    }


    IReadOnlyList<IJsonValue> IJsonCompositeValue.Items 
        => Content;

    string IJsonValue.Name 
        => Name;

    object IJsonValue.Value 
        => Content;

    public Option<IJsonValue> TryFindValue(string path) 
        => JsonValue.TryFindValue(this, path);

    public Option<JsonPrimitiveValue> TryFindPrimitiveValue(string path) 
        => JsonValue.TryFindPrimitiveValue(this, path);

    public Option<JsonArrayValue> TryFindArrayValue(string path) 
        => JsonValue.TryFindArrayValue(this, path);


}
