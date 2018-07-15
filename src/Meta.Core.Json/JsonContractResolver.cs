//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Defines custom contract resolver that excludes read-only properties from serialization
    /// </summary>
    class JsonContractResolver : DefaultContractResolver
    {
        static bool IsReadOnlyProperty(Type type, string memberName)
        {
            var prop = type.GetProperty(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return prop != null ? !prop.CanWrite : false;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            if (type.Realizes<IValueObject>())
            {
                var valueMembers = type.GetValueMembers().ToSet(x => x.Name);
                return base.CreateProperties(type, memberSerialization).Where(p => valueMembers.Contains(p.PropertyName)).ToList();
            }
            else
                return base.CreateProperties(type, memberSerialization)
                        .Where(p => !IsReadOnlyProperty(type, p.PropertyName)).ToList();
        }



    }

}
