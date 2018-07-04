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
    using System.Diagnostics;

    using static metacore;

    /// <summary>
    /// Encapsulates extended property index/lookup
    /// </summary>
    public class SqlPropertyIndex
    {
        static IReadOnlyList<SqlPropertyAttachment> EmptyList = rolist<SqlPropertyAttachment>();

        public static SqlPropertyIndex Create(IEnumerable<SqlPropertyAttachment> properties)
        {
            var idx = new SqlPropertyIndex();
            foreach (var groups in properties.GroupBy(x => x.SubjectName))
            {
                idx.storage.Add(groups.Key, rolist(groups.Select(x => x)));
            }
            return idx;
        }

        Dictionary<string, IReadOnlyList<SqlPropertyAttachment>> storage 
            = new Dictionary<string, IReadOnlyList<SqlPropertyAttachment>>();

        bool ContainsKey(string subjectName)
            => storage.ContainsKey(subjectName);

        [DebuggerStepThrough]
        public IReadOnlyList<SqlPropertyAttachment> GetProperties(string subjectName) 
            => ContainsKey(subjectName) ? storage[subjectName] : EmptyList;

        public Option<object> TryFindValue(string subjectName, string propertyName)
        {
            var result = default(object);
            if (ContainsKey(subjectName))
            {
                var properties = GetProperties(subjectName);
                var property = properties.FirstOrDefault(p => p.PropertyName == propertyName);
                if (property != null)
                    result = property.PropertyValue;
            }
            return result;
        }

        public Option<T> FindValue<T>(string subjectName, string propertyName)
            => TryFindValue(subjectName, propertyName).Map(x => cast<T>(x), () => none<T>());

        public IReadOnlyList<SqlPropertyAttachment> this[string subjectName] 
            => GetProperties(subjectName);

        public Option<object> this[string subjectName, string propertyName] 
            => TryFindValue(subjectName, propertyName);
    }
}
