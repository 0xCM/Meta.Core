//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Represents a fundamental metadata type
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class CoreMetadataType<T> : CoreDataType<T>
{
    public CoreMetadataType(string DataTypeName)
        : base(DataTypeName)
    { }
}
