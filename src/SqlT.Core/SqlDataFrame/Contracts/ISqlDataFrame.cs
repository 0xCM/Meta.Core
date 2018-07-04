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
    using System.Data;
    using System.Linq;


    public interface ISqlDataFrame : IEnumerable
    {
        IReadOnlyList<SqlColumnIdentifier> Columns { get; }

        IReadOnlyList<object[]> Rows { get; }

        IDataReader GetReader();
    }

    public interface ISqlDataFrame<F> : ISqlDataFrame, IEnumerable<F>
        where F : class, ISqlTabularProxy, new()
    {

    }
}