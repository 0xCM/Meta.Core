//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Concurrent;
    using System.Linq.Expressions;


    using static minicore;

    /// <summary>
    /// Defines an association between a message type and a formatter for that message type
    /// that render text-based presentations for message type instances
    /// </summary>
    public class TypedMessageFormat
    {
        public static readonly TypedMessageFormat Default 
            = new TypedMessageFormat(typeof(object), string.Empty);

        public static string Render<M>(M Message)
        {
            var template = Lookup<M>().ValueOrDefault(Default);
            var result = format(Message, template);
            return result;
        }

        public static Option<TypedMessageFormat> Lookup(Type MessageType)
            => _Formats.TryFind(MessageType);

        public static Option<TypedMessageFormat> Lookup<T>()
            => Lookup(typeof(T));

        public static TypedMessageFormat Define<M>(string template, params Expression<Func<M, object>>[] Selectors)
        {
            var result = template;
            Selectors.Mapi((i, selector) 
                => result = result.Replace($"@p{i + 1}", $"@{selector.GetValueMemberName()}"));
            var format = new TypedMessageFormat(typeof(M), result);
            _Formats.TryAdd(typeof(M), format);
            return format;
        }

        public static void Register(IEnumerable<TypedMessageFormat> formats)
            => iter(formats, f => _Formats.TryAdd(f.MessageType, f));

        static ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>> _MessageProperties
            = new ConcurrentDictionary<Type, IReadOnlyDictionary<string, PropertyInfo>>();

        static ConcurrentDictionary<Type, TypedMessageFormat> _Formats
            = new ConcurrentDictionary<Type, TypedMessageFormat>();

        static IReadOnlyDictionary<string, PropertyInfo> properties<E>()
            => _MessageProperties.GetOrAdd(typeof(E), t => (from p in t.GetProperties()
                                                            where p.GetIndexParameters().Length == 0 && p.GetMethod != null
                                                            select p).ToDictionary(x => x.Name));
        static IEnumerable<NamedValue> propertyValues<E>(E @event)
            => from p in properties<E>().Values
               select new NamedValue(p.Name, p.GetValue(@event));

        static string formatValue(object value)
            => value?.ToString() ?? string.Empty;

        static string format<M>(M message, TypedMessageFormat template)
        {
            if (message == null)
                return "null";

            if (template.IsDefault)
                return message.ToString();

            var output = template.FormatString;
            foreach (var argValue in propertyValues(message))
            {
                var search = $"@{argValue.Name}";
                var replace = formatValue(argValue.Value);
                output = output.Replace(search, replace);
            }

            return output;
        }

        public TypedMessageFormat(Type MessageType, string FormatString)
        {
            this.MessageType = MessageType;
            this.FormatString = FormatString;
        }

        public Type MessageType { get; }

        public string FormatString { get; }

        public override int GetHashCode()
            => MessageType.GetHashCode();

        public override bool Equals(object obj)
            => MessageType.Equals(obj);

        public override string ToString()
            => FormatString;

        public bool IsDefault
            => MessageType == typeof(object) && isBlank(FormatString);

    }
}