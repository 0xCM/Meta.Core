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

    using SqlT.Types.SqlDom;

    using static metacore;


    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public class SqlDomMetamodel
    {
        IReadOnlyDictionary<string, SqlDomTypeDescriptor> TypeIndex { get; }


        public SqlDomMetamodel(IEnumerable<SqlDomTypeDescriptor> DomTypes)
        {
            TypeIndex = DomTypes.ToDictionary(x => x.SqlDomType.Name);
        }

        public IEnumerable<SqlDomAttribute> Attributes(string ElementName)
            => TypeIndex.TryFind(ElementName).MapValueOrDefault(x => x.Attributes, stream<SqlDomAttribute>());

        public IEnumerable<SqlDomAssociation> Associations(string ElementName)
            => TypeIndex.TryFind(ElementName).MapValueOrDefault(x => x.Associations, stream<SqlDomAssociation>());

        public IEnumerable<SqlDomCollection> Collections(string ElementName)
            => TypeIndex.TryFind(ElementName).MapValueOrDefault(x => x.Collections, stream<SqlDomCollection>());


        public SqlDomMetamodelViews Views
            => new SqlDomMetamodelViews(TypeIndex.Values);

        public SqlDomTypeDescriptor DomType(string ElementName)
            => TypeIndex[ElementName];

            

    }


}