//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

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