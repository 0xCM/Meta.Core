//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;


    public interface ISqlDomServices
    {
        Option<FilePath> GenerateSqlTDom(FolderPath dstFolder);


        Option<FilePath> EmitFileSignatures(FilePath srcFile, FolderPath dstFolder);

        Option<FilePath> EmitFunctionFactory(FilePath dstFile);

        Option<FilePath> SaveXmlSyntaxFile(FilePath srcFile, FolderPath dstFolder);

        Option<int> AnalyzeCannedScenarios(FolderPath dstFolder);

        Option<CorrelationToken> AnalyzeCannedScenario(string scenarioName, FolderPath dstFolder);

        IEnumerable<ClrClass> DescribeConcreteElements();

        Option<SqlDomTypeCorrelations> GetTypeCorrelations();

        Option<SqlTDomInfo> DescribeSqlTDom();

        Option<ReadOnlyList<ClrType>> GetSqlTModelTypes();
    }
}
