//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;
    
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