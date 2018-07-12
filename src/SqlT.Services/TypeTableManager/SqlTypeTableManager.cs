//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Models;
    using SqlT.Types;
    using SqlT.Syntax;

    using static SqlT.Syntax.SqlNativeTypes;
    using static SqlT.Models.SqlModelBuilders;
    using static metacore;

    class SqlTypeTableManager : ApplicationService<SqlTypeTableManager, ISqlTypeTableManager>, ISqlTypeTableManager
    {
        static ReadOnlySet<Type> DataContracts
            = roset(typeof(ITinyTypeTable), typeof(ISmallTypeTable), typeof(ILargeTypeTable));

        public SqlTypeTableManager(IApplicationContext C)
            : base(C)
        {
            
        }

        public SqlTable DefineTypeTable<E>(SqlSchemaName Schema, SqlTableName TableName = null)
            => DefineTypeTable(typeof(E), Schema, TableName);

        public SqlTable DefineTypeTable(Type EnumType, SqlSchemaName Schema, SqlTableName TableName = null)
        {
            var name = ifNull(TableName, () => new SqlTableName(EnumType.Name)).WithSchema(Schema);
            var table = from t in Table(name, EnumType.GetCustomAttribute<DescriptionAttribute>()?.Description)

                        let type = EnumType.GetEnumUnderlyingType()
                        let typeCodeField = new CoreDataFieldDescription(1, "TypeCode", type.ToCoreType().Require(), new CoreDataFacets(IsValueRequired: true))
                        from c1 in t.WithColumn(typeCodeField)
                        from c2 in t.WithColumn("Identifier", nvarchar.Reference(false, 75))
                        from c3 in t.WithColumn("Label", nvarchar.Reference(true, 75))
                        from c4 in t.WithColumn("Description", nvarchar.Reference(true, 250))
                        from c5 in t.WithColumn("CreateTS", datetime2.Reference(false, scale: 0 ))
                        from c6 in t.WithColumn("UpdateTS", datetime2.Reference(true, scale: 0))
                        from pk in t.WithPrimaryKey(typeCodeField.Name)
                        let ix = from i in UniqueIndex($"UQIX_{name.UnquotedLocalName}", name, "Identifier")
                                 select i.Complete()
                        from uq in t.WithIndex(~ix)
                        select t.Complete();
            return ~table;

        }

        public Option<int> UpdateTypeTable(ISqlProxyBroker Broker, SqlTableName TypeTableName, Type enumType)
        {
            var tableDescription = Broker.Metadata.Tables.TryGetSingle(x => x.ObjectName == TypeTableName);
            if (!tableDescription)
                return none<int>(AppMessage.Error($"The {TypeTableName} table could not be found"));
            else if (!PXM.IsTypeTable((~tableDescription)))
                return none<int>(AppMessage.Error($"The {TypeTableName} table is not a type table"));

            var proxyType = (~tableDescription).RuntimeType;
            var literals = ClrEnum.Get(enumType).Literals;

            var proxies = rolist(from literal in literals.Stream()
                               let proxy = (ISqlTableProxy)Activator.CreateInstance(proxyType)
                               let adapter = SqlTypeTableAdapter.Adapt(proxy)
                               select adapter.Specify(literal));

            var exclusions = map(
                SqlColumnRole.AuditRoleTypes.Union(stream(SqlColumnRoleKind.SystemVersion)),
                r => SqlColumnRole.DefaultRoleColumnNames[r].UnqualifiedName);

            return (from t in Broker.Table(TypeTableName).TruncateIfExists()
                    from l in Broker.BulkCopy(proxyType, proxies, proxies.Count, exclusions)
                    select l);
        }

        Option<int> ISqlTypeTableManager.UpdateTypeTable<T, E>(ISqlProxyBroker Broker)
            => UpdateTypeTable(Broker, PXM.TableName<T>(), typeof(E));

        public Option<int> UpdateTypeTable(ISqlProxyBroker Broker, ISqlProxyTypeBinding Binding)
            => UpdateTypeTable(Broker, PXM.Table(Binding.ProxyType).ObjectName, Binding.BoundType);
    }

}
