//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using static metacore;
    using SqlT.Core;

    public class SqlSequenceDescription : ValueObject<SqlSequenceDescription>
    {
        public readonly string SequenceName;
        public readonly CoreDataType ItemType;
        public readonly CoreDataValue MinValue;
        public readonly CoreDataValue MaxValue;
        public readonly CoreDataValue InitialValue;
        public readonly CoreDataValue Increment;
        public readonly bool Cycle;

        public SqlSequenceDescription(
            string SequenceName,
            CoreDateType DataType = null,
            CoreDataValue MinValue = null,
            CoreDataValue MaxValue = null,
            CoreDataValue InitialValue = null,
            CoreDataValue Increment = null,
            bool Cycle = false
            )
        {
            this.SequenceName = SequenceName;
            this.ItemType = coalesce(DataType, (CoreDataType)CoreDataTypes.Int32);
            this.MinValue = coalesce(MinValue, 0);
            this.MaxValue = coalesce(MaxValue, Int32.MaxValue);
            this.InitialValue = coalesce(MaxValue, 1);
            this.Increment = coalesce(InitialValue, 1);
        }
    }

    public class SqlSequenceDescription<T> 
        where T : IComparable
    {
        public SqlSequenceName SequenceName { get; }

        public CoreDataType ItemType { get; }

        public Option<T> MinValue { get; }

        public Option<T> MaxValue { get; }

        public Option<T> InitialValue { get; }

        public Option<T> Increment { get; }

        public Option<T> CacheSize { get; }

        public bool Cycle { get; }

    }
}
