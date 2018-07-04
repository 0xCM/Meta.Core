//This file was generated at 5/27/2018 10:01:17 AM using version 1.2018.3.11161 the SqT data access toolset.
namespace SqlT.SqlDocs.Proxies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SqlDocsTableTypeNames
    {
        public readonly static SqlTableTypeName Configuration = "[SqlDocs].[Configuration]";
        public readonly static SqlTableTypeName MarkdownFileContent = "[SqlDocs].[MarkdownFileContent]";
        public readonly static SqlTableTypeName MarkdownFileInfo = "[SqlDocs].[MarkdownFileInfo]";
        public readonly static SqlTableTypeName MarkdownHelpKeyword = "[SqlDocs].[MarkdownHelpKeyword]";
        public readonly static SqlTableTypeName MarkdownTableInfo = "[SqlDocs].[MarkdownTableInfo]";
        public readonly static SqlTableTypeName MarkdownTableRow = "[SqlDocs].[MarkdownTableRow]";
        public readonly static SqlTableTypeName SqlSyntaxBlock = "[SqlDocs].[SqlSyntaxBlock]";
        public readonly static SqlTableTypeName TextFileDescription = "[SqlDocs].[TextFileDescription]";
    }

    public sealed class SqlDocsViewNames
    {
        public readonly static SqlViewName DocumentTableIdentity = "[SqlDocs].[DocumentTableIdentity]";
    }

    public sealed class SqlDocsProcedureNames
    {
        public readonly static SqlProcedureName SyncMarkdownFileContent = "[SqlDocs].[SyncMarkdownFileContent]";
        public readonly static SqlProcedureName SyncMarkdownFiles = "[SqlDocs].[SyncMarkdownFiles]";
        public readonly static SqlProcedureName SyncMarkdownHelpKeywords = "[SqlDocs].[SyncMarkdownHelpKeywords]";
        public readonly static SqlProcedureName SyncMarkdownTables = "[SqlDocs].[SyncMarkdownTables]";
        public readonly static SqlProcedureName SyncSampleScripts = "[SqlDocs].[SyncSampleScripts]";
        public readonly static SqlProcedureName SyncSyntaxBlocks = "[SqlDocs].[SyncSyntaxBlocks]";
    }

    public sealed class SqlDocsSequenceNames
    {
        public readonly static SqlSequenceName MarkdownFileContentSequence = "[SqlDocs].[MarkdownFileContentSequence]";
        public readonly static SqlSequenceName MarkdownFileSequence = "[SqlDocs].[MarkdownFileSequence]";
        public readonly static SqlSequenceName MarkdownHelpKeywordSequence = "[SqlDocs].[MarkdownHelpKeywordSequence]";
        public readonly static SqlSequenceName MarkdownTableRowSequence = "[SqlDocs].[MarkdownTableRowSequence]";
        public readonly static SqlSequenceName MarkdownTableSequence = "[SqlDocs].[MarkdownTableSequence]";
        public readonly static SqlSequenceName SampleScriptSequence = "[SqlDocs].[SampleScriptSequence]";
        public readonly static SqlSequenceName SqlSyntaxSequence = "[SqlDocs].[SqlSyntaxSequence]";
    }

    public sealed class SqlDocsTableFunctionNames
    {
        public readonly static SqlFunctionName Configurations = "[SqlDocs].[Configurations]";
        public readonly static SqlFunctionName DocumentKeywords = "[SqlDocs].[DocumentKeywords]";
        public readonly static SqlFunctionName DocumentTableRows = "[SqlDocs].[DocumentTableRows]";
        public readonly static SqlFunctionName MarkdownTableRows = "[SqlDocs].[MarkdownTableRows]";
    }

    [SqlTableFunction("SqlDocs", "Configurations")]
    public partial class Configurations : SqlTableFunctionProxy<Configurations, Configuration>
    {
        public Configurations()
        {
        }
    }

    [SqlTableFunctionResult("SqlDocs", "DocumentKeywords")]
    public partial class DocumentKeywordsResult : SqlTabularProxy
    {
        [SqlColumn("FileLocation", 0), SqlTypeFacets("nvarchar", false, 500)]
        public string FileLocation
        {
            get;
            set;
        }

        [SqlColumn("SegmentName", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("DocumentTitle", 2), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlColumn("Keyword", 3), SqlTypeFacets("nvarchar", false, 75)]
        public string Keyword
        {
            get;
            set;
        }

        public DocumentKeywordsResult()
        {
        }

        public DocumentKeywordsResult(object[] items)
        {
            FileLocation = (string)items[0];
            SegmentName = (string)items[1];
            DocumentTitle = (string)items[2];
            Keyword = (string)items[3];
        }

        public DocumentKeywordsResult(string FileLocation, string SegmentName, string DocumentTitle, string Keyword)
        {
            this.FileLocation = FileLocation;
            this.SegmentName = SegmentName;
            this.DocumentTitle = DocumentTitle;
            this.Keyword = Keyword;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FileLocation, SegmentName, DocumentTitle, Keyword };
        }
    }

    [SqlTableFunction("SqlDocs", "DocumentKeywords")]
    public partial class DocumentKeywords : SqlTableFunctionProxy<DocumentKeywords, DocumentKeywordsResult>
    {
        public DocumentKeywords()
        {
        }
    }

    [SqlTableFunction("SqlDocs", "MarkdownTableRows")]
    public partial class MarkdownTableRows : SqlTableFunctionProxy<MarkdownTableRows, MarkdownTableRow>
    {
        public MarkdownTableRows()
        {
        }
    }

    [SqlTableFunction("SqlDocs", "DocumentTableRows")]
    public partial class DocumentTableRows : SqlTableFunctionProxy<DocumentTableRows, MarkdownTableRow>
    {
        [SqlParameter("@DocumentTitle", 0, false, false), SqlTypeFacets("nvarchar", true, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlParameter("@TableNumber", 1, false, false), SqlTypeFacets("int", true)]
        public int? TableNumber
        {
            get;
            set;
        }

        [SqlParameter("@FirstRowNumber", 2, false, false), SqlTypeFacets("int", true)]
        public int? FirstRowNumber
        {
            get;
            set;
        }

        public DocumentTableRows()
        {
        }

        public DocumentTableRows(object[] items)
        {
            DocumentTitle = (string)items[0];
            TableNumber = (int?)items[1];
            FirstRowNumber = (int?)items[2];
        }

        public DocumentTableRows(string DocumentTitle, int? TableNumber, int? FirstRowNumber)
        {
            this.DocumentTitle = DocumentTitle;
            this.TableNumber = TableNumber;
            this.FirstRowNumber = FirstRowNumber;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DocumentTitle, TableNumber, FirstRowNumber };
        }
    }

    [SqlProcedure("SqlDocs", "SyncSampleScripts")]
    public partial class SyncSampleScripts : SqlProcedureProxy
    {
        [SqlParameter("@SegmentName", 0, false, false), SqlTypeFacets("nvarchar", true, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlParameter("@Scripts", 1, true, false), SqlTypeFacets("[SqlDocs].[TextFileDescription]", true)]
        public IEnumerable<TextFileDescription> Scripts
        {
            get;
            set;
        }

        public SyncSampleScripts()
        {
        }

        public SyncSampleScripts(object[] items)
        {
            SegmentName = (string)items[0];
            Scripts = (IEnumerable<TextFileDescription>)items[1];
        }

        public SyncSampleScripts(string SegmentName, IEnumerable<TextFileDescription> Scripts)
        {
            this.SegmentName = SegmentName;
            this.Scripts = Scripts;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, Scripts };
        }
    }

    [SqlProcedure("SqlDocs", "SyncMarkdownFileContent")]
    public partial class SyncMarkdownFileContent : SqlProcedureProxy
    {
        [SqlParameter("@SegmentName", 0, false, false), SqlTypeFacets("nvarchar", true, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlParameter("@Content", 1, true, false), SqlTypeFacets("[SqlDocs].[MarkdownFileContent]", true)]
        public IEnumerable<MarkdownFileContent> Content
        {
            get;
            set;
        }

        public SyncMarkdownFileContent()
        {
        }

        public SyncMarkdownFileContent(object[] items)
        {
            SegmentName = (string)items[0];
            Content = (IEnumerable<MarkdownFileContent>)items[1];
        }

        public SyncMarkdownFileContent(string SegmentName, IEnumerable<MarkdownFileContent> Content)
        {
            this.SegmentName = SegmentName;
            this.Content = Content;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, Content };
        }
    }

    [SqlProcedure("SqlDocs", "SyncMarkdownFiles")]
    public partial class SyncMarkdownFiles : SqlProcedureProxy
    {
        [SqlParameter("@SegmentName", 0, false, false), SqlTypeFacets("nvarchar", true, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlParameter("@Descriptions", 1, true, false), SqlTypeFacets("[SqlDocs].[MarkdownFileInfo]", true)]
        public IEnumerable<MarkdownFileInfo> Descriptions
        {
            get;
            set;
        }

        public SyncMarkdownFiles()
        {
        }

        public SyncMarkdownFiles(object[] items)
        {
            SegmentName = (string)items[0];
            Descriptions = (IEnumerable<MarkdownFileInfo>)items[1];
        }

        public SyncMarkdownFiles(string SegmentName, IEnumerable<MarkdownFileInfo> Descriptions)
        {
            this.SegmentName = SegmentName;
            this.Descriptions = Descriptions;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, Descriptions };
        }
    }

    [SqlProcedure("SqlDocs", "SyncMarkdownHelpKeywords")]
    public partial class SyncMarkdownHelpKeywords : SqlProcedureProxy
    {
        [SqlParameter("@Keywords", 0, true, false), SqlTypeFacets("[SqlDocs].[MarkdownHelpKeyword]", true)]
        public IEnumerable<MarkdownHelpKeyword> Keywords
        {
            get;
            set;
        }

        public SyncMarkdownHelpKeywords()
        {
        }

        public SyncMarkdownHelpKeywords(object[] items)
        {
            Keywords = (IEnumerable<MarkdownHelpKeyword>)items[0];
        }

        public SyncMarkdownHelpKeywords(IEnumerable<MarkdownHelpKeyword> Keywords)
        {
            this.Keywords = Keywords;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Keywords };
        }
    }

    [SqlProcedure("SqlDocs", "SyncMarkdownTables")]
    public partial class SyncMarkdownTables : SqlProcedureProxy
    {
        [SqlParameter("@Tables", 0, true, false), SqlTypeFacets("[SqlDocs].[MarkdownTableInfo]", true)]
        public IEnumerable<MarkdownTableInfo> Tables
        {
            get;
            set;
        }

        [SqlParameter("@Rows", 1, true, false), SqlTypeFacets("[SqlDocs].[MarkdownTableRow]", true)]
        public IEnumerable<MarkdownTableRow> Rows
        {
            get;
            set;
        }

        public SyncMarkdownTables()
        {
        }

        public SyncMarkdownTables(object[] items)
        {
            Tables = (IEnumerable<MarkdownTableInfo>)items[0];
            Rows = (IEnumerable<MarkdownTableRow>)items[1];
        }

        public SyncMarkdownTables(IEnumerable<MarkdownTableInfo> Tables, IEnumerable<MarkdownTableRow> Rows)
        {
            this.Tables = Tables;
            this.Rows = Rows;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Tables, Rows };
        }
    }

    [SqlProcedure("SqlDocs", "SyncSyntaxBlocks")]
    public partial class SyncSyntaxBlocks : SqlProcedureProxy
    {
        [SqlParameter("@Blocks", 0, true, false), SqlTypeFacets("[SqlDocs].[SqlSyntaxBlock]", true)]
        public IEnumerable<SqlSyntaxBlock> Blocks
        {
            get;
            set;
        }

        public SyncSyntaxBlocks()
        {
        }

        public SyncSyntaxBlocks(object[] items)
        {
            Blocks = (IEnumerable<SqlSyntaxBlock>)items[0];
        }

        public SyncSyntaxBlocks(IEnumerable<SqlSyntaxBlock> Blocks)
        {
            this.Blocks = Blocks;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Blocks };
        }
    }

    [SqlView("SqlDocs", "DocumentTableIdentity")]
    public partial class DocumentTableIdentity : SqlViewProxy
    {
        [SqlColumn("SegmentName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("DocumentTitle", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlColumn("TablePosition", 2), SqlTypeFacets("int", false)]
        public int TablePosition
        {
            get;
            set;
        }

        [SqlColumn("TableNumber", 3), SqlTypeFacets("bigint", true)]
        public long? TableNumber
        {
            get;
            set;
        }

        public DocumentTableIdentity()
        {
        }

        public DocumentTableIdentity(object[] items)
        {
            SegmentName = (string)items[0];
            DocumentTitle = (string)items[1];
            TablePosition = (int)items[2];
            TableNumber = (long?)items[3];
        }

        public DocumentTableIdentity(string SegmentName, string DocumentTitle, int TablePosition, long? TableNumber)
        {
            this.SegmentName = SegmentName;
            this.DocumentTitle = DocumentTitle;
            this.TablePosition = TablePosition;
            this.TableNumber = TableNumber;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, DocumentTitle, TablePosition, TableNumber };
        }
    }

    [SqlRecord("SqlDocs", "TextFileDescription")]
    public partial class TextFileDescription : SqlTableTypeProxy<TextFileDescription>
    {
        [SqlColumn("SegmentName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("SourcePath", 1), SqlTypeFacets("nvarchar", false, 500)]
        public string SourcePath
        {
            get;
            set;
        }

        [SqlColumn("ModifiedDate", 2), SqlTypeFacets("date", true)]
        public Date? ModifiedDate
        {
            get;
            set;
        }

        [SqlColumn("FileSize", 3), SqlTypeFacets("bigint", false)]
        public long FileSize
        {
            get;
            set;
        }

        [SqlColumn("FileContent", 4), SqlTypeFacets("nvarchar", false, 0)]
        public string FileContent
        {
            get;
            set;
        }

        public TextFileDescription()
        {
        }

        public TextFileDescription(object[] items)
        {
            SegmentName = (string)items[0];
            SourcePath = (string)items[1];
            ModifiedDate = (Date?)items[2];
            FileSize = (long)items[3];
            FileContent = (string)items[4];
        }

        public TextFileDescription(string SegmentName, string SourcePath, Date? ModifiedDate, long FileSize, string FileContent)
        {
            this.SegmentName = SegmentName;
            this.SourcePath = SourcePath;
            this.ModifiedDate = ModifiedDate;
            this.FileSize = FileSize;
            this.FileContent = FileContent;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, SourcePath, ModifiedDate, FileSize, FileContent };
        }
    }

    [SqlRecord("SqlDocs", "Configuration")]
    public partial class Configuration : SqlTableTypeProxy<Configuration>
    {
        [SqlColumn("ConfigurationName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string ConfigurationName
        {
            get;
            set;
        }

        [SqlColumn("RepositoryLocation", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string RepositoryLocation
        {
            get;
            set;
        }

        [SqlColumn("SelectedSections", 2), SqlTypeFacets("nvarchar", true, 250)]
        public string SelectedSections
        {
            get;
            set;
        }

        public Configuration()
        {
        }

        public Configuration(object[] items)
        {
            ConfigurationName = (string)items[0];
            RepositoryLocation = (string)items[1];
            SelectedSections = (string)items[2];
        }

        public Configuration(string ConfigurationName, string RepositoryLocation, string SelectedSections)
        {
            this.ConfigurationName = ConfigurationName;
            this.RepositoryLocation = RepositoryLocation;
            this.SelectedSections = SelectedSections;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ConfigurationName, RepositoryLocation, SelectedSections };
        }
    }

    [SqlRecord("SqlDocs", "MarkdownFileContent")]
    public partial class MarkdownFileContent : SqlTableTypeProxy<MarkdownFileContent>
    {
        [SqlColumn("SegmentName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("DocumentTitle", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlColumn("FileLocation", 2), SqlTypeFacets("nvarchar", false, 500)]
        public string FileLocation
        {
            get;
            set;
        }

        [SqlColumn("ModifiedDate", 3), SqlTypeFacets("date", true)]
        public Date? ModifiedDate
        {
            get;
            set;
        }

        [SqlColumn("FileSize", 4), SqlTypeFacets("bigint", false)]
        public long FileSize
        {
            get;
            set;
        }

        [SqlColumn("FileContent", 5), SqlTypeFacets("nvarchar", false, 0)]
        public string FileContent
        {
            get;
            set;
        }

        public MarkdownFileContent()
        {
        }

        public MarkdownFileContent(object[] items)
        {
            SegmentName = (string)items[0];
            DocumentTitle = (string)items[1];
            FileLocation = (string)items[2];
            ModifiedDate = (Date?)items[3];
            FileSize = (long)items[4];
            FileContent = (string)items[5];
        }

        public MarkdownFileContent(string SegmentName, string DocumentTitle, string FileLocation, Date? ModifiedDate, long FileSize, string FileContent)
        {
            this.SegmentName = SegmentName;
            this.DocumentTitle = DocumentTitle;
            this.FileLocation = FileLocation;
            this.ModifiedDate = ModifiedDate;
            this.FileSize = FileSize;
            this.FileContent = FileContent;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, DocumentTitle, FileLocation, ModifiedDate, FileSize, FileContent };
        }
    }

    [SqlRecord("SqlDocs", "MarkdownFileInfo")]
    public partial class MarkdownFileInfo : SqlTableTypeProxy<MarkdownFileInfo>
    {
        [SqlColumn("SegmentName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("DocumentTitle", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlColumn("FileLocation", 2), SqlTypeFacets("nvarchar", false, 500)]
        public string FileLocation
        {
            get;
            set;
        }

        [SqlColumn("ModifiedDate", 3), SqlTypeFacets("date", true)]
        public Date? ModifiedDate
        {
            get;
            set;
        }

        [SqlColumn("FileSize", 4), SqlTypeFacets("bigint", false)]
        public long FileSize
        {
            get;
            set;
        }

        public MarkdownFileInfo()
        {
        }

        public MarkdownFileInfo(object[] items)
        {
            SegmentName = (string)items[0];
            DocumentTitle = (string)items[1];
            FileLocation = (string)items[2];
            ModifiedDate = (Date?)items[3];
            FileSize = (long)items[4];
        }

        public MarkdownFileInfo(string SegmentName, string DocumentTitle, string FileLocation, Date? ModifiedDate, long FileSize)
        {
            this.SegmentName = SegmentName;
            this.DocumentTitle = DocumentTitle;
            this.FileLocation = FileLocation;
            this.ModifiedDate = ModifiedDate;
            this.FileSize = FileSize;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, DocumentTitle, FileLocation, ModifiedDate, FileSize };
        }
    }

    [SqlRecord("SqlDocs", "MarkdownHelpKeyword")]
    public partial class MarkdownHelpKeyword : SqlTableTypeProxy<MarkdownHelpKeyword>
    {
        [SqlColumn("SegmentName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("DocumentTitle", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlColumn("Keyword", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string Keyword
        {
            get;
            set;
        }

        public MarkdownHelpKeyword()
        {
        }

        public MarkdownHelpKeyword(object[] items)
        {
            SegmentName = (string)items[0];
            DocumentTitle = (string)items[1];
            Keyword = (string)items[2];
        }

        public MarkdownHelpKeyword(string SegmentName, string DocumentTitle, string Keyword)
        {
            this.SegmentName = SegmentName;
            this.DocumentTitle = DocumentTitle;
            this.Keyword = Keyword;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, DocumentTitle, Keyword };
        }
    }

    [SqlRecord("SqlDocs", "MarkdownTableInfo")]
    public partial class MarkdownTableInfo : SqlTableTypeProxy<MarkdownTableInfo>
    {
        [SqlColumn("SegmentName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("DocumentTitle", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlColumn("TablePosition", 2), SqlTypeFacets("int", false)]
        public int TablePosition
        {
            get;
            set;
        }

        [SqlColumn("RowCount", 3), SqlTypeFacets("int", false)]
        public int RowCount
        {
            get;
            set;
        }

        [SqlColumn("ColumnCount", 4), SqlTypeFacets("int", false)]
        public int ColumnCount
        {
            get;
            set;
        }

        public MarkdownTableInfo()
        {
        }

        public MarkdownTableInfo(object[] items)
        {
            SegmentName = (string)items[0];
            DocumentTitle = (string)items[1];
            TablePosition = (int)items[2];
            RowCount = (int)items[3];
            ColumnCount = (int)items[4];
        }

        public MarkdownTableInfo(string SegmentName, string DocumentTitle, int TablePosition, int RowCount, int ColumnCount)
        {
            this.SegmentName = SegmentName;
            this.DocumentTitle = DocumentTitle;
            this.TablePosition = TablePosition;
            this.RowCount = RowCount;
            this.ColumnCount = ColumnCount;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, DocumentTitle, TablePosition, RowCount, ColumnCount };
        }
    }

    [SqlRecord("SqlDocs", "MarkdownTableRow")]
    public partial class MarkdownTableRow : SqlTableTypeProxy<MarkdownTableRow>
    {
        [SqlColumn("SegmentName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("DocumentTitle", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlColumn("TableNumber", 2), SqlTypeFacets("int", true)]
        public int? TableNumber
        {
            get;
            set;
        }

        [SqlColumn("TablePosition", 3), SqlTypeFacets("int", false)]
        public int TablePosition
        {
            get;
            set;
        }

        [SqlColumn("RowNumber", 4), SqlTypeFacets("int", false)]
        public int RowNumber
        {
            get;
            set;
        }

        [SqlColumn("CellValue01", 5), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue01
        {
            get;
            set;
        }

        [SqlColumn("CellValue02", 6), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue02
        {
            get;
            set;
        }

        [SqlColumn("CellValue03", 7), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue03
        {
            get;
            set;
        }

        [SqlColumn("CellValue04", 8), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue04
        {
            get;
            set;
        }

        [SqlColumn("CellValue05", 9), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue05
        {
            get;
            set;
        }

        [SqlColumn("CellValue06", 10), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue06
        {
            get;
            set;
        }

        [SqlColumn("CellValue07", 11), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue07
        {
            get;
            set;
        }

        [SqlColumn("CellValue08", 12), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue08
        {
            get;
            set;
        }

        [SqlColumn("CellValue09", 13), SqlTypeFacets("nvarchar", true, 250)]
        public string CellValue09
        {
            get;
            set;
        }

        public MarkdownTableRow()
        {
        }

        public MarkdownTableRow(object[] items)
        {
            SegmentName = (string)items[0];
            DocumentTitle = (string)items[1];
            TableNumber = (int?)items[2];
            TablePosition = (int)items[3];
            RowNumber = (int)items[4];
            CellValue01 = (string)items[5];
            CellValue02 = (string)items[6];
            CellValue03 = (string)items[7];
            CellValue04 = (string)items[8];
            CellValue05 = (string)items[9];
            CellValue06 = (string)items[10];
            CellValue07 = (string)items[11];
            CellValue08 = (string)items[12];
            CellValue09 = (string)items[13];
        }

        public MarkdownTableRow(string SegmentName, string DocumentTitle, int? TableNumber, int TablePosition, int RowNumber, string CellValue01, string CellValue02, string CellValue03, string CellValue04, string CellValue05, string CellValue06, string CellValue07, string CellValue08, string CellValue09)
        {
            this.SegmentName = SegmentName;
            this.DocumentTitle = DocumentTitle;
            this.TableNumber = TableNumber;
            this.TablePosition = TablePosition;
            this.RowNumber = RowNumber;
            this.CellValue01 = CellValue01;
            this.CellValue02 = CellValue02;
            this.CellValue03 = CellValue03;
            this.CellValue04 = CellValue04;
            this.CellValue05 = CellValue05;
            this.CellValue06 = CellValue06;
            this.CellValue07 = CellValue07;
            this.CellValue08 = CellValue08;
            this.CellValue09 = CellValue09;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, DocumentTitle, TableNumber, TablePosition, RowNumber, CellValue01, CellValue02, CellValue03, CellValue04, CellValue05, CellValue06, CellValue07, CellValue08, CellValue09 };
        }
    }

    [SqlRecord("SqlDocs", "SqlSyntaxBlock")]
    public partial class SqlSyntaxBlock : SqlTableTypeProxy<SqlSyntaxBlock>
    {
        [SqlColumn("SegmentName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string SegmentName
        {
            get;
            set;
        }

        [SqlColumn("DocumentTitle", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentTitle
        {
            get;
            set;
        }

        [SqlColumn("SyntaxPosition", 2), SqlTypeFacets("int", false)]
        public int SyntaxPosition
        {
            get;
            set;
        }

        [SqlColumn("SyntaxContent", 3), SqlTypeFacets("nvarchar", false, 0)]
        public string SyntaxContent
        {
            get;
            set;
        }

        public SqlSyntaxBlock()
        {
        }

        public SqlSyntaxBlock(object[] items)
        {
            SegmentName = (string)items[0];
            DocumentTitle = (string)items[1];
            SyntaxPosition = (int)items[2];
            SyntaxContent = (string)items[3];
        }

        public SqlSyntaxBlock(string SegmentName, string DocumentTitle, int SyntaxPosition, string SyntaxContent)
        {
            this.SegmentName = SegmentName;
            this.DocumentTitle = DocumentTitle;
            this.SyntaxPosition = SyntaxPosition;
            this.SyntaxContent = SyntaxContent;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SegmentName, DocumentTitle, SyntaxPosition, SyntaxContent };
        }
    }
}
namespace SqlT.SqlDocs.Proxies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    [SqlProxyBrokerFactory]
    class SqlStoreBrokerFactory : SqlProxyBrokerFactory<SqlStoreBrokerFactory>
    {
        /// <summary>
                /// The name of the catalog that provided the source metadata from
                /// which the proxies were constructed
                /// </summary>
        public const string SourceCatalog = @"SqlT.SqlDocs";
        public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs) => ((SqlProxyBrokerFactory<SqlStoreBrokerFactory>)(new SqlStoreBrokerFactory())).CreateBroker(cs);
    }
}
// Emission concluded at 5/27/2018 10:01:19 AM
