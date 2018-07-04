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
    using SqlT.SqlTDom;
    using SqlT.Services;
    using SqlT.Types.SqlDom;

    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;



    class SqlMetamodelServices : ApplicationService<SqlMetamodelServices, ISqlMetamodelServices>, ISqlMetamodelServices
    {
        static IReadOnlyDictionary<string, ClrType> SqlTModelIndex { get; }

        static SqlDomTypeDescriptors TypeDescriptors { get; }

        static SqlDomTypeCorrelations Correlations { get; }

        static ClrAssembly TSqlDomAssembly
            => typeof(TSql.TSqlParser).Assembly;

        static SqlDomTypeDescriptors CreateTypeDescriptors()
            => SqlDomTypeDescriptors.FromAssembly(TSqlDomAssembly); 


        static IEnumerable<ClrType> SqlTModelElementTypes
            => from t in SqlTDomServices.ClrAssembly.NamedPublicTypes
               where t.ReflectedElement.Realizes<ISqlTDomElement>()
                && not(t.IsInterfaceType)
               select t;

        static IEnumerable<ClrType> SqlTModelEnumTypes
            => from t in SqlTDomServices.ClrAssembly.NamedPublicTypes               
               where t.IsEnumType && t.IsDeclaredIn("SqlT.SqlTDom")
               select t;

        static IReadOnlyDictionary<string, ClrType> IndexSqlTModelElements()
        {

            var assembly = SqlTDomServices.ClrAssembly;
            var sqltTypes = assembly.NamedPublicTypes;
            var sqltModelElements = from t in sqltTypes
                                    where t.ReflectedElement.Realizes<ISqlTDomElement>()
                                     && not(t.IsInterfaceType)
                                    select t;
            return (map(sqltModelElements, e => (e.Name, e))).ToReadOnlyDictionary();

        }

        static IReadOnlyDictionary<string, ClrType> IndexTSqlElements()
        {
            var tsqlTypes = TSqlDomAssembly.NamedPublicTypes;
            var tsqlElements = (map(tsqlTypes, t => (t.Name, t))).ToReadOnlyDictionary();
            return tsqlElements;
        }

        static SqlDomTypeCorrelations CorrelateModel()
        {
            var tsqlElements = IndexTSqlElements();
            var correlations = from sqlT in SqlTModelIndex.Where(t => not(t.Value.IsEnumType))
                               from tSql in tsqlElements
                               where sqlT.Key == tSql.Key
                               select new SqlDomTypeCorrelation(tSql.Value, sqlT.Value);
            return SqlDomTypeCorrelations.Create(correlations.ToArray());
        }


        static SqlMetamodelServices()
        {
            SqlTModelIndex = union(SqlTModelEnumTypes, SqlTModelElementTypes).ToDictionary(x => x.Name);
            TypeDescriptors = CreateTypeDescriptors();
            Correlations = CorrelateModel();

        }


        public SqlMetamodelServices(IApplicationContext C)
            : base(C)
        {
            DomMetamodel = new SqlDomMetamodel(TypeDescriptors);
        }


        public SqlDomMetamodel DomMetamodel { get; }
          

        public SqlDomTypeDescriptors DescribeDomTypes()
            => TypeDescriptors;

        public SqlDomTypeCorrelations GetTypeCorrelations()
            => Correlations;

        public IEnumerable<ClrType> GetSqlTModelTypes()
            => SqlTModelIndex.Values;

        public Option<SqlDomTypeCorrelation> Correlate(object instance)        
            => Correlations.TryFind(instance.GetType().Name);        


    }
}
