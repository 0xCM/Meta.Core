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

    using Meta.Models;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    public abstract class SqlColumn<C> : SqlElement<C>, ISqlColumn<C>
        where C : SqlColumn<C>
    {

        public static implicit operator SqlColumnDefinition(SqlColumn<C> c)
            => c.Definition;

        protected SqlColumn(
            SqlColumnName ColumnName,
            int Position,
            sxc.data_type_ref DataTypeReference,
            ISqlObject Parent
            ) : this
                (
                    ColumnName,
                    Position,
                    DataTypeReference,
                    Parent,
                    null,
                    null,
                    null,
                    null,
                    false,
                    null
                )
        { }

        protected SqlColumn
        (
            SqlColumnName ColumnName,
            int Position,
            sxc.data_type_ref DataTypeReference,
            ISqlObject Parent,
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
            this.Parent = Parent != null ? some(Parent) : new Option<ISqlObject>();
            this.DefaultConstraint = DefaultConstraint;
            this.ComputationExpression = ComputationExpression;
            this.ComputationPersisted = ComputationPersisted;
            this.ColumnRole = ColumnRole ?? SqlColumnRoleTypes.UnclassifiedRole;
        }

        protected SqlColumn(SqlColumnDefinition def)
            : base(def.Name, def.Documentation.ValueOrDefault(), def.Properties)
        {
            Parent = def.Parent;
            DefaultConstraint = def.Default;
            DataTypeReference = def.DataType;
            ColumnRole = def.ColumnRole;
            Position = def.Position;
            ComputationExpression = def.ComputationExpression;
            ComputationPersisted = def.ComputationPersisted;
            
        }

        public Option<ISqlObject> Parent { get; }

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

        public abstract C Retype(SqlTypeDescriptor newType);

        public abstract C Reparent(ISqlObject newParent);

        public abstract C Reposition(int newPosition);

        public abstract C Rename(SqlColumnName newName);

        ISqlColumn ISqlColumn.Reparent(ISqlObject newParent)
            => Reparent(newParent);

        ISqlColumn ISqlColumn.Retype(SqlTypeDescriptor newType)
            => Retype(newType);

        ISqlColumn ISqlColumn.Reposition(int newPosition)
            => Reposition(newPosition);

        ISqlColumn ISqlColumn.Rename(SqlColumnName newName)
            => Rename(newName);
    }

    public sealed class SqlColumn : SqlColumn<SqlColumn>
    {
        public SqlColumn(SqlColumnName Name, int Position, sxc.data_type_ref TypeReference, ISqlObject Parent = null)
            : base(Name, Position, TypeReference, Parent)
        { }

        public override SqlColumn Retype(SqlTypeDescriptor newType)
            => new SqlColumn(Name, Position, DataTypeReference.retype(newType), Parent.ValueOrDefault());

        public override SqlColumn Rename(SqlColumnName newName)
            => new SqlColumn(newName, Position, DataTypeReference, Parent.ValueOrDefault());

        public override SqlColumn Reparent(ISqlObject newParent)
            => new SqlColumn(Name, Position, DataTypeReference, newParent);

        public override SqlColumn Reposition(int newPosition)
            => new SqlColumn(Name, newPosition, DataTypeReference, Parent.ValueOrDefault());
    }
}
