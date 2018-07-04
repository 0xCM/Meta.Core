//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface ISqlColumnReader : IEnumerable, IDisposable
    {

    }

    public interface ISqlColumnReader<TCol>
        : ISqlColumnReader, IEnumerable<DataFrameRow<TCol>>
    {

    }
    public interface ISqlColumnReader<TCol1, TCol2> 
        : ISqlColumnReader,  IEnumerable<DataFrameRow<TCol1, TCol2>>
    {

    }

    public interface ISqlColumnReader<TCol1, TCol2, TCol3> 
        : ISqlColumnReader, IEnumerable<DataFrameRow<TCol1, TCol2, TCol3>>
    { }

    public interface ISqlColumnReader<TCol1, TCol2, TCol3, TCol4>
        : ISqlColumnReader, IEnumerable<DataFrameRow<TCol1, TCol2, TCol3,TCol4>>
    { }


}
