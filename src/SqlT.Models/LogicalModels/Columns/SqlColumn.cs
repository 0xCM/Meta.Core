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

    using Meta.Models;
    using SqlT.Core;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    public abstract class SqlColumn<C> : SqlElement<C>, ISqlColumn<C>
        where C : SqlColumn<C>
    {

        public static implicit operator SqlColumnDefinition(SqlColumn<C> c)
            => c.Definition;

        protected SqlColumn(SqlColumnName ColumnName, int Position,
            sxc.data_type_ref DataTypeReference, sxc.sql_object Parent) 
                : this(ColumnName, Position, DataTypeReference,
                    Parent, Documentation: null, Properties: null, null, null, false, null
                )
        { }

        protected SqlColumn
        (
            SqlColumnName ColumnName,
            int Position,
            sxc.data_type_ref DataTypeReference,
            sxc.sql_object Parent,
            SqlElementDescription Documentation,
            IEnumerable<SqlPropertyAttachment> Properties,
            SqlDefaultConstraint DefaultConstraint,
            string ComputationExpression,
            bool ComputationPersisted,
            SqlColumnRoleType ColumnRole
         )
            : base
            (ColumnName, Documentation:Documentation, Properties: Properties)
        {
            this.Position = Position;
            this.DataTypeReference = DataTypeReference;
            this.Parent = Parent != null 
                ? some(Parent as sxc.sql_object) 
                : new Option<sxc.sql_object>();
            this.DefaultConstraint = DefaultConstraint;
            this.ComputationExpression = ComputationExpression;
            this.ComputationPersisted = ComputationPersisted;
            this.ColumnRole = ColumnRole ?? SqlColumnRoleTypes.UnclassifiedRole;
        }

        protected SqlColumn(SqlColumnDefinition def)
            : base(def.Name, def.Documentation.ValueOrDefault(), def.Properties)
        {
            Parent = def.Parent.Map(p => p as sxc.sql_object);
            DefaultConstraint = def.Default;
            DataTypeReference = def.DataType;
            ColumnRole = def.ColumnRole;
            Position = def.Position;
            ComputationExpression = def.ComputationExpression;
            ComputationPersisted = def.ComputationPersisted;
            
        }

        public Option<sxc.sql_object> Parent { get; }

        public Option<SqlDefaultConstraint> DefaultConstraint { get; }

        public sxc.data_type_ref DataTypeReference { get; }

        public SqlColumnRoleType ColumnRole { get; }

        public int Position { get; }

        public Option<string> ComputationExpression { get; }

        public bool ComputationPersisted { get; }

        public bool IsComputed
            => ComputationExpression.IsSome() && isNotBlank(~ComputationExpression);

        public SqlColumnName ColumnName
            =>(SqlColumnName)ElementName;

        public SqlColumnName Name
            => ColumnName;

        public SqlColumnIdentifier ColumnIdentifier
            => new SqlColumnIdentifier(Name, Position);

        /// <summary>
        /// Recovers the definition from the specification
        /// </summary>
        public virtual SqlColumnDefinition Definition
            => new SqlColumnDefinition
            (
                this.Position,
                this.Name.UnqualifiedName,
                this.DataTypeReference,
                this.Parent.ValueOrDefault(),
                this.Properties,
                this.Documentation.ValueOrDefault(),
                this.DefaultConstraint.ValueOrDefault(),
                this.ComputationExpression.ValueOrDefault(),
                this.ComputationPersisted,
                this.ColumnRole
            );

        SqlColumnName IModel<SqlColumnName>.Name
            => Name;

        public override string ToString()
            => $"[{Name} {DataTypeReference}";

        public abstract C Retype(SqlTypeReference newType);

        public abstract C Reparent(sxc.sql_object newParent);

        public abstract C Reposition(int newPosition);

        public abstract C Rename(SqlColumnName newName);

        ISqlColumn ISqlColumn.Reparent(sxc.sql_object newParent)
            => Reparent(newParent);

        ISqlColumn ISqlColumn.Retype(SqlTypeReference newType)
            => Retype(newType);

        ISqlColumn ISqlColumn.Reposition(int newPosition)
            => Reposition(newPosition);

        ISqlColumn ISqlColumn.Rename(SqlColumnName newName)
            => Rename(newName);
    }

    public sealed class SqlColumn : SqlColumn<SqlColumn>
    {
        public SqlColumn(SqlColumnName Name, int Position, sxc.data_type_ref TypeReference, sxc.sql_object Parent = null)
            : base(Name, Position, TypeReference, Parent)
        { }

        public override SqlColumn Retype(SqlTypeReference newType)
            => new SqlColumn(Name, Position, DataTypeReference.retype(newType), Parent.ValueOrDefault());

        public override SqlColumn Rename(SqlColumnName newName)
            => new SqlColumn(newName, Position, DataTypeReference, Parent.ValueOrDefault());

        public override SqlColumn Reparent(sxc.sql_object newParent)
            => new SqlColumn(Name, Position, DataTypeReference, newParent);

        public override SqlColumn Reposition(int newPosition)
            => new SqlColumn(Name, newPosition, DataTypeReference, Parent.ValueOrDefault());
    }
}
