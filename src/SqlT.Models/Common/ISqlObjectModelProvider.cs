//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface ISqlObjetModelProvider
    {

        IEnumerable<ISqlObject> Models { get; }

    }

    public interface ISqlObjectModelProvider<T> : ISqlObjetModelProvider
        where T : ISqlObject
    {

        new IEnumerable<T> Models { get; }
    }



}
