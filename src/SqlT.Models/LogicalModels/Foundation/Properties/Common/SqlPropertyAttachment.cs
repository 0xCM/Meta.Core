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

    using static metacore;

    using SqlT.Core;
    using SqlT.Syntax;
    using static SqlT.Syntax.SqlSyntax;

    /// <summary>
    /// Characterizes an extended property
    /// </summary>
    [SqlElementType(SqlElementTypeNames.ExtendedProperty)]
    public sealed class SqlPropertyAttachment : SqlElement<SqlPropertyAttachment>
    {
        static readonly xprop_level0_type XPL0 = new xprop_level0_type();
        static readonly xprop_level1_type XPL1 = new xprop_level1_type();
        static readonly xprop_level2_type XPL2 = new xprop_level2_type();

        static readonly Dictionary<string, xprop_type> PropertyTypeIndex
            = new Dictionary<string, xprop_type>
            {
                [SqlElementTypeNames.ColumnStoreIndex] = XPL2.Index,
                [SqlElementTypeNames.Contract] = XPL0.Contract,
                [SqlElementTypeNames.Database] = XPL0.Database,
                [SqlElementTypeNames.DefaultConstraint] = XPL2.Constraint,
                [SqlElementTypeNames.ExtendedPrimitive] = XPL1.Type,
                [SqlElementTypeNames.Filegroup] = XPL0.FileGroup,
                [SqlElementTypeNames.ForeignKey] = XPL2.Constraint,
                [SqlElementTypeNames.Index] = XPL2.Index,
                [SqlElementTypeNames.MessageType] = XPL0.MessageType,
                [SqlElementTypeNames.Parameter] = XPL2.Parameter,
                [SqlElementTypeNames.PrimaryKeyConstraint] = XPL2.Constraint,
                [SqlElementTypeNames.Procedure] = XPL1.Procedure,
                [SqlElementTypeNames.Projector] = XPL1.Procedure,
                [SqlElementTypeNames.Queue] = XPL1.Queue,
                [SqlElementTypeNames.ScalarFunction] = XPL1.Function,
                [SqlElementTypeNames.Schema] = XPL0.Schema,
                [SqlElementTypeNames.Sequence] = XPL1.Sequence,
                [SqlElementTypeNames.Service] = XPL0.Service,
                [SqlElementTypeNames.Synonym] = XPL1.Synonym,
                [SqlElementTypeNames.Table] = XPL1.Table,
                [SqlElementTypeNames.TableColumn] = XPL2.Column,
                [SqlElementTypeNames.TableType] = XPL1.TableType,
                [SqlElementTypeNames.TableTypeColumn] = XPL2.Column,
                [SqlElementTypeNames.TableValuedFunction] = XPL1.Function,
                [SqlElementTypeNames.UniqueConstraint] = XPL2.Constraint,
                [SqlElementTypeNames.User] = XPL0.User,
                [SqlElementTypeNames.View] = XPL1.View,
            };


        /// <summary>
        /// Transparently extracts the value from the property
        /// </summary>
        /// <param name="p">The property from which the value will be extracted</param>
        public static implicit operator string(SqlPropertyAttachment p) 
            => toString(p.PropertyValue);

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlPropertyAttachment"/> element
        /// </summary>
        /// <param name="SubjectLineage">The subject to which the property is attached together with it's lineage in ascending structural order</param>
        /// <param name="PropertyName">The name of the property</param>
        /// <param name="PropertyValue">The value of the property</param>
        public SqlPropertyAttachment(IReadOnlyList<SqlElementDescriptor> SubjectLineage,
            SqlExtendedPropertyName PropertyName, object PropertyValue)
            : base(PropertyName, Documentation: null)
        {
            this.SubjectLineage = SubjectLineage;
            this.PropertyName = PropertyName;
            this.PropertyValue = PropertyValue;
        }

        /// <summary>
        /// The subject to which the property is attached together with it's lineage in ascending structural order
        /// </summary>
        public IReadOnlyList<SqlElementDescriptor> SubjectLineage { get; }

        /// <summary>
        /// The name of the property
        /// </summary>
        public SqlExtendedPropertyName PropertyName { get; }

        /// <summary>
        /// The value of the property
        /// </summary>
        public object PropertyValue { get; }

        SqlElementDescriptor Subject
            => SubjectLineage.LastOrDefault();

        /// <summary>
        /// Gets the subject's name
        /// </summary>
        public string SubjectName
            => (Subject?.FullName) ?? String.Empty;

        public override string ToString() 
            => $"{SubjectName}({PropertyName})={PropertyValue}";
    }

}