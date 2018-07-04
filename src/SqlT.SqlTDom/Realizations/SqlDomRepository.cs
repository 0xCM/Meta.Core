//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.CSharp;
    using SqlT.Services;
    using SqlT.SqlTDom;

    using static metacore;

    using DomTypes = SqlT.Types.SqlDom;
    using DomStore = SqlT.SqlStore.SqlDom;

    class SqlDomRepository : ApplicationService<SqlDomRepository, ISqlDomRepository>, ISqlDomRepository
    {
        static ISqlProxyBroker SqlStoreBroker
            => SqlTStoreProxies.Assembly.ProxyBroker(SqlConnectionString.Build().LocalConnection("SqlT").UsingIntegratedSecurity());

        public SqlDomRepository(IApplicationContext C)
            : base(C)
        {

        }

        ISqlDomServices DomServices
            => C.SqlDomServices();

        ISqlMetamodelServices MetamodelServices
            => C.SqlMetamodelSevices();

        IEnumerable<SqlDomTypeDescriptor> DomTypes
            => MetamodelServices.DescribeDomTypes();

        IEnumerable<SqlDomTypeDescriptor> EnumTypes
            => from t in DomTypes
               where t.IsEnum
               select t;

        static IEnumerable<DomTypes.ElementAttribute> StoreAttributes(SqlDomTypeDescriptor descriptor)
            => from a in descriptor.Attributes
               select a.ToRecord();

        static IEnumerable<DomTypes.Association> StoreAssociations(SqlDomTypeDescriptor descriptor)
            => from a in descriptor.Associations
               select a.ToRecord();

        static IEnumerable<DomTypes.Collection> StoreCollections(SqlDomTypeDescriptor descriptor)
            => from a in descriptor.Collections
               select a.ToRecord();

        static IEnumerable<DomTypes.EnumLiteral> StoreEnumLiterals(SqlDomTypeDescriptor descriptor)
            => from l in descriptor.EnumLiterals
               select new DomTypes.EnumLiteral
               (
                   EnumName: descriptor.ElementName, 
                   LiteralName: l.LiteralName,
                   LiteralValue: l.LiteralValue                     
               );

        static DomTypes.Element StoreElement(SqlDomTypeDescriptor descriptor)
            => new DomTypes.Element
                (
                    ElementName: descriptor.ElementName,
                    ParentName: descriptor.ParentName,
                    IsAbstract: not(descriptor.IsConcrete),
                    ElementType: descriptor.DomElementKind.Identifier()
                );

        Option<int> Exec<P>(P proc)
            where P : class, ISqlProcedureProxy, new()
            => SqlStoreBroker.Call(proc);

        public Option<int> SaveXmlSyntax(IEnumerable<SqlXmlSyntaxFormat> syntax)
        {
            var records = map(syntax, s =>
                          new DomTypes.ScriptXml
                          (
                              ScriptName: s.SourceScript.ScriptName,
                              SourceText: s.SourceScript,
                              XmlFormat: s.XmlSyntax

                          ));

            return Exec(new DomStore.LoadScriptXml(records));
        }

        public Option<int> LoadMetamodel()
           => from types in some(rolist(DomTypes))
              let elements = map(types, StoreElement)
              let literals = rolist(from e in EnumTypes
                                  from l in StoreEnumLiterals(e)
                                  select l)
              let collections = rolist(from t in DomTypes
                                     from c in StoreCollections(t)
                                     select c)
              let attributes = rolist(from t in DomTypes
                                    from a in StoreAttributes(t)
                                    select a)
              let associations = rolist(from t in DomTypes
                                      from a in StoreAssociations(t)
                                      select a)
              from e in Exec(new DomStore.SyncElements(elements))
              from dt in Exec(new DomStore.SyncDataTypes())
              from l in Exec(new DomStore.SyncEnumLiterals(literals))
              from c in Exec(new DomStore.SyncCollections(collections))
              from a in Exec(new DomStore.SyncAttributes(attributes))
              from o in Exec(new DomStore.SyncAssociations(associations))
              select e + l + c + a + o;
    }
}