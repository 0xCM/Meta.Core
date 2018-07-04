//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Language;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Types.SqlDom;

    using static metacore;

    /// <summary>
    /// Describes and classifies a type defined by the TSql/SqlT DOM
    /// </summary>
    public class SqlDomTypeDescriptor
    {
        public SqlDomTypeDescriptor(ClrType SqlDomType, ElementKind ElementType)
        {
            this.SqlDomType = SqlDomType;
            this.DomElementKind = ElementType;
            this.Attributes = rolist(TSqlDomTypeIndex.AttributeProperties(SqlDomType).Select(SqlDomAttribute.FromProperty));
            this.Associations = rolist(TSqlDomTypeIndex.AssociationProperties(SqlDomType).Select(SqlDomAssociation.FromProperty));
            this.Collections = rolist(TSqlDomTypeIndex.CollectionProperties(SqlDomType).Select(p => new SqlDomCollection(p.Property, p.ElementType)));
            this.EnumLiterals = SqlDomType.IsEnumType
                ? ClrEnum.Get(SqlDomType).Literals.Stream().ToReadOnlyList()
                : rolist<ClrEnumLiteral>();

        }

        public ClrType SqlDomType { get; }

        public ElementKind DomElementKind { get; }

        public IReadOnlyList<SqlDomAttribute> Attributes { get; }

        public IReadOnlyList<SqlDomAssociation> Associations { get; }

        public IReadOnlyList<SqlDomCollection> Collections { get; }

        public IReadOnlyList<ClrEnumLiteral> EnumLiterals { get; }


        public bool IsConcrete
            => not(SqlDomType.IsAbstract);

        public bool IsEnum
            => EnumLiterals.Count != 0;

        public string ElementName
            => SqlDomType.Name;

        public string ParentName
            => SqlDomType.BaseType.MapValueOrDefault(t => t.Name, string.Empty);

        public override string ToString()
            => isNotBlank(ParentName)
            ? $"{ParentName} > {SqlDomType} : {DomElementKind}"
            : $"{SqlDomType} : {DomElementKind}";

    }

}