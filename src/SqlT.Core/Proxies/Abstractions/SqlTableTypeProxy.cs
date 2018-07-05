//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Text;


    /// <summary>
    /// Base type for SQL table type proxy representatives
    /// </summary>
    /// <typeparam name="T">The derived subtyp</typeparam>
    public abstract class SqlTableTypeProxy<T> : SqlTabularProxy<T>, ISqlTableTypeProxy<T>
        where T : SqlTableTypeProxy<T>, new()
    {


    }
}