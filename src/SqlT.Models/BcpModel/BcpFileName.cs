//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SqlT.Core;
    using Meta.Core;
    
    using static metacore;

    using N = SqlBcpFileName;

    public struct IdentifiedBcpExtension 
    {

        public static implicit operator IdentifiedBcpExtension((BcpFileType Type, FileExtension Extension) xy)
            => new IdentifiedBcpExtension(xy);

        public static implicit operator (BcpFileType Type, FileExtension Extension)(IdentifiedBcpExtension x)
            => (x.Type, x.Extension);

        public IdentifiedBcpExtension((BcpFileType Type, FileExtension Extension) xy)
        {
            this.Type = xy.Type;
            this.Extension = xy.Extension;
        }

        public IdentifiedBcpExtension(BcpFileType Type, FileExtension Extension)
        {
            this.Type = Type;
            this.Extension = Extension;
        }

        public BcpFileType Type { get; }

        public FileExtension Extension { get; }

    }

    public sealed class SqlBcpFileName : FileName<N>
    {
        sealed class BcpScriptExtensionLookup 
        {

            static readonly Map<BcpFileType, FileExtension> LookupMap = Map.cons
                ((BcpFileType.BcpExportScript, FileExtension.Parse("bat")),
                (BcpFileType.BcpFormatScript, FileExtension.Parse("bat")),
                (BcpFileType.BcpImportScript, FileExtension.Parse("bat")),
                (BcpFileType.SqlInsertScript, FileExtension.Parse("sql")));

            public Option<FileExtension> Lookup(BcpFileType FileType)
                => LookupMap.Value(FileType);
        }

        sealed class BcpContentExtensionLookup 
        {

            static readonly Map<BcpFileType, FileExtension> LookupMap = Map.cons
                ((BcpFileType.DataFile, FileExtension.Parse("dat")),
                (BcpFileType.FormatFile, FileExtension.Parse("fmt")));

            public Option<FileExtension> Lookup(BcpFileType FileType)
                => LookupMap.Value(FileType);
        }

        sealed class BcpActionExtensionLookup   
        {
            static readonly Map<BcpFileType, FileExtension> LookupMap = Map.cons
                ((BcpFileType.BcpExportScript, FileExtension.Parse("export")),
                (BcpFileType.BcpFormatScript, FileExtension.Parse("format")),
                (BcpFileType.BcpImportScript, FileExtension.Parse("import")),
                (BcpFileType.SqlInsertScript, FileExtension.Parse("insert")));

            public Option<FileExtension> Lookup(BcpFileType FileType)
                => LookupMap.Value(FileType);
        }

        protected override Func<string, N> Reconstructor
            => path => new N(path);

        public static N Create(BcpFileType FileType, SqlTableName srcTable, string FilterValue = null)
        {
            var actions = new BcpScriptExtensionLookup();
            var content = new BcpContentExtensionLookup();
            var scripts = new BcpScriptExtensionLookup();
            
            var fn = FileName.Parse($"{srcTable.ServerNamePart}.{srcTable.DatabaseNamePart}.{srcTable.SchemaNamePart}.{srcTable.UnqualifiedName}");
            if (isNotBlank(FilterValue))
                fn += FileExtension.Parse($"{FilterValue}");

            actions.Lookup(FileType).OnSome(x => fn += x);
            scripts.Lookup(FileType).OnSome(x => fn += x);
            content.Lookup(FileType).OnSome(x => fn += x);

            return new N(fn);
        }

        public static N Parse(params string[] parts)
            => string.Join(string.Empty, parts);

        public static implicit operator FileName(N x)
            => new FileName(x.Value);

        public static implicit operator FilePath(N x)
            => new FilePath(x.Value);

        public static implicit operator N(string x)
            => new N(x);

        public static N operator +(N filename, FileExtension extension)
            => filename.AddExtension(extension);

        public SqlBcpFileName()
            : this(string.Empty)
        {

        }

        public SqlBcpFileName(string Value)
            : base(Value)
        { }

        public override string ToString()
            => this.Value;
    }
}