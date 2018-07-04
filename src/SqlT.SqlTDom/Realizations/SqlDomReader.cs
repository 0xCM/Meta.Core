//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Services;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    class SqlDomReader : ApplicationService<SqlDomReader, ISqlDomReader>, ISqlDomReader
    {
        
        SqlDomMetamodel Metamodel { get; }

        public SqlDomReader(IApplicationContext C)
            : base(C)
        {
            Metamodel = C.SqlMetamodelSevices().DomMetamodel;
        }

        static string domName(TSql.TSqlFragment tSql)
            => tSql.GetType().Name;


        public SqlDomRoot DomRoot(TSql.TSqlFragment tSql)            
            => new SqlDomRoot(Metamodel.DomType(
                    domName(tSql)), 
                    AttributeValues(tSql), 
                    AssociationValues(tSql), 
                    CollectionValues(tSql), 
                    tSql
                );

        public IEnumerable<SqlDomAttributeValue> AttributeValues(TSql.TSqlFragment tSql, SqlDomElementValue parent = null)
            => from a in Metamodel.Attributes(domName(tSql))
               where not(a.SupportsInfrastructure)
               let value = a.DefiningProperty.GetValue(tSql)
               where isNotNull(value)
               select new SqlDomAttributeValue(a, value, parent);

        public IEnumerable<SqlDomAssociationValue> AssociationValues(TSql.TSqlFragment tSql, SqlDomElementValue parent = null)
            => from a in Metamodel.Associations(domName(tSql))
                let value = a.DefiningProperty.GetValue(tSql)
                where isNotNull(value)
               select new SqlDomAssociationValue(a,value, parent);

        public IEnumerable<SqlDomCollectionValue> CollectionValues(TSql.TSqlFragment tSql, SqlDomElementValue parent = null)
            => from c in Metamodel.Collections(domName(tSql))
               let cValue = c.DefiningProperty.GetValue(tSql) as IEnumerable
               where isNotNull(cValue)
               let items = rolist(cValue.Cast<TSql.TSqlFragment>())
               select new SqlDomCollectionValue(c, cValue, items, parent);
               

        SqlDomIdentifierValue IdentifierValue(SqlDomElementMember member, TSql.MultiPartIdentifier tSql, SqlDomElementValue parent = null)
            => new SqlDomIdentifierValue(member, tSql, parent,
                from part in tSql.Identifiers
                select new SqlDomIdentifierComponent(part.Value, part.QuoteType != TSql.QuoteType.NotQuoted));

        SqlDomIdentifierValue IdentifierValue(SqlDomElementMember member, TSql.Identifier tSql, SqlDomElementValue parent = null)
            => new SqlDomIdentifierValue(member, tSql, parent, 
                    stream(new SqlDomIdentifierComponent(tSql.Value, tSql.QuoteType != TSql.QuoteType.NotQuoted)));

        IEnumerable<SqlDomElementValue> GetValues(SqlDomAssociationValue a)
        {
            if (a.SourceValue is TSql.MultiPartIdentifier)
                yield return IdentifierValue(a.Member, a.SourceValue as TSql.MultiPartIdentifier, a);
            else if (a.SourceValue is TSql.Identifier)
                yield return IdentifierValue(a.Member, a.SourceValue as TSql.Identifier, a);
            else if (a.SourceValue is TSql.TSqlFragment)
                foreach (var deconstruction in Deconstruct(a.SourceValue as TSql.TSqlFragment, a))
                    yield return deconstruction;
        }

        public IEnumerable<SqlDomElementValue> Deconstruct(TSql.TSqlFragment tSql, SqlDomElementValue parent = null)
        {            
            foreach (var a in AttributeValues(tSql,parent))
                yield return a;

            foreach(var a in AssociationValues(tSql,parent))
                yield return a.WithMemberValues(GetValues(a));

            foreach (var c in CollectionValues(tSql, parent))
            {
                foreach (var item in c.ItemSource)
                {
                    var items = new List<SqlDomElementValue>(Deconstruct(item as TSql.TSqlFragment, c));
                    if (items.Count != 0)
                        yield return c.WithItems(items);
                }
            }
        }
    }

}