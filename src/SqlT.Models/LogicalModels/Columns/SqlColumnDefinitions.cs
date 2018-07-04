//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;

    using Meta.Syntax;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;
    using kwt = SqlT.Syntax.SqlKeywordTypes;
    
    public sealed class SqlColumnDefinitions : SyntaxList<SqlColumnDefinition>
    {

        public static implicit operator SqlColumnDefinitions(SqlColumnDefinition[] definitions)
            => new SqlColumnDefinitions(definitions);

        public SqlColumnDefinitions(params SqlColumnDefinition[] definitions)
            : base(definitions)
        { }

        public Option<SqlColumnDefinition> this[SqlColumnRoleKind role]
            => this.FirstOrDefault(c => c.ColumnRole.RoleKind == role);

        public Option<SqlColumnDefinition> this[SqlColumnIdentifier colid]
            => this.FirstOrDefault(c => c.ColumnIdentifier == colid);
    }
}