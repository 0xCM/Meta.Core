//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using SqlT.Core;


    public interface ISqlSequenceRuntime : ISqlObjectRuntime
    {
        SqlSequenceName Name { get; }

        Option<V> Restart<V>(V newValue);

        Option<V> CurrentValue<V>();

        Option<V> NextValue<V>();

        Option<SqlSequenceName> Create(SqlTypeName SequenceType);

        Option<V> ConfigureKeySequence<V>(V MaxKey) 
            where V : IComparable;

    }

}