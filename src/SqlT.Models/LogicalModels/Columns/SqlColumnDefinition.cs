//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Syntax;
    using static metacore;
    using sxc = SqlT.Syntax.contracts;
        
    public sealed class SqlColumnDefinition  : SqlElementDefinition<SqlColumnDefinition, SqlColumnName>
    {
        public static SqlColumnDefinition Specify<t>(int position, SqlColumnName name, t type, string description = null)
            where t : sxc.data_type_ref
                => new SqlColumnDefinition(position, name, type, Documentation: description);

        public static SqlColumnDefinition Specify<t>(int position, SqlColumnName name, t type, SqlColumnRoleType role)
            where t : sxc.data_type_ref
                => new SqlColumnDefinition(position, name, type, ColumnRole: role);

        public static SqlColumnDefinition Specify<t>(SqlColumnName name, t type, SqlColumnRoleType role)
            where t : sxc.data_type_ref
                => new SqlColumnDefinition(-1, name, type, ColumnRole: role);

        public static SqlColumnDefinition Specify<t>(SqlColumnName name, t type, string description = null)
            where t : sxc.data_type_ref
                => new SqlColumnDefinition(-1, name, type, Documentation: description);

        public static SqlColumnDefinition Specify<t>(SqlColumnName name, t type, SqlSequenceName seq, bool pk = true)
            where t : sxc.data_type_ref
                => seq.CreateSequencedColumn(type, SqlTableName.Empty, -1, pk, name);

        public static SqlColumnDefinition Specify(int position, SqlColumnName name, sxc.ISqlType type,
            bool isNullable, int? length = null, byte? precision = null, byte? scale = null, string description = null)
            => new SqlTableColumn(
                         Position: position,
                         LocalName: name,
                         DataType: type.Reference(isNullable, length, precision, scale),
                         Documentation: description
                        );

        public static implicit operator SqlColumnName(SqlColumnDefinition c)
            => c.Name;

        public SqlColumnDefinition(){}

        public SqlColumnDefinition
        (
            int Position,
            SqlColumnName Name,
            sxc.data_type_ref DataType,
            sxc.sql_object Parent = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            SqlElementDescription Documentation = null,
            SqlDefaultConstraint Default = null,
            string ComputationExpression = null,
            bool ComputationPersisted = false,
            SqlColumnRoleType ColumnRole = null
         ) : base(Name, Properties, Documentation)

        {
            this.Position = Position;
            this.Name = Name;
            this.DataType = DataType;
            this.Parent = Parent != null ? some(Parent) : none<sxc.sql_object>();
            this.Default = Default;
            this.ComputationExpression = isBlank(ComputationExpression) 
              ? none<string>() 
              : some(ComputationExpression);
            this.ComputationPersisted = ComputationPersisted;
            this.ColumnRole = ColumnRole ?? SqlColumnRoleTypes.UnclassifiedRole;
        }

        public int Position { get; set; }
        
        public sxc.data_type_ref DataType { get; set; }
        
        public Option<sxc.sql_object> Parent { get; set; }

        public Option<SqlDefaultConstraint> Default { get; set; }

        public Option<string> ComputationExpression { get; set; }

        public bool ComputationPersisted { get; set; }
    
        public SqlColumnRoleType ColumnRole { get; set; }

        public SqlColumnIdentifier ColumnIdentifier 
            => new SqlColumnIdentifier(Name, Position);

        public override string ToString()
            => (Position != -1 ? $"{Position} " : String.Empty) 
            +  Name.UnqualifiedName
            + (ColumnRole.RoleKind == SqlColumnRoleKind.Unclassified 
            ? String.Empty 
            : $"({ColumnRole.RoleName})");
    }

}
