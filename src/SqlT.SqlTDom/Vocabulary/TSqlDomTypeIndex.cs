//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using SqlT.Models;
    using SqlT.Core;    

    using static metacore;

    /// <summary>
    /// Implements utilities for TSql DOM discovery
    /// </summary>
    public static class TSqlDomTypeIndex
    {
        static IReadOnlyDictionary<string, ReadOnlyList<ClrProperty>> TSqlTypes
            = map(ClrAssembly.Get(typeof(TSql.TSqlParser).Assembly).NamedPublicTypes,
                    t => (t.Name,
                    t.PublicInstanceProperties.ToReadOnlyList())).ToReadOnlyDictionary();

        public static IReadOnlyList<ClrProperty> DomProperties(Type DomType)
            => TSqlTypes.TryFind(DomType.Name).ValueOrDefault(rolist<ClrProperty>());

        public static IReadOnlyList<ClrProperty> DomProperties(this TSql.TSqlFragment tSql)
            => TSqlTypes[tSql.GetType().Name];

        public static IEnumerable<(ClrProperty Property, ClrType ElementType)> CollectionProperties(ClrType SqlDomType)
            => from p in SqlDomType.PublicInstanceProperties
               where p.PropertyType.IsGenericEnumerableType
               let typeArg = p.PropertyType.GenericTypeArguments.Single()
               where typeArg.ReflectedElement.IsSubclassOf(typeof(TSql.TSqlFragment))
               select (p, typeArg.ArgumentType);

        public static IEnumerable<ClrProperty> AttributeProperties(ClrType SqlDomType)
            => from p in DomProperties(SqlDomType)
               where p.PropertyType.IsEnumType
                 || p.PropertyType.IsPrimitive
                 || p.PropertyType == typeof(string)
               select p;

        public static IEnumerable<ClrProperty> AssociationProperties(Type SqlDomType)
            => from p in DomProperties(SqlDomType)
               where p.PropertyType.IsSubclassOf<TSql.TSqlFragment>()
               && not(p.IsIndexer)
               select ClrProperty.Get(p);

        public static IReadOnlyDictionary<ClrProperty, TSql.TSqlFragment> ClrPropertyIndex(this TSql.TSqlFragment tSql)
        {
            var values =
                from prop in tSql.GetType().GetPublicProperties(true)
                where prop.PropertyType.IsSubclassOf(typeof(TSql.TSqlFragment))
                let v = prop.GetValue(tSql) as TSql.TSqlFragment
                where v != null
                select (prop: ClrProperty.Get(prop), v);

            return values.ToDictionary(x => x.prop, x => x.v);

        }

        public static IReadOnlyDictionary<ClrProperty, ReadOnlyList<TSql.TSqlFragment>> ClrCollectionIndex(this TSql.TSqlFragment tSql)
        {
            var props = rolist(ClrClass.Get(tSql.GetType()).PublicInstanceProperties);

            var genericListProps = rolist(from p in props
                                        where p.PropertyType.IsGenericEnumerableType
                                        select p);
            var values =
                from prop in genericListProps
                let typeArg = prop.PropertyType.GenericTypeArguments.Single()
                where typeArg.ReflectedElement.IsSubclassOf(typeof(TSql.TSqlFragment))
                let v = prop.GetValue(tSql) as IEnumerable
                where v != null
                select (prop, v);

            var index = from cv in values
                        select (cv.prop, list: rolist(cv.Item2.Cast<TSql.TSqlFragment>()));

            return index.ToDictionary(i => i.prop, i => i.list);

        }

        public static IReadOnlyDictionary<ClrProperty, object> ClrScalarIndex(this TSql.TSqlFragment tSql)
            => (from
                    p in tSql.DomProperties()
                where
                    p.PropertyType.IsEnumType
                        || p.PropertyType.IsPrimitive
                        || p.PropertyType == typeof(string)
                select
                    (p, p.GetValue(tSql))
            ).ToDictionary(x => x.p, x => x.Item2);

    }
}
