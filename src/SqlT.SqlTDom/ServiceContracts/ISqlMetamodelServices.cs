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

    using static metacore;

    

    public interface ISqlMetamodelServices
    {
        SqlDomTypeCorrelations GetTypeCorrelations();

        SqlDomTypeDescriptors DescribeDomTypes();

        SqlDomMetamodel DomMetamodel { get; }


        Option<SqlDomTypeCorrelation> Correlate(object instance);

        IEnumerable<ClrType> GetSqlTModelTypes();
    }




}