//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;


public abstract class SemanticFileName<T> : FileName<T>
    where T : SemanticFileName<T>, new()
{
    protected SemanticFileName()
        : base(String.Empty)
    { }

    protected SemanticFileName(string Value)
        : base(Value ?? String.Empty)
    { }

    protected SemanticFileName(string Value, FileExtension Extension)
        : base(Value, Extension)
    { }

    public virtual FileExtension CanonicalExtension { get; }
        = FileExtension.Empty;

   
}
