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

    using Meta.Core;
    using Meta.Core.Project;

    using SqlT.Core;
    using SqlT.Models;    
    using SqlT.CSharp;
    using SqlT.Services;
    

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    using static SqlT.Dom.SqlSyntaxFormatter;

    class SqlDomServices : ApplicationService<SqlDomServices, ISqlDomServices>, ISqlDomServices
    {

        public SqlDomServices(IApplicationContext C)
            : base(C)
        {
            
        }

        static readonly (string, object) ScenarioLib 
            = (nameof(ScenarioLib), @"$(DevTempDir)");

        static ClrAssembly TSqlAssembly
            => typeof(TSql.TSqlFragment).Assembly;

        static ClrAssembly SqlTAssembly
            => typeof(SqlTDom.TSqlFragment).Assembly;

        static Option<ClrNamespaceName> SqlTDomNamespace
            => ClrClass.Get<SqlTDom.TSqlFragment>().Namespace;

        static ReadOnlyList<ClrTypeLineage> DeriveLineage<T>(IEnumerable<ClrClass> classPool)
            => map(
                from c in classPool
                where not(c.IsAbstract) && c.IsSublcassOf<T>()
                select c, c => c.TypeLineage
                );

        ISqlMetamodelServices MetaServices
            => C.Service<ISqlMetamodelServices>();

        ISqlXmlSyntaxFormatter XmlSyntaxFormatter
            => C.SqlXmlSyntaxFormatter();

        public Option<SqlTDomInfo> DescribeSqlTDom()
        {
            var sourceTypes = MetaServices.DescribeDomTypes();

            var allInterfaces = SqlTAssembly.PublicInterfaces;
            var allStructs = SqlTAssembly.PublicStructs;
            var enums = SqlTAssembly.PublicEnums;
            var allClasses = SqlTAssembly.PublicClasses.Where(t => t.Namespace == SqlTDomNamespace).AsList();
            var literals = DeriveLineage<TSql.Literal>(allClasses.Stream());
            var statements = DeriveLineage<TSql.TSqlStatement>(allClasses.Stream());
            return new SqlTDomInfo(sourceTypes, allClasses, statements, literals, enums);
        }

        public Option<CSharpProject> SpecifySqlTDomProject(SqlTDomInfo sqlT, ProjectEmissionOptions options)
            => C.SqlTDomProjectSpecifier().SpecifyTSqlDomProject(sqlT, options);


        public Option<FilePath> GenerateSqlTDom(FolderPath targetFolder)
            => from model in DescribeSqlTDom()
               let options = new ProjectEmissionOptions{ProjectRootLocation = targetFolder}
               from project in SpecifySqlTDomProject(model, options)
               from projectFile in C.CSharpProjectGenerator().GenerateProject(project, options)
               select projectFile;


        (SqlScript src, SqlSyntaxSignatures dst) CalcSignatures(SqlScript src)
            => (src, src.CalcSignatures());

        static IEnumerable<SqlScript> CollectSqlScripts(FolderTree parent)
        {
            foreach (var file in parent.ListFiles("*.sql"))
            {
                yield return ~ SqlScript.FromFile(file);
                foreach (var child in parent.Dive())
                    foreach (var subfile in child.Content.GetFiles(".sql"))
                        yield return ~ SqlScript.FromFile(subfile);
            }
        }

        void CharacterizeStatemnt()
        {


        }

        static IApplicationMessage EmittedSignatures(FilePath dstPath)
            => ApplicationMessage.Inform("Signatures emitted to @dstPath", new
            {
                dstPath
            });

        const string ResMarker = @"res:\\";

        Option<TextResource> TryFindTextResource(string resid)
            => SqlTDomServices.Resources.TryFindTextResource(resid);

        static string GetResId(string path)
            => path.Replace(ResMarker, string.Empty);

        Option<SqlScript> LookupScript(string path)
            => path.StartsWith(ResMarker)
            ? TryFindTextResource(GetResId(path))
                .MapValueOrDefault(x => new SqlScript(GetResId(path), x.Text))
            : SqlScript.FromFile(path, null);

        Option<FilePath> EmitScriptSignaturesWorkflow(SqlScript script, FolderPath dstFolder)
              => from s in some(script)
                 let sigs = script.CalcSignatures()
                 let scriptFileName = FileName.Parse(script.ScriptName)
                 let srcCopy = dstFolder + scriptFileName
                 let dstFileName = scriptFileName.AddExtension("txt")
                 let dstFile = dstFolder + dstFileName
                 from result in dstFile.Write(SyntaxFileHeader() + sigs.ToString()).ToOption()
                 select dstFile;


        Option<FilePath> EmitFileSignaturesWorkflow(FilePath srcFile, FolderPath dstFolder)
              => from script in LookupScript(srcFile)
                 let sigs = script.CalcSignatures()
                 let srcCopy = dstFolder + srcFile.FileName
                 let dstFileName = srcFile.FileName.AddExtension("txt")
                 let dstFile = dstFolder + dstFileName
                 from result in dstFile.Write(SyntaxFileHeader() + sigs.ToString()).ToOption()
                 select dstFile;

        public Option<FilePath> EmitFunctionFactory(FilePath dstFile)
        {
            var f = new SqlTDomFunc(C);
            var sigs = f.SpecifySignatures().ToList();
            var contract = f.SpecifyMasterContract();
            var code = contract.GenerateCode
                (
                    SqlTDomProjectSpecifier.TopNamespace, 
                    dstFile, 
                    SqlTDomProjectSpecifier.Usings.ToArray()
                );
            return dstFile;
        }
        


        public IEnumerable<ClrClass> DescribeConcreteElements()
            => DescribeSqlTDom().OnNone(Notify).Require().ConcreteTypes.OrderBy(x => x.Name);


        public Option<FilePath> EmitFileSignatures(FilePath srcFile, FolderPath dstFolder)
        {
            var wf = EmitFileSignaturesWorkflow(srcFile, dstFolder);
            if (wf)
                return wf.WithMessage(EmittedSignatures(wf.ValueOrDefault()));
            else
                return wf;
        }

        public Option<CorrelationToken> AnalyzeCannedScenario(string scenarioName, FolderPath dstFolder)
        {
            var analyzer = C.Service<ISqlAnalyzer>();
            var analysis = from res in SqlTDomServices.Resources.TryFindTextResource(scenarioName)
                         let sql = new SqlScript(res.Name, res.Text)
                         from a in analyzer.AnalyzeScript(sql)
                         select a;
            return analysis.MapValueOrDefault(_ => CorrelationToken.Create());
        }

        public Option<int> AnalyzeCannedScenarios(FolderPath dstFolder)
        {
            var scripts = map(SqlTDomServices.Resources.TextResources(".sql"),
                res => new SqlScript(res.Name, res.Text));
            foreach(var script in scripts)
            {

                EmitScriptSignaturesWorkflow(script, dstFolder)
                    .OnSome(dstFile => Notify(EmittedSignatures(dstFile)))
                    .OnNone(Notify);
            }
            
            return 0;
        }

        public Option<ReadOnlyList<ClrType>> GetSqlTModelTypes()
            => C.SqlMetamodelSevices().GetSqlTModelTypes().ToReadOnlyList();

        public Option<SqlDomTypeCorrelations> GetTypeCorrelations()
            => C.SqlMetamodelSevices().GetTypeCorrelations();

        public Option<FilePath> SaveXmlSyntaxFile(SqlScript srcScript, FolderPath dstFolder)
            => from x in XmlSyntaxFormatter.FormatXmlSyntax(srcScript)
               let scriptFileName = FileName.Parse(srcScript.ScriptName)
               let srcCopy = dstFolder + scriptFileName
               let dstFileName = scriptFileName.AddExtension("xml")
               let dstFile = dstFolder + dstFileName
               select dstFile.Write(x.XmlSyntax).DstPath;

        public Option<FilePath> SaveXmlSyntaxFile(FilePath srcFile, FolderPath dstFolder)
            => from srcScript in LookupScript(srcFile)
               from saved in SaveXmlSyntaxFile(srcScript, dstFolder)
               select saved;

        public Option<int> SaveXmlSyntaxFiles(FolderPath srcFolder, FolderPath dstFolder = null)
        {
            var root = srcFolder.Resolve(ScenarioLib);
            var srcTree = new FolderTree(root);
            var scripts = list(CollectSqlScripts(srcTree));
            var outputFolder = ifNull(dstFolder,
                () => srcTree.AbsoluteLocation + FolderName.Parse("signatures"));

            int count = 0;

            iter(scripts, script =>
                SaveXmlSyntaxFile(script, outputFolder)
                        .OnSome(_ => count++)
                        .OnNone(Notify));

            return count;

        }

    }



}
