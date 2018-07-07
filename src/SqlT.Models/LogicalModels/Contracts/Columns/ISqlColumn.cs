//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Defines contract for all tabular-owed columns
    /// </summary>
    public interface ISqlColumn : ISqlElement<SqlColumnName>
    {
        /// <summary>
        /// The peer-relative and 0-based position of the column
        /// </summary>
        int Position { get; }

        sxc.data_type_ref DataTypeReference { get; }

        /// <summary>
        /// The owning tabular, if any
        /// </summary>
        Option<sxc.sql_object> Parent { get; }

        /// <summary>
        /// Default constraint applied to the column, if any
        /// </summary>
        Option<SqlDefaultConstraint> DefaultConstraint { get; }

        /// <summary>
        /// Identifies the column by name and/or relative position
        /// </summary>
        SqlColumnIdentifier ColumnIdentifier { get; }

        /// <summary>
        /// The column's computed value, if any
        /// </summary>
        Option<string> ComputationExpression { get; }

        /// <summary>
        /// If column is computed, indicates whether the computation is persisted
        /// </summary>
        bool ComputationPersisted { get; }

        /// <summary>
        /// The role played by the column within its context
        /// </summary>
        SqlColumnRoleType ColumnRole { get; }

        /// <summary>
        /// Clones the column while assigning it a new data type
        /// </summary>
        /// <param name="newType">Describes the new data type</param>
        /// <returns></returns>
        ISqlColumn Retype(SqlTypeDescriptor newType);

        /// <summary>
        /// Clones the column while assigning it a new parent
        /// </summary>
        /// <param name="newParent">The new parent to which the column will belong</param>
        /// <returns></returns>
        ISqlColumn Reparent(sxc.sql_object newParent);

        /// <summary>
        /// Clones the column while assigning it a new position
        /// </summary>
        /// <param name="newPosition">The new position the column will occupy</param>
        /// <returns></returns>
        ISqlColumn Reposition(int newPosition);

        /// <summary>
        /// Clones the column while assigning it a new name
        /// </summary>
        /// <param name="newName">The column's new name</param>
        /// <returns></returns>
        ISqlColumn Rename(SqlColumnName newName);
    }

    public interface ISqlColumn<M> : ISqlColumn
        where M : ISqlColumn
    {

    }
}
