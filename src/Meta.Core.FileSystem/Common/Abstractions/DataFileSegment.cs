//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Represents a logical segment in a file
/// </summary>
/// <remarks>
/// For a text file, this corresponds to a line; for a binary file, it could correspond to a segment of bytes of a given length, etc. 
/// </remarks>
public abstract class DataFileSegment 
{
    protected readonly object data;

    protected DataFileSegment(object data)
    {
        this.data = data;
    }

    public object Data => data;


}

public abstract class DataFileSegment<T> : DataFileSegment
{

    public DataFileSegment(T data)
        : base(data)
    {

    }
    public new T Data => (T)data;

}




