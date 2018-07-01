//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Mime;

/// <summary>
/// Base type for data files that held in memory
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class MemoryFile<T> : DataFile<T>
    where T : DataFileSegment      
{
    protected readonly byte[] data;

    public MemoryFile(byte[] data, ContentType FileContentTpe = null)
        : base(String.Empty, FileContentTpe ?? MimeTypes.Binary)
    {
        this.data = data;
    }

    protected Stream CreateStream() 
        => new MemoryStream(data);
}