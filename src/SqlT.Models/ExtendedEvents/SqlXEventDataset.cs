//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public class SqlXEventDataset
    {
        public SqlXEventDataset(string EventName, Guid EventUid, DateTimeOffset EventOS, IEnumerable<NamedValue> FieldValues, IEnumerable<NamedValue> ActionValues)
        {
            this.EventName = EventName;
            this.EventUid = EventUid;
            this.EventTS = EventOS.LocalDateTime;
            this.FieldValues = FieldValues.ToArray();
            this.ActionValues = ActionValues.ToArray();
        }

        public string EventName { get; }

        public Guid EventUid { get; }

        public DateTime EventTS { get; }

        public NamedValues FieldValues { get; }

        public NamedValues ActionValues { get; }

        public T FieldValue<T>(string name)
            => cast<T>(FieldValues[name]);

        public T FieldValue<T>(int idx)
            => cast<T>(FieldValues[idx]);

        public T ActionValue<T>(string name)
            => cast<T>(ActionValues[name]);

        public T ActionValue<T>(int idx)
            => cast<T>(ActionValues[idx]);

        public IReadOnlyDictionary<string, object> FieldValueSelection(IReadOnlySet<string> FieldNames)
            => dict(from v in FieldValues
                    where FieldNames.Contains(v.Name)
                    select (v.Name, v.Value));

        public IReadOnlyDictionary<string, object> ActionValueSelection(IReadOnlySet<string> ActionNames)
            => dict(from v in FieldValues
                    where ActionNames.Contains(v.Name)
                    select (v.Name, v.Value));
    }

}