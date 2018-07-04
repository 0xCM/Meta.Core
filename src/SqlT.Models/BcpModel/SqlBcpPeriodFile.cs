//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;


    public abstract class SqlBcpPeriodFile<T> : ValueObject<T>
        where T : SqlBcpPeriodFile<T>
    {
        protected SqlBcpPeriodFile(DateRange Period, SqlTableName SourceTable, FileExtension Extension)
        {
            this.Period = Period;
            this.SourceTable = SourceTable;
            this.Extension = Extension;
        }

        public DateRange Period { get; }

        public SqlTableName SourceTable { get; }

        public FileExtension Extension { get; }

        public FileName FileName
            => new FileName($"{SourceTable.TrimServer().Format(false)}.{Period.ToDelimitedString()}", Extension);

        public FilePath GetPath(FolderPath outfolder)
            => outfolder + FileName;

        public override string ToString()
            => FileName;
    }


}