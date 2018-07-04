//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Models;
    using SqlT.Core;

    using static metacore;
    using static SqlSyntax;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

    public sealed class database_file : Model<database_file>
    {
        public database_file(SimpleSqlName logical_file_name, string_literal filename,
            file_size initial_size = null, file_size max_size = null, file_growth file_growth = null)
        {
            this.logical_file_name = logical_file_name;
            this.filename = filename;
            this.initial_size = initial_size;
            this.file_growth = file_growth;
        }

        public SimpleSqlName logical_file_name { get; }

        public string_literal filename { get; }

        public ModelOption<file_size> initial_size { get; }

        public ModelOption<file_size> max_size { get; }

        public ModelOption<file_growth> file_growth { get; }

        public override string ToString()
            => concat($"{NAME} = {logical_file_name}",
                $", {FILENAME} ={filename}",
                initial_size.map(x => $",{SIZE} = {x}", () => string.Empty),
                max_size.map(x => $",{MAXSIZE} = {x}", () => string.Empty),
                file_growth.map(x => $", {FILEGROWTH} = {x}", () => string.Empty));
    }

}