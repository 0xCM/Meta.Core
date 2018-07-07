//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    using Meta.Core;

    public interface ISqlDataset
    {
        SqlDatasetDesignator Designator { get; }

        Seq<ISqlTabularProxy> Rows { get; }
    }

    public interface ISqlDataset<T> : ISqlDataset
        where T : class, ISqlTabularProxy, new()
    {        
        new Lst<T> Rows { get; }

    }

}