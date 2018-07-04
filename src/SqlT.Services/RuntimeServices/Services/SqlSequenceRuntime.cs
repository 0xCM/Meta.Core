//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using SqlT.Core;
    using SqlT.Syntax;
    using System.Linq;

    using SqlT.Models;
    using SqlT.SqlSystem;

    using static metacore;

    class SqlSequenceRuntime : SqlObjectRuntime<SqlSequenceRuntime, ISqlSequenceHandle>, ISqlSequenceRuntime
    {
        public SqlSequenceRuntime(IApplicationContext C, ISqlSequenceHandle Handle)
            : base(C, Handle)
        {
            
        }

        public SqlSequenceName Name
            => Handle.ElementName;

        public Option<V> Restart<V>(V newValue)
            => Handle.Restart(newValue).Map(_ => newValue);

        public Option<V> CurrentValue<V>()
            => Database.SequenceCatalog
                    .TryGetFirst(seq => seq.ObjectName.AsSequenceName() == Name)
                    .Map(x => cast<V>(x.CurrentValue));

        public Option<V> NextValue<V>()
            => Broker.NextSequenceValue<V>(Handle.ElementName).ToOption();

        public Option<SqlSequenceName> Create(SqlTypeName TypeName)
        {
            var spec = new SqlSequence(
                SequenceName: Name,
                SequenceDataType: SqlNativeTypes.TryFind(TypeName).Require().Reference(false),
                InitialValue: "1",
                Increment: "1",
                CacheSize: "10"
                );
            return CreateElement(spec).Map(_ => Name);
        }

        public Option<V> ConfigureKeySequence<V>(V MaxKey)
            where V : IComparable

        {
            var z = CurrentValue<V>();
            if (!z)
                return z;

            var curSeqValue = z.ValueOrDefault();                            

            if (curSeqValue.CompareTo(MaxKey) < 0)
            {
                Print($"MaxKey: {MaxKey}, Current Sequence Value {Name}: {curSeqValue}");
                var restartAt = cast<V>(cast<long>(MaxKey) + 1L);
                Print($"Restarting sequence at {restartAt}");
                return Restart(restartAt);
            }
            else
                Print($"The {Name} sequence requires no adjustment");
            return curSeqValue;
        }
    }
}