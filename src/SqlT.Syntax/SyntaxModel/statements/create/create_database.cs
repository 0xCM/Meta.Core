//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using static metacore;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Core;

    using kwt = SqlKeywordTypes;

    partial class SqlSyntax
    {

        public sealed class create_database : create_statement<create_database, SqlDatabaseName>
        {
            public create_database(
                SqlDatabaseName database_name, 
                SyntaxList<database_file> filespecs = null,
                bool? contained = null,
                bool? trustworthy = null
                )
                : base(DATABASE, database_name)
            {
                this.filespecs = filespecs ?? SyntaxList<database_file>.empty;
                this.containment = toggled_option.optional<kwt.CONTAINMENT>(contained);
                this.trustworthy = toggled_option.optional<kwt.TRUSTWORTHY>(trustworthy);
            }

            public ModelOption<toggled_option<kwt.CONTAINMENT>> containment { get; }

            public ModelOption<toggled_option<kwt.TRUSTWORTHY>> trustworthy { get; }

            public ModelOption<service_broker_option> service_broker_option { get; }

            public SyntaxList<database_file> filespecs { get; }
        }
    }
}

