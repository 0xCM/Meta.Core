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
    using SqlT.Language;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    using SqlD = SqlScriptDescription;

    class SqlAnalyzer : ApplicationService<SqlAnalyzer, ISqlAnalyzer>, ISqlAnalyzer
    {
        ISqlMetamodelServices Bridge { get; }

        public SqlAnalyzer(IApplicationContext C)
            : base(C)
        {
            this.Bridge = C.Service<ISqlMetamodelServices>();
        }

        SqlDomTypeCorrelation Correlate(TSql.TSqlFragment src)
            => Bridge.Correlate(src).ValueOrDefault();

        SqlD Describe(TSql.NamedTableReference src)
            => new SqlD(src,Correlate(src));
    
        SqlD Describe(TSql.UpdateSpecification src)
            => new SqlD(src, Correlate(src));

        SqlD Describe(TSql.UpdateStatement src)
            => new SqlD(src, Correlate(src));

        SqlD Describe(TSql.TSqlFragment src)
            => new SqlD(src, Correlate(src));

        SqlD DescribeAny(dynamic tSql)
            => Describe(tSql);            

        public Option<SqlScriptAnalysis> AnalyzeScript(SqlScript sql)
        {
            var descriptions = new List<SqlD>();
            TSqlParser.NativeParser().ParseAny(sql.ScriptText)
                                     .Accept(new SignatureVisitor(tSql =>  descriptions.Add(DescribeAny(tSql))));
            return new SqlScriptAnalysis(sql);
        }
    }
}