//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mime;

/// <summary>
/// Lists a few of the most basic content types. See http://mimeapplication.net/ for a complete catalog
/// </summary>
public class MimeTypes
{
    public static readonly ContentType Text = new ContentType("text/plain");
    public static readonly ContentType JSON = new ContentType("application/json");
    public static readonly ContentType Binary = new ContentType("application/octet-stream");
    public static readonly ContentType CSV = new ContentType("text/csv");
    public static readonly ContentType XLS = new ContentType("application/vnd.ms-excel");
}
