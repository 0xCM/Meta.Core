//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Tool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using static xmlfunc;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.CSharp;
    using SqlT.Syntax;
    using SqlT.Services;
    using SqlT.SqlDocs;
    using SqlT.Dom;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    using Meta.Core;

    using static SqlT.Models.SqlModelBuilders;

    using T = SqlT.Types.MC;
    using S = SqlT.SqlStore.MC;

    class AppSession : NodeSession<AppSession>
    {

        ReadOnlyList<Option<SqlScript>> GetPatternScripts()
            => ClrAssembly.ExecutingAssembly.DefiningAreaLocation.MapRequired(area =>
            {
                var scriptFolder = area.GetCombinedFolderPath("src\\SqlT.Schemas.Test\\Patterns");
                var wf = from scriptFile in scriptFolder.Files(CommonFileExtensions.Sql, true)
                         let script = SqlScript.FromFile(scriptFile)
                         select script;
                return wf.ToReadOnlyList();                                                        
            });



        public AppSession(INodeContext C)
            : base(C)
        {
            //var results = map(TestWorkflows, 
            //    wf => wf.Evaluate());
            var results = C.WorkflowExecution().ExecuteWorkflows(GetType().Assembly).ToList();           
        }
      
        ISqlFieldListGenerator FieldListGenerator
            => C.CSharpFieldListGenerator();

        ISqlDocs SqlDocs
            => C.SqlDocs();

        ISqlDocStore SqlDocsStore
            => C.SqlDocStore();

        SqlProcedure BuildMergeProcedure(SqlProcedureName Name, Type SourceType, Type TargetType, ClrPropertyName MatchColumn, bool Sync)
            => ~ from p in Procedure(Name)
               from m in Merge(SourceType, TargetType, true, Sync)
               from x in m.Map(MatchColumn,MatchColumn, true)
               let merge = m.Complete()
               let recordType = PXM.TableTypeName(SourceType).Reference()
               from s in p.WithStatements(merge)
               from args in p.WithParameters(new SqlRoutineParameter("Records", recordType, true))
               select p;

        static ISqlProxyBroker SqlStoreBroker
            => SqlTStoreProxies.Assembly.ProxyBroker(SqlConnectionString.Build().LocalConnection("SqlT").UsingIntegratedSecurity());

        IEnumerable<T.CoreDataTypeInfo> GetCoreDataTypes()
             => from src in new CoreDataTypes()
                select new T.CoreDataTypeInfo
                    (
                        DataTypeName: src.DataTypeName,
                        ClrTypeName: src.ClrType.Name,
                        IsInteger: src.IsInteger,
                        IsBoolean: src.IsBoolean,
                        CanSpecifyPrecision: src.CanSpecifyPrecision,
                        CanSpecifyLength: src.CanSpecifyLength,
                        CanSpecifyScale: src.CanSpecifyScale,
                        IsTemporal: src.IsTemporal,
                        IsText: src.IsText
                    );

        ISqlDomServices DomServices
            => C.SqlDomServices();

        ISqlMetamodelServices MetaModelServices
            => C.SqlMetamodelSevices();

        ISqlDomRepository DomRepository
            => C.SqlDomRepository();

        ISqlDomReader DomReader
            => C.SqlDomReader();

        ISqlDocsNavigator SqlDocsNavigator
            => C.NodeContext(Host).SqlDocsNavigator();

        ISqlParser SqlParser
            => C.SqlParser();

        Option<int> LoadMetaCore(IApplicationContext C)
            => SqlStoreBroker.Call(new S.SyncCoreDataTypes(GetCoreDataTypes()));

        public void listgen(string profile)
        {
            C.GenerateCode(profile).OnNone(Notify);
        }


        static string assign(SqlDomAttributeValue a)
            => $"{a.Member.MemberName}={squote(toString(a.SourceValue))}";
               
        IEnumerable<string> Traverse(SqlDomElementValue DomElement, int level)
        {
            switch(DomElement)
            {

                case SqlDomIdentifierValue x:
                    yield return tabs(level, tag(x.Member.MemberName, string.Join(".", x.Components)));
                    break;

                case SqlDomAssociationValue x:
                    var attributes = array(x.MemberValues.OfType<SqlDomAttributeValue>()
                                .Where(a => isNotNull(a.SourceValue)).Select(a => assign(a)));
                    yield return tabs(level,$"<{x.Member.ElementName} {spaced(attributes)}>");

                    foreach (var member in x.MemberValues.Where(z => not(z is SqlDomAttributeValue)))
                        foreach (var y in Traverse(member, level + 1))
                            yield return y;


                    yield return tabs(level, $"</{x.Member.ElementName}>");
                    break;


                case SqlDomCollectionValue x:
                    var _attributes = array(x.Items.OfType<SqlDomAttributeValue>()
                        .Where(a => isNotNull(a.SourceValue)).Select(a => assign(a)));
                    yield return tabs(level, $"<{x.Member.ElementName} {spaced(_attributes)}>");

                   
                    foreach (var member in x.Items.Where(z => not(z is SqlDomAttributeValue)))
                    {                       
                        //foreach (var y in Traverse(member, level + 1))
                        //    yield return y;
                    }

                    yield return tabs(level, $"</{x.Member.ElementName}>");
                    break;
            }
        }


        public void savedom()
        {
            DomRepository.LoadMetamodel()
                    .OnNone(Notify)
                    .OnSome(_ => Notify(inform($"Persisted metamodel")));

        }


        void test()
        {
            var testFile1 = FilePath.Parse(@"C:\Dev\Areas\OSS\ms\ms.sql-docs\docs\t-sql\language-elements\bitwise-and-equals-transact-sql.md");
            var testFile2 = FilePath.Parse(@"C:\Dev\Areas\OSS\ms\ms.sql-docs\docs\t-sql\lesson-1-5-summary-creating-database-objects.md");
            var testDoc = SqlDocs.ParseDocument(testFile2);
        }

        Option<int> SyncSqlDocs(IEnumerable<SqlMarkdownDocument> documents)
            => from x1 in SqlDocsStore.SyncDescriptions(documents)
               from x2 in SqlDocsStore.SyncTables(documents)
               from x3 in SqlDocsStore.SyncSyntaxBlocks(documents)
               from x4 in SqlDocsStore.SyncHeadings(documents)
               from x5 in SqlDocsStore.SyncHelpKeywords(documents)
               select x1 + x2 + x3 + x4;

        void AbsorbMarkdown()
        {
            var docs = SqlDocsNavigator.MarkdownDocuments.ToList();
            Notify(inform($"Parsing {docs.Count} documents"));
            var documents = rolist(from x in map(docs, doc => SqlDocs.ParseDocument(doc))
                                 where x.IsSome()
                                 select x.ValueOrDefault());

            Notify(inform($"Saving {documents.Count} documents"));

            SyncSqlDocs(documents).OnNone(Notify);

            //SqlDocsStore.SyncDocumentContent(documents);

            Notify(inform($"Completed save operation"));

        }

        //t-sql/functions/serverproperty-transact-sql;
        public void sqldocs()
        {


            SqlDocsStore.SyncSampleScripts().OnNone(Notify).OnSome(_ => Notify(inform("Saved sample scripts")));
            

        }



        public void gendom()
        {

            var script = SqlScript.Create(SqlTDomServices.Resources.FindTextResource("DescribeDataTypes.sql"));
            var parsed = SqlParser.ParseAny(script).Map(x => x as TSql.TSqlFragment).OnNone(Notify).Require();
            var root = DomReader.DomRoot(parsed);
            var element = DomReader.Deconstruct(parsed).Single();
            var text = string.Join(eol(), Traverse(element, 0));
            var outpath = CommonFolders.DevTemp + FileName.Parse("DescribeDataTypes.xml");
            outpath.Write(text);

        }

        protected XsdInfo Print(XsdInfo xsd)
        {

            if (xsd.IsValid)
                Notify(inform($"{xsd.XsdFile.Require().FileName}: {xsd.TargetNamespace}"));
            else
                Notify(warn($"{xsd.XsdFile} was not successfully processed"));

            return xsd;
        }


        public void xsd()
        {

            var documents = list(from file in C.NFS().Assets().XsdSchemas()
                        let xsd = XsdInfo.FromFile(file)
                        let name = ifBlank(xsd.TargetNamespace, file.AbsolutePath)                        
                        select new T.XsdDocument
                        (
                            SourcePath: file.AbsolutePath,
                            DocumentName: name,
                            Processed: xsd.IsValid,
                            ProcessingError: xsd.ErrorMessage.MapValueOrDefault(e => left(e.Format(false),500)),
                            XmlContent: xsd.XsdText
                        ));

            iter(documents, doc => QueueBroker.Publish(doc));

            SqlStoreBroker.Call(new S.StoreXsdDocuments(documents)).ToOption()
                    .OnNone(Notify)
                    .OnSome(_ => Notify(inform($"Saved {documents.Count} XSD documents")));

                
        }


        IQueueBroker QueueBroker
            => C.NodeContext(Host).QueueBroker();


        public void broker()
        {
            QueueBroker.Subscribe(typeof(T.XsdDocument), message => Print(cast<T.XsdDocument>(message).DocumentName));


        }

        IEnumerable<SqlScript> TestCases
            => from res in SqlTShell.Assembly.GetResourceProvider().TextResources(".sql")
               select SqlScript.Create(res.Name, res.Text);


        ISqlXmlSyntaxFormatter XmlSyntaxFormatter
            => C.SqlXmlSyntaxFormatter();


        public IEnumerable<Option<SqlXmlSyntaxFormat>> ParseXmlSyntax(IEnumerable<SqlScript> scripts)
            => from s in scripts
               select XmlSyntaxFormatter.FormatXmlSyntax(s);


        Option<FilePath> EmitSqlXmlSyntax(SqlScript script)
            => from syntax in XmlSyntaxFormatter.FormatXmlSyntax(script)
               let syntaxFile = syntax.SourceScript.SourceFile.MapRequired(f => f.ChangeExtension(CommonFileExtensions.Xml))
               from syntaxOut in syntaxFile.Write(syntax.XmlSyntax).ToFileOption()
               select syntaxOut;


        public void proxygen()
        {
            var profile = CommonFolders.DevAreaRoot.GetCombinedFolderPath("metacore\\src\\SqlT.Proxies.Z0") + FileName.Parse("Z0.sqlt");
            C.GenerateCode(profile).OnNone(Notify);
        }
        public void syntax()
        {

            iter(GetPatternScripts(),
                script => script.OnNone(Notify).OnSome(
                    s => EmitSqlXmlSyntax(s)
                            .OnNone(Notify)
                            .OnSome(dst => Notify(inform($"Emitted SqlXml syntax to {dst}"))
                            )));
         
            //var tableName = SqlTableName.Parse("[A].[MyTable]");
            //var indexName = SqlIndexName.Parse("IX_MyTable");
            //var propname = "IsDisabled";
            //var sql2 = $"select indexproperty({squote(tableName)},{squote(indexName)},{squote(propname)})";
            //var sx2 = XmlSyntaxFormatter.FormatXmlSyntax(sql2);
            //var sql3 = "select top(50) x.A, x.B, x.C from [X].[Y] x";
            //var sx3 = XmlSyntaxFormatter.FormatXmlSyntax(sql3);            
            //var uc1 = uc.uc_indexproperty.get_index_property(tableName, "IX_MyTable", "some_idx_property");
            //var uc2 = uc.uc_object_id.get_object_id(tableName);
            //var sql = uc1.FormatSyntax();
            //var dom = SqlParser.ParseAny(SqlScript.Create($"select {sql}")).OnNone(Notify);

            
        }
    }

}