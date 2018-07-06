//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.SqlSystem;

    using PN = SqlT.Core.SqlPropertyNames;

    /// <summary>
    /// Defines extension methods to facilitate extended property manipulation/interrogation
    /// </summary>
    public static class SqlPropertyExtensions
    {
        public static Option<IExtendedProperty> TryFindProperty(this IExtendedPropertyProvider x, SqlExtendedPropertyName PropertyName)
            => x.Properties.TryFind(PropertyName);

        public static Option<SqlFormatStringProperty> FormatString(this IExtendedPropertyProvider provider)
            => provider.TryFindProperty(PN.FormatString)
                       .Map(x => new SqlFormatStringProperty(x.value?.ToString()));        

        public static Option<SqlDataContractProperty> DataContract(this IExtendedPropertyProvider provider)
            => provider.TryFindProperty(PN.DataContract)
                       .Map(x => new SqlDataContractProperty(x.value?.ToString()));

        public static Option<SqlEnumProviderProperty> SqlEnumProvider(this IExtendedPropertyProvider provider)
                => provider.TryFindProperty(PN.EnumProvider)
                        .Map(x => new SqlEnumProviderProperty(x.value?.ToString()));

        public static Option<SqlExternalContractProperty> ExternalContract(this IExtendedPropertyProvider provider)
            => provider.TryFindProperty(PN.ExternalContract)
                       .Map(x => new SqlExternalContractProperty(x.value?.ToString()));
        public static Option<SqlRecordContractProperty> RecordContract(this IExtendedPropertyProvider provider)
            => provider.TryFindProperty(PN.RecordContract)
                       .Map(x => new SqlRecordContractProperty(x.value?.ToString()));

        public static IEnumerable<SqlFormatStringProperty> FormatStrings(this IEnumerable<IExtendedProperty> properties)
                => from p in properties
                   where p.name == PN.FormatString
                   select new SqlFormatStringProperty(toString(p.value));

        //This extends too many things
        static ISqlPropertyApplication<P, V, E> ApplyTo<P, V, E>(this P Property, E Element)
            where P : ISqlCustomProperty<V>
            where E : IExtensibleElement
                => new SqlPropertyApplication<P, V, E>(Property, Element);


        public static bool IsEnumProvider(this IExtendedPropertyProvider provider)
            => provider.TryFindProperty(PN.EnumProvider).IsSome();

    }
}