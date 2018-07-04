//This file was generated at 5/12/2018 8:42:08 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.Types.SqlDom
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SqlDomViewNames
    {
        public readonly static SqlViewName ElementLineage = "[SqlDom].[ElementLineage]";
        public readonly static SqlViewName ElementMember = "[SqlDom].[ElementMember]";
        public readonly static SqlViewName EnumElement = "[SqlDom].[EnumElement]";
    }

    public sealed class SqlDomTableTypeNames
    {
        public readonly static SqlTableTypeName Association = "[SqlDom].[Association]";
        public readonly static SqlTableTypeName AttributeValue = "[SqlDom].[AttributeValue]";
        public readonly static SqlTableTypeName Collection = "[SqlDom].[Collection]";
        public readonly static SqlTableTypeName Element = "[SqlDom].[Element]";
        public readonly static SqlTableTypeName ElementAttribute = "[SqlDom].[ElementAttribute]";
        public readonly static SqlTableTypeName EnumLiteral = "[SqlDom].[EnumLiteral]";
        public readonly static SqlTableTypeName ScriptDocument = "[SqlDom].[ScriptDocument]";
        public readonly static SqlTableTypeName ScriptXml = "[SqlDom].[ScriptXml]";
    }

    public enum ElementKind : int
    {
        /// <summary>
        /// Indicates the absence of a classification
        /// </summary>
        [Description("Indicates the absence of a classification")]
        None = 0,
        /// <summary>
        /// Identifies an infrastrucutre type that isn't relevant to the representation/modeling of SQL syntax
        /// </summary>
        [Description("Identifies an infrastrucutre type that isn't relevant to the representation/modeling of SQL syntax")]
        Infrastructure = 1,
        /// <summary>
        /// Identifies a type that models a literal value
        /// </summary>
        [Description("Identifies a type that models a literal value")]
        Literal = 2,
        /// <summary>
        /// Identifies a type that models a nonscalar expression
        /// </summary>
        [Description("Identifies a type that models a nonscalar expression")]
        NonscalarExpression = 3,
        /// <summary>
        /// Identifies a type that models a scalar expression
        /// </summary>
        [Description("Identifies a type that models a scalar expression")]
        ScalarExpression = 4,
        /// <summary>
        /// Identifies an enumeration type
        /// </summary>
        [Description("Identifies an enumeration type")]
        Enum = 5,
        /// <summary>
        /// Identifies a type that models an option
        /// </summary>
        [Description("Identifies a type that models an option")]
        Option = 6,
        /// <summary>
        /// Identifies an element, such as a table or column, within some context
        /// </summary>
        [Description("Identifies an element, such as a table or column, within some context")]
        ElementReference = 7,
        /// <summary>
        /// Identifies a defining type
        /// </summary>
        [Description("Identifies a defining type")]
        Definition = 8,
        /// <summary>
        /// Identifies a type that models an alter statement
        /// </summary>
        [Description("Identifies a type that models an alter statement")]
        AlterStatement = 9,
        /// <summary>
        /// Identifies a type that models a create statement
        /// </summary>
        [Description("Identifies a type that models a create statement")]
        CreateStatement = 10,
        /// <summary>
        /// Identifies a type that models a drop statement
        /// </summary>
        [Description("Identifies a type that models a drop statement")]
        DropStatement = 11,
        /// <summary>
        /// Identifies a type that models a predicate
        /// </summary>
        [Description("Identifies a type that models a predicate")]
        Predicate = 12,
        /// <summary>
        /// Identifies a type that models a statement that is not a create, drop or alter statement
        /// </summary>
        [Description("Identifies a type that models a statement that is not a create, drop or alter statement")]
        BasicStatement = 13,
        /// <summary>
        /// Identifies a type that models a clause
        /// </summary>
        [Description("Identifies a type that models a clause")]
        Clause = 14,
        /// <summary>
        /// Identifies a type that models an action
        /// </summary>
        [Description("Identifies a type that models an action")]
        Action = 15,
        /// <summary>
        /// Identifies a type that models an identifier or name
        /// </summary>
        [Description("Identifies a type that models an identifier or name")]
        Identifier = 16,
        /// <summary>
        /// Identifies a non-enumeration classifying type
        /// </summary>
        [Description("Identifies a non-enumeration classifying type")]
        Classifier = 17,
        /// <summary>
        /// Identifies a type that exists to provide backwards compatibility 
        /// </summary>
        [Description("Identifies a type that exists to provide backwards compatibility ")]
        CompatibilityElement = 18
    }

    [SqlRecord("SqlDom", "ScriptXml")]
    public partial class ScriptXml : SqlTableTypeProxy<ScriptXml>
    {
        [SqlColumn("ScriptName", 0), SqlTypeFacets("varchar", false, 128)]
        public string ScriptName
        {
            get;
            set;
        }

        [SqlColumn("SourceText", 1), SqlTypeFacets("nvarchar", false, 0)]
        public string SourceText
        {
            get;
            set;
        }

        [SqlColumn("XmlFormat", 2), SqlTypeFacets("xml", false)]
        public string XmlFormat
        {
            get;
            set;
        }

        public ScriptXml()
        {
        }

        public ScriptXml(object[] items)
        {
            ScriptName = (string)items[0];
            SourceText = (string)items[1];
            XmlFormat = (string)items[2];
        }

        public ScriptXml(string ScriptName, string SourceText, string XmlFormat)
        {
            this.ScriptName = ScriptName;
            this.SourceText = SourceText;
            this.XmlFormat = XmlFormat;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ScriptName, SourceText, XmlFormat };
        }

        public override void SetItemArray(object[] items)
        {
            ScriptName = (string)items[0];
            SourceText = (string)items[1];
            XmlFormat = (string)items[2];
        }
    }

    [SqlRecord("SqlDom", "ElementAttribute")]
    public partial class ElementAttribute : SqlTableTypeProxy<ElementAttribute>
    {
        [SqlColumn("ElementName", 0), SqlTypeFacets("varchar", false, 250)]
        public string ElementName
        {
            get;
            set;
        }

        [SqlColumn("AttributeName", 1), SqlTypeFacets("varchar", false, 250)]
        public string AttributeName
        {
            get;
            set;
        }

        [SqlColumn("DataType", 2), SqlTypeFacets("varchar", false, 250)]
        public string DataType
        {
            get;
            set;
        }

        [SqlColumn("Infrastructure", 3), SqlTypeFacets("bit", false)]
        public bool Infrastructure
        {
            get;
            set;
        }

        [SqlColumn("IsReadOnly", 4), SqlTypeFacets("bit", false)]
        public bool IsReadOnly
        {
            get;
            set;
        }

        public ElementAttribute()
        {
        }

        public ElementAttribute(object[] items)
        {
            ElementName = (string)items[0];
            AttributeName = (string)items[1];
            DataType = (string)items[2];
            Infrastructure = (bool)items[3];
            IsReadOnly = (bool)items[4];
        }

        public ElementAttribute(string ElementName, string AttributeName, string DataType, bool Infrastructure, bool IsReadOnly)
        {
            this.ElementName = ElementName;
            this.AttributeName = AttributeName;
            this.DataType = DataType;
            this.Infrastructure = Infrastructure;
            this.IsReadOnly = IsReadOnly;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ElementName, AttributeName, DataType, Infrastructure, IsReadOnly };
        }

        public override void SetItemArray(object[] items)
        {
            ElementName = (string)items[0];
            AttributeName = (string)items[1];
            DataType = (string)items[2];
            Infrastructure = (bool)items[3];
            IsReadOnly = (bool)items[4];
        }
    }

    [SqlRecord("SqlDom", "Collection")]
    public partial class Collection : SqlTableTypeProxy<Collection>
    {
        [SqlColumn("ElementName", 0), SqlTypeFacets("varchar", false, 250)]
        public string ElementName
        {
            get;
            set;
        }

        [SqlColumn("CollectionName", 1), SqlTypeFacets("varchar", false, 250)]
        public string CollectionName
        {
            get;
            set;
        }

        [SqlColumn("ItemType", 2), SqlTypeFacets("varchar", false, 250)]
        public string ItemType
        {
            get;
            set;
        }

        [SqlColumn("IsReadOnly", 3), SqlTypeFacets("bit", false)]
        public bool IsReadOnly
        {
            get;
            set;
        }

        public Collection()
        {
        }

        public Collection(object[] items)
        {
            ElementName = (string)items[0];
            CollectionName = (string)items[1];
            ItemType = (string)items[2];
            IsReadOnly = (bool)items[3];
        }

        public Collection(string ElementName, string CollectionName, string ItemType, bool IsReadOnly)
        {
            this.ElementName = ElementName;
            this.CollectionName = CollectionName;
            this.ItemType = ItemType;
            this.IsReadOnly = IsReadOnly;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ElementName, CollectionName, ItemType, IsReadOnly };
        }

        public override void SetItemArray(object[] items)
        {
            ElementName = (string)items[0];
            CollectionName = (string)items[1];
            ItemType = (string)items[2];
            IsReadOnly = (bool)items[3];
        }
    }

    [SqlRecord("SqlDom", "Association")]
    public partial class Association : SqlTableTypeProxy<Association>
    {
        [SqlColumn("ElementName", 0), SqlTypeFacets("varchar", false, 250)]
        public string ElementName
        {
            get;
            set;
        }

        [SqlColumn("AssociationName", 1), SqlTypeFacets("varchar", false, 250)]
        public string AssociationName
        {
            get;
            set;
        }

        [SqlColumn("AssociationType", 2), SqlTypeFacets("varchar", false, 250)]
        public string AssociationType
        {
            get;
            set;
        }

        [SqlColumn("IsReadOnly", 3), SqlTypeFacets("bit", false)]
        public bool IsReadOnly
        {
            get;
            set;
        }

        public Association()
        {
        }

        public Association(object[] items)
        {
            ElementName = (string)items[0];
            AssociationName = (string)items[1];
            AssociationType = (string)items[2];
            IsReadOnly = (bool)items[3];
        }

        public Association(string ElementName, string AssociationName, string AssociationType, bool IsReadOnly)
        {
            this.ElementName = ElementName;
            this.AssociationName = AssociationName;
            this.AssociationType = AssociationType;
            this.IsReadOnly = IsReadOnly;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ElementName, AssociationName, AssociationType, IsReadOnly };
        }

        public override void SetItemArray(object[] items)
        {
            ElementName = (string)items[0];
            AssociationName = (string)items[1];
            AssociationType = (string)items[2];
            IsReadOnly = (bool)items[3];
        }
    }

    [SqlRecord("SqlDom", "Element")]
    public partial class Element : SqlTableTypeProxy<Element>
    {
        [SqlColumn("ElementName", 0), SqlTypeFacets("varchar", false, 250)]
        public string ElementName
        {
            get;
            set;
        }

        [SqlColumn("ParentName", 1), SqlTypeFacets("varchar", true, 250)]
        public string ParentName
        {
            get;
            set;
        }

        [SqlColumn("IsAbstract", 2), SqlTypeFacets("bit", false)]
        public bool IsAbstract
        {
            get;
            set;
        }

        [SqlColumn("ElementType", 3), SqlTypeFacets("nvarchar", false, 75)]
        public string ElementType
        {
            get;
            set;
        }

        public Element()
        {
        }

        public Element(object[] items)
        {
            ElementName = (string)items[0];
            ParentName = (string)items[1];
            IsAbstract = (bool)items[2];
            ElementType = (string)items[3];
        }

        public Element(string ElementName, string ParentName, bool IsAbstract, string ElementType)
        {
            this.ElementName = ElementName;
            this.ParentName = ParentName;
            this.IsAbstract = IsAbstract;
            this.ElementType = ElementType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ElementName, ParentName, IsAbstract, ElementType };
        }

        public override void SetItemArray(object[] items)
        {
            ElementName = (string)items[0];
            ParentName = (string)items[1];
            IsAbstract = (bool)items[2];
            ElementType = (string)items[3];
        }
    }

    [SqlRecord("SqlDom", "EnumLiteral")]
    public partial class EnumLiteral : SqlTableTypeProxy<EnumLiteral>
    {
        [SqlColumn("EnumName", 0), SqlTypeFacets("varchar", true, 250)]
        public string EnumName
        {
            get;
            set;
        }

        [SqlColumn("LiteralName", 1), SqlTypeFacets("varchar", true, 250)]
        public string LiteralName
        {
            get;
            set;
        }

        [SqlColumn("LiteralValue", 2), SqlTypeFacets("int", true)]
        public int? LiteralValue
        {
            get;
            set;
        }

        public EnumLiteral()
        {
        }

        public EnumLiteral(object[] items)
        {
            EnumName = (string)items[0];
            LiteralName = (string)items[1];
            LiteralValue = (int?)items[2];
        }

        public EnumLiteral(string EnumName, string LiteralName, int? LiteralValue)
        {
            this.EnumName = EnumName;
            this.LiteralName = LiteralName;
            this.LiteralValue = LiteralValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EnumName, LiteralName, LiteralValue };
        }

        public override void SetItemArray(object[] items)
        {
            EnumName = (string)items[0];
            LiteralName = (string)items[1];
            LiteralValue = (int?)items[2];
        }
    }

    [SqlRecord("SqlDom", "ScriptDocument")]
    public partial class ScriptDocument : SqlTableTypeProxy<ScriptDocument>
    {
        [SqlColumn("ScriptName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ScriptName
        {
            get;
            set;
        }

        [SqlColumn("ScriptText", 1), SqlTypeFacets("nvarchar", false, 0)]
        public string ScriptText
        {
            get;
            set;
        }

        public ScriptDocument()
        {
        }

        public ScriptDocument(object[] items)
        {
            ScriptName = (string)items[0];
            ScriptText = (string)items[1];
        }

        public ScriptDocument(string ScriptName, string ScriptText)
        {
            this.ScriptName = ScriptName;
            this.ScriptText = ScriptText;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ScriptName, ScriptText };
        }

        public override void SetItemArray(object[] items)
        {
            ScriptName = (string)items[0];
            ScriptText = (string)items[1];
        }
    }

    [SqlRecord("SqlDom", "AttributeValue")]
    public partial class AttributeValue : SqlTableTypeProxy<AttributeValue>
    {
        [SqlColumn("ElementName", 0), SqlTypeFacets("varchar", false, 250)]
        public string ElementName
        {
            get;
            set;
        }

        [SqlColumn("AttributeName", 1), SqlTypeFacets("varchar", false, 250)]
        public string AttributeName
        {
            get;
            set;
        }

        [SqlColumn("AttributeValue", 2), SqlTypeFacets("varchar", false, 250)]
        public string AttributeValueColumn
        {
            get;
            set;
        }

        public AttributeValue()
        {
        }

        public AttributeValue(object[] items)
        {
            ElementName = (string)items[0];
            AttributeName = (string)items[1];
            AttributeValueColumn = (string)items[2];
        }

        public AttributeValue(string ElementName, string AttributeName, string AttributeValueColumn)
        {
            this.ElementName = ElementName;
            this.AttributeName = AttributeName;
            this.AttributeValueColumn = AttributeValueColumn;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ElementName, AttributeName, AttributeValueColumn };
        }

        public override void SetItemArray(object[] items)
        {
            ElementName = (string)items[0];
            AttributeName = (string)items[1];
            AttributeValueColumn = (string)items[2];
        }
    }

    [SqlView("SqlDom", "ElementMember")]
    public partial class ElementMember : SqlViewProxy
    {
        [SqlColumn("ElementName", 0), SqlTypeFacets("varchar", false, 250)]
        public string ElementName
        {
            get;
            set;
        }

        [SqlColumn("MemberIndex", 1), SqlTypeFacets("bigint", true)]
        public long? MemberIndex
        {
            get;
            set;
        }

        [SqlColumn("MemberName", 2), SqlTypeFacets("varchar", false, 250)]
        public string MemberName
        {
            get;
            set;
        }

        [SqlColumn("MemberType", 3), SqlTypeFacets("varchar", true, 250)]
        public string MemberType
        {
            get;
            set;
        }

        [SqlColumn("IsAttribute", 4), SqlTypeFacets("int", false)]
        public int IsAttribute
        {
            get;
            set;
        }

        [SqlColumn("IsAssociation", 5), SqlTypeFacets("int", false)]
        public int IsAssociation
        {
            get;
            set;
        }

        [SqlColumn("IsCollection", 6), SqlTypeFacets("int", false)]
        public int IsCollection
        {
            get;
            set;
        }

        [SqlColumn("IsEnumLiteral", 7), SqlTypeFacets("int", false)]
        public int IsEnumLiteral
        {
            get;
            set;
        }

        [SqlColumn("IsReadOnly", 8), SqlTypeFacets("int", false)]
        public int IsReadOnly
        {
            get;
            set;
        }

        public ElementMember()
        {
        }

        public ElementMember(object[] items)
        {
            ElementName = (string)items[0];
            MemberIndex = (long?)items[1];
            MemberName = (string)items[2];
            MemberType = (string)items[3];
            IsAttribute = (int)items[4];
            IsAssociation = (int)items[5];
            IsCollection = (int)items[6];
            IsEnumLiteral = (int)items[7];
            IsReadOnly = (int)items[8];
        }

        public ElementMember(string ElementName, long? MemberIndex, string MemberName, string MemberType, int IsAttribute, int IsAssociation, int IsCollection, int IsEnumLiteral, int IsReadOnly)
        {
            this.ElementName = ElementName;
            this.MemberIndex = MemberIndex;
            this.MemberName = MemberName;
            this.MemberType = MemberType;
            this.IsAttribute = IsAttribute;
            this.IsAssociation = IsAssociation;
            this.IsCollection = IsCollection;
            this.IsEnumLiteral = IsEnumLiteral;
            this.IsReadOnly = IsReadOnly;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ElementName, MemberIndex, MemberName, MemberType, IsAttribute, IsAssociation, IsCollection, IsEnumLiteral, IsReadOnly };
        }

        public override void SetItemArray(object[] items)
        {
            ElementName = (string)items[0];
            MemberIndex = (long?)items[1];
            MemberName = (string)items[2];
            MemberType = (string)items[3];
            IsAttribute = (int)items[4];
            IsAssociation = (int)items[5];
            IsCollection = (int)items[6];
            IsEnumLiteral = (int)items[7];
            IsReadOnly = (int)items[8];
        }
    }

    [SqlView("SqlDom", "ElementLineage")]
    public partial class ElementLineage : SqlViewProxy
    {
        [SqlColumn("ElementName", 0), SqlTypeFacets("varchar", true, 250)]
        public string ElementName
        {
            get;
            set;
        }

        [SqlColumn("ParentName", 1), SqlTypeFacets("varchar", true, 250)]
        public string ParentName
        {
            get;
            set;
        }

        [SqlColumn("ParentAncestor", 2), SqlTypeFacets("varchar", true, 250)]
        public string ParentAncestor
        {
            get;
            set;
        }

        [SqlColumn("IsAbstract", 3), SqlTypeFacets("bit", true)]
        public bool? IsAbstract
        {
            get;
            set;
        }

        public ElementLineage()
        {
        }

        public ElementLineage(object[] items)
        {
            ElementName = (string)items[0];
            ParentName = (string)items[1];
            ParentAncestor = (string)items[2];
            IsAbstract = (bool?)items[3];
        }

        public ElementLineage(string ElementName, string ParentName, string ParentAncestor, bool? IsAbstract)
        {
            this.ElementName = ElementName;
            this.ParentName = ParentName;
            this.ParentAncestor = ParentAncestor;
            this.IsAbstract = IsAbstract;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ElementName, ParentName, ParentAncestor, IsAbstract };
        }

        public override void SetItemArray(object[] items)
        {
            ElementName = (string)items[0];
            ParentName = (string)items[1];
            ParentAncestor = (string)items[2];
            IsAbstract = (bool?)items[3];
        }
    }

    [SqlView("SqlDom", "EnumElement")]
    public partial class EnumElement : SqlViewProxy
    {
        [SqlColumn("EnumName", 0), SqlTypeFacets("varchar", false, 250)]
        public string EnumName
        {
            get;
            set;
        }

        [SqlColumn("LiteralName", 1), SqlTypeFacets("varchar", false, 250)]
        public string LiteralName
        {
            get;
            set;
        }

        [SqlColumn("ElementType", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string ElementType
        {
            get;
            set;
        }

        [SqlColumn("IsNaturalDefault", 3), SqlTypeFacets("bit", true)]
        public bool? IsNaturalDefault
        {
            get;
            set;
        }

        public EnumElement()
        {
        }

        public EnumElement(object[] items)
        {
            EnumName = (string)items[0];
            LiteralName = (string)items[1];
            ElementType = (string)items[2];
            IsNaturalDefault = (bool?)items[3];
        }

        public EnumElement(string EnumName, string LiteralName, string ElementType, bool? IsNaturalDefault)
        {
            this.EnumName = EnumName;
            this.LiteralName = LiteralName;
            this.ElementType = ElementType;
            this.IsNaturalDefault = IsNaturalDefault;
        }

        public override object[] GetItemArray()
        {
            return new object[] { EnumName, LiteralName, ElementType, IsNaturalDefault };
        }

        public override void SetItemArray(object[] items)
        {
            EnumName = (string)items[0];
            LiteralName = (string)items[1];
            ElementType = (string)items[2];
            IsNaturalDefault = (bool?)items[3];
        }
    }
}
//This file was generated at 5/12/2018 8:42:08 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.Types.MC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class MCTableTypeNames
    {
        public readonly static SqlTableTypeName AreaDistribution = "[MC].[AreaDistribution]";
        public readonly static SqlTableTypeName CoreDataTypeInfo = "[MC].[CoreDataTypeInfo]";
        public readonly static SqlTableTypeName DistributionMoniker = "[MC].[DistributionMoniker]";
        public readonly static SqlTableTypeName Facet = "[MC].[Facet]";
        public readonly static SqlTableTypeName ProjectDefinition = "[MC].[ProjectDefinition]";
        public readonly static SqlTableTypeName ProjectVariable = "[MC].[ProjectVariable]";
        public readonly static SqlTableTypeName SolutionDefinition = "[MC].[SolutionDefinition]";
        public readonly static SqlTableTypeName ToolRegistration = "[MC].[ToolRegistration]";
        public readonly static SqlTableTypeName XsdDocument = "[MC].[XsdDocument]";
    }

    /// <summary>
    /// Identifies an executable used for system build/construction or operational purposes
    /// </summary>
    [SqlRecord("MC", "ToolRegistration")]
    public partial class ToolRegistration : SqlTableTypeProxy<ToolRegistration>
    {
        [SqlColumn("ToolId", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string ToolId
        {
            get;
            set;
        }

        [SqlColumn("ExecutableName", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string ExecutableName
        {
            get;
            set;
        }

        [SqlColumn("ExecutablePath", 2), SqlTypeFacets("nvarchar", true, 250)]
        public string ExecutablePath
        {
            get;
            set;
        }

        public ToolRegistration()
        {
        }

        public ToolRegistration(object[] items)
        {
            ToolId = (string)items[0];
            ExecutableName = (string)items[1];
            ExecutablePath = (string)items[2];
        }

        public ToolRegistration(string ToolId, string ExecutableName, string ExecutablePath)
        {
            this.ToolId = ToolId;
            this.ExecutableName = ExecutableName;
            this.ExecutablePath = ExecutablePath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ToolId, ExecutableName, ExecutablePath };
        }

        public override void SetItemArray(object[] items)
        {
            ToolId = (string)items[0];
            ExecutableName = (string)items[1];
            ExecutablePath = (string)items[2];
        }
    }

    [SqlRecord("MC", "DistributionMoniker")]
    public partial class DistributionMoniker : SqlTableTypeProxy<DistributionMoniker>
    {
        [SqlColumn("DistributionId", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string DistributionId
        {
            get;
            set;
        }

        [SqlColumn("ContentType", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string ContentType
        {
            get;
            set;
        }

        [SqlColumn("ContentVersion", 2), SqlTypeFacets("nvarchar", true, 75)]
        public string ContentVersion
        {
            get;
            set;
        }

        public DistributionMoniker()
        {
        }

        public DistributionMoniker(object[] items)
        {
            DistributionId = (string)items[0];
            ContentType = (string)items[1];
            ContentVersion = (string)items[2];
        }

        public DistributionMoniker(string DistributionId, string ContentType, string ContentVersion)
        {
            this.DistributionId = DistributionId;
            this.ContentType = ContentType;
            this.ContentVersion = ContentVersion;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DistributionId, ContentType, ContentVersion };
        }

        public override void SetItemArray(object[] items)
        {
            DistributionId = (string)items[0];
            ContentType = (string)items[1];
            ContentVersion = (string)items[2];
        }
    }

    [SqlRecord("MC", "AreaDistribution")]
    public partial class AreaDistribution : SqlTableTypeProxy<AreaDistribution>
    {
        [SqlColumn("DistributionId", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string DistributionId
        {
            get;
            set;
        }

        [SqlColumn("DistributionType", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string DistributionType
        {
            get;
            set;
        }

        [SqlColumn("AreaId", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string AreaId
        {
            get;
            set;
        }

        public AreaDistribution()
        {
        }

        public AreaDistribution(object[] items)
        {
            DistributionId = (string)items[0];
            DistributionType = (string)items[1];
            AreaId = (string)items[2];
        }

        public AreaDistribution(string DistributionId, string DistributionType, string AreaId)
        {
            this.DistributionId = DistributionId;
            this.DistributionType = DistributionType;
            this.AreaId = AreaId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DistributionId, DistributionType, AreaId };
        }

        public override void SetItemArray(object[] items)
        {
            DistributionId = (string)items[0];
            DistributionType = (string)items[1];
            AreaId = (string)items[2];
        }
    }

    [SqlRecord("MC", "XsdDocument")]
    public partial class XsdDocument : SqlTableTypeProxy<XsdDocument>
    {
        [SqlColumn("SourcePath", 0), SqlTypeFacets("nvarchar", false, 250)]
        public string SourcePath
        {
            get;
            set;
        }

        [SqlColumn("DocumentName", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string DocumentName
        {
            get;
            set;
        }

        [SqlColumn("Processed", 2), SqlTypeFacets("bit", false)]
        public bool Processed
        {
            get;
            set;
        }

        [SqlColumn("ProcessingError", 3), SqlTypeFacets("nvarchar", true, 500)]
        public string ProcessingError
        {
            get;
            set;
        }

        [SqlColumn("XmlContent", 4), SqlTypeFacets("xml", false)]
        public string XmlContent
        {
            get;
            set;
        }

        public XsdDocument()
        {
        }

        public XsdDocument(object[] items)
        {
            SourcePath = (string)items[0];
            DocumentName = (string)items[1];
            Processed = (bool)items[2];
            ProcessingError = (string)items[3];
            XmlContent = (string)items[4];
        }

        public XsdDocument(string SourcePath, string DocumentName, bool Processed, string ProcessingError, string XmlContent)
        {
            this.SourcePath = SourcePath;
            this.DocumentName = DocumentName;
            this.Processed = Processed;
            this.ProcessingError = ProcessingError;
            this.XmlContent = XmlContent;
        }

        public override object[] GetItemArray()
        {
            return new object[] { SourcePath, DocumentName, Processed, ProcessingError, XmlContent };
        }

        public override void SetItemArray(object[] items)
        {
            SourcePath = (string)items[0];
            DocumentName = (string)items[1];
            Processed = (bool)items[2];
            ProcessingError = (string)items[3];
            XmlContent = (string)items[4];
        }
    }

    [SqlRecord("MC", "SolutionDefinition")]
    public partial class SolutionDefinition : SqlTableTypeProxy<SolutionDefinition>
    {
        [SqlColumn("AreaId", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string AreaId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("SolutionId", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string SolutionId
        {
            get;
            set;
        }

        [SqlColumn("SolutionName", 3), SqlTypeFacets("nvarchar", false, 250)]
        public string SolutionName
        {
            get;
            set;
        }

        public SolutionDefinition()
        {
        }

        public SolutionDefinition(object[] items)
        {
            AreaId = (string)items[0];
            SystemId = (string)items[1];
            SolutionId = (string)items[2];
            SolutionName = (string)items[3];
        }

        public SolutionDefinition(string AreaId, string SystemId, string SolutionId, string SolutionName)
        {
            this.AreaId = AreaId;
            this.SystemId = SystemId;
            this.SolutionId = SolutionId;
            this.SolutionName = SolutionName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { AreaId, SystemId, SolutionId, SolutionName };
        }

        public override void SetItemArray(object[] items)
        {
            AreaId = (string)items[0];
            SystemId = (string)items[1];
            SolutionId = (string)items[2];
            SolutionName = (string)items[3];
        }
    }

    [SqlRecord("MC", "Facet")]
    public partial class Facet : SqlTableTypeProxy<Facet>
    {
        [SqlColumn("FacetName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string FacetName
        {
            get;
            set;
        }

        [SqlColumn("FacetValue", 1), SqlTypeFacets("nvarchar", true, 250)]
        public string FacetValue
        {
            get;
            set;
        }

        public Facet()
        {
        }

        public Facet(object[] items)
        {
            FacetName = (string)items[0];
            FacetValue = (string)items[1];
        }

        public Facet(string FacetName, string FacetValue)
        {
            this.FacetName = FacetName;
            this.FacetValue = FacetValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FacetName, FacetValue };
        }

        public override void SetItemArray(object[] items)
        {
            FacetName = (string)items[0];
            FacetValue = (string)items[1];
        }
    }

    [SqlRecord("MC", "ProjectVariable")]
    public partial class ProjectVariable : SqlTableTypeProxy<ProjectVariable>
    {
        [SqlColumn("ProjectId", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string ProjectId
        {
            get;
            set;
        }

        [SqlColumn("VariableName", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string VariableName
        {
            get;
            set;
        }

        [SqlColumn("VariableValue", 2), SqlTypeFacets("nvarchar", false, 1024)]
        public string VariableValue
        {
            get;
            set;
        }

        public ProjectVariable()
        {
        }

        public ProjectVariable(object[] items)
        {
            ProjectId = (string)items[0];
            VariableName = (string)items[1];
            VariableValue = (string)items[2];
        }

        public ProjectVariable(string ProjectId, string VariableName, string VariableValue)
        {
            this.ProjectId = ProjectId;
            this.VariableName = VariableName;
            this.VariableValue = VariableValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ProjectId, VariableName, VariableValue };
        }

        public override void SetItemArray(object[] items)
        {
            ProjectId = (string)items[0];
            VariableName = (string)items[1];
            VariableValue = (string)items[2];
        }
    }

    [SqlRecord("MC", "CoreDataTypeInfo")]
    public partial class CoreDataTypeInfo : SqlTableTypeProxy<CoreDataTypeInfo>
    {
        [SqlColumn("DataTypeName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string DataTypeName
        {
            get;
            set;
        }

        [SqlColumn("ClrTypeName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ClrTypeName
        {
            get;
            set;
        }

        [SqlColumn("IsInteger", 2), SqlTypeFacets("bit", false)]
        public bool IsInteger
        {
            get;
            set;
        }

        [SqlColumn("IsText", 3), SqlTypeFacets("bit", false)]
        public bool IsText
        {
            get;
            set;
        }

        [SqlColumn("IsBoolean", 4), SqlTypeFacets("bit", false)]
        public bool IsBoolean
        {
            get;
            set;
        }

        [SqlColumn("IsTemporal", 5), SqlTypeFacets("bit", false)]
        public bool IsTemporal
        {
            get;
            set;
        }

        [SqlColumn("CanSpecifyLength", 6), SqlTypeFacets("bit", false)]
        public bool CanSpecifyLength
        {
            get;
            set;
        }

        [SqlColumn("CanSpecifyPrecision", 7), SqlTypeFacets("bit", false)]
        public bool CanSpecifyPrecision
        {
            get;
            set;
        }

        [SqlColumn("CanSpecifyScale", 8), SqlTypeFacets("bit", false)]
        public bool CanSpecifyScale
        {
            get;
            set;
        }

        public CoreDataTypeInfo()
        {
        }

        public CoreDataTypeInfo(object[] items)
        {
            DataTypeName = (string)items[0];
            ClrTypeName = (string)items[1];
            IsInteger = (bool)items[2];
            IsText = (bool)items[3];
            IsBoolean = (bool)items[4];
            IsTemporal = (bool)items[5];
            CanSpecifyLength = (bool)items[6];
            CanSpecifyPrecision = (bool)items[7];
            CanSpecifyScale = (bool)items[8];
        }

        public CoreDataTypeInfo(string DataTypeName, string ClrTypeName, bool IsInteger, bool IsText, bool IsBoolean, bool IsTemporal, bool CanSpecifyLength, bool CanSpecifyPrecision, bool CanSpecifyScale)
        {
            this.DataTypeName = DataTypeName;
            this.ClrTypeName = ClrTypeName;
            this.IsInteger = IsInteger;
            this.IsText = IsText;
            this.IsBoolean = IsBoolean;
            this.IsTemporal = IsTemporal;
            this.CanSpecifyLength = CanSpecifyLength;
            this.CanSpecifyPrecision = CanSpecifyPrecision;
            this.CanSpecifyScale = CanSpecifyScale;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DataTypeName, ClrTypeName, IsInteger, IsText, IsBoolean, IsTemporal, CanSpecifyLength, CanSpecifyPrecision, CanSpecifyScale };
        }

        public override void SetItemArray(object[] items)
        {
            DataTypeName = (string)items[0];
            ClrTypeName = (string)items[1];
            IsInteger = (bool)items[2];
            IsText = (bool)items[3];
            IsBoolean = (bool)items[4];
            IsTemporal = (bool)items[5];
            CanSpecifyLength = (bool)items[6];
            CanSpecifyPrecision = (bool)items[7];
            CanSpecifyScale = (bool)items[8];
        }
    }

    [SqlRecord("MC", "ProjectDefinition")]
    public partial class ProjectDefinition : SqlTableTypeProxy<ProjectDefinition>
    {
        [SqlColumn("AreaId", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string AreaId
        {
            get;
            set;
        }

        [SqlColumn("SystemId", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string SystemId
        {
            get;
            set;
        }

        [SqlColumn("ProjectId", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string ProjectId
        {
            get;
            set;
        }

        [SqlColumn("ProjectType", 3), SqlTypeFacets("nvarchar", false, 75)]
        public string ProjectType
        {
            get;
            set;
        }

        [SqlColumn("ProjectName", 4), SqlTypeFacets("nvarchar", false, 250)]
        public string ProjectName
        {
            get;
            set;
        }

        public ProjectDefinition()
        {
        }

        public ProjectDefinition(object[] items)
        {
            AreaId = (string)items[0];
            SystemId = (string)items[1];
            ProjectId = (string)items[2];
            ProjectType = (string)items[3];
            ProjectName = (string)items[4];
        }

        public ProjectDefinition(string AreaId, string SystemId, string ProjectId, string ProjectType, string ProjectName)
        {
            this.AreaId = AreaId;
            this.SystemId = SystemId;
            this.ProjectId = ProjectId;
            this.ProjectType = ProjectType;
            this.ProjectName = ProjectName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { AreaId, SystemId, ProjectId, ProjectType, ProjectName };
        }

        public override void SetItemArray(object[] items)
        {
            AreaId = (string)items[0];
            SystemId = (string)items[1];
            ProjectId = (string)items[2];
            ProjectType = (string)items[3];
            ProjectName = (string)items[4];
        }
    }

    public enum ProjectKind : byte
    {
        /// <summary>
        /// Specifies the absence of classification
        /// </summary>
        [Description("Specifies the absence of classification")]
        None = 0,
        /// <summary>
        /// Identifies a class library project
        /// </summary>
        [Description("Identifies a class library project")]
        Library = 1,
        /// <summary>
        /// Identifies a console project
        /// </summary>
        [Description("Identifies a console project")]
        Console = 2,
        /// <summary>
        /// Identifies a sql project
        /// </summary>
        [Description("Identifies a sql project")]
        Sql = 3
    }

    public enum DistributionKind : byte
    {
        /// <summary>
        /// Denotes the absence of a classification
        /// </summary>
        [Description("Denotes the absence of a classification")]
        None = 0,
        /// <summary>
        /// A library distribution
        /// </summary>
        [Description("A library distribution")]
        Library = 1,
        /// <summary>
        /// An executable distribution
        /// </summary>
        [Description("An executable distribution")]
        Executable = 2,
        /// <summary>
        /// A sql package distribution
        /// </summary>
        [Description("A sql package distribution")]
        SqlPackage = 3
    }
}
//This file was generated at 5/12/2018 8:42:08 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.Types
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SqlTViewNames
    {
        public readonly static SqlViewName TableStatsView = "[SqlT].[TableStatsView]";
        public readonly static SqlViewName TimeZoneDescriptor = "[SqlT].[TimeZoneDescriptor]";
    }

    public sealed class SqlTTableTypeNames
    {
        public readonly static SqlTableTypeName BackupDescription = "[SqlT].[BackupDescription]";
        public readonly static SqlTableTypeName ColumnComparison = "[SqlT].[ColumnComparison]";
        public readonly static SqlTableTypeName ColumnDefinition = "[SqlT].[ColumnDefinition]";
        public readonly static SqlTableTypeName ColumnFacet = "[SqlT].[ColumnFacet]";
        public readonly static SqlTableTypeName ColumnGroupMember = "[SqlT].[ColumnGroupMember]";
        public readonly static SqlTableTypeName ColumnRoleAssignment = "[SqlT].[ColumnRoleAssignment]";
        public readonly static SqlTableTypeName Database = "[SqlT].[Database]";
        public readonly static SqlTableTypeName DataTypeDescription = "[SqlT].[DataTypeDescription]";
        public readonly static SqlTableTypeName DefaultFilePath = "[SqlT].[DefaultFilePath]";
        public readonly static SqlTableTypeName FileSystemEntry = "[SqlT].[FileSystemEntry]";
        public readonly static SqlTableTypeName FileTableDescription = "[SqlT].[FileTableDescription]";
        public readonly static SqlTableTypeName ForeignKey = "[SqlT].[ForeignKey]";
        public readonly static SqlTableTypeName ForeignKeyColumn = "[SqlT].[ForeignKeyColumn]";
        public readonly static SqlTableTypeName ForeignKeyInfo = "[SqlT].[ForeignKeyInfo]";
        public readonly static SqlTableTypeName LargeTypeTable = "[SqlT].[LargeTypeTable]";
        public readonly static SqlTableTypeName ObjectFacet = "[SqlT].[ObjectFacet]";
        public readonly static SqlTableTypeName PrimaryKey = "[SqlT].[PrimaryKey]";
        public readonly static SqlTableTypeName PrimaryKeyColumn = "[SqlT].[PrimaryKeyColumn]";
        public readonly static SqlTableTypeName ProxyFieldList = "[SqlT].[ProxyFieldList]";
        public readonly static SqlTableTypeName ProxyGenerationSpec = "[SqlT].[ProxyGenerationSpec]";
        public readonly static SqlTableTypeName ProxyProfileDefinition = "[SqlT].[ProxyProfileDefinition]";
        public readonly static SqlTableTypeName ServerCollation = "[SqlT].[ServerCollation]";
        public readonly static SqlTableTypeName SmallTypeTable = "[SqlT].[SmallTypeTable]";
        public readonly static SqlTableTypeName SystemDataType = "[SqlT].[SystemDataType]";
        public readonly static SqlTableTypeName TableColumn = "[SqlT].[TableColumn]";
        public readonly static SqlTableTypeName TableDescription = "[SqlT].[TableDescription]";
        public readonly static SqlTableTypeName TableQuery = "[SqlT].[TableQuery]";
        public readonly static SqlTableTypeName TableQueryColumn = "[SqlT].[TableQueryColumn]";
        public readonly static SqlTableTypeName TableRowCount = "[SqlT].[TableRowCount]";
        public readonly static SqlTableTypeName TableStats = "[SqlT].[TableStats]";
        public readonly static SqlTableTypeName TableType = "[SqlT].[TableType]";
        public readonly static SqlTableTypeName TinyTypeTable = "[SqlT].[TinyTypeTable]";
        public readonly static SqlTableTypeName TypeTable = "[SqlT].[TypeTable]";
        public readonly static SqlTableTypeName UserDataType = "[SqlT].[UserDataType]";
    }

    [SqlRecord("SqlT", "ColumnRoleAssignment")]
    public partial class ColumnRoleAssignment : SqlTableTypeProxy<ColumnRoleAssignment>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ObjectSchema", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectSchema
        {
            get;
            set;
        }

        [SqlColumn("ObjectName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnRole", 5), SqlTypeFacets("nvarchar", false, 75)]
        public string ColumnRole
        {
            get;
            set;
        }

        public ColumnRoleAssignment()
        {
        }

        public ColumnRoleAssignment(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ObjectSchema = (string)items[2];
            ObjectName = (string)items[3];
            ColumnName = (string)items[4];
            ColumnRole = (string)items[5];
        }

        public ColumnRoleAssignment(string ServerName, string DatabaseName, string ObjectSchema, string ObjectName, string ColumnName, string ColumnRole)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ObjectSchema = ObjectSchema;
            this.ObjectName = ObjectName;
            this.ColumnName = ColumnName;
            this.ColumnRole = ColumnRole;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, ObjectSchema, ObjectName, ColumnName, ColumnRole };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ObjectSchema = (string)items[2];
            ObjectName = (string)items[3];
            ColumnName = (string)items[4];
            ColumnRole = (string)items[5];
        }
    }

    [SqlRecord("SqlT", "ForeignKeyColumn")]
    public partial class ForeignKeyColumn : SqlTableTypeProxy<ForeignKeyColumn>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("sysname", true)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ForeignKeySchema", 2), SqlTypeFacets("sysname", true)]
        public string ForeignKeySchema
        {
            get;
            set;
        }

        [SqlColumn("ForeignKeyName", 3), SqlTypeFacets("sysname", true)]
        public string ForeignKeyName
        {
            get;
            set;
        }

        [SqlColumn("ClientTableSchema", 4), SqlTypeFacets("sysname", true)]
        public string ClientTableSchema
        {
            get;
            set;
        }

        [SqlColumn("ClientTableName", 5), SqlTypeFacets("sysname", true)]
        public string ClientTableName
        {
            get;
            set;
        }

        [SqlColumn("SupplierTableSchema", 6), SqlTypeFacets("sysname", true)]
        public string SupplierTableSchema
        {
            get;
            set;
        }

        [SqlColumn("SupplierTableName", 7), SqlTypeFacets("sysname", true)]
        public string SupplierTableName
        {
            get;
            set;
        }

        [SqlColumn("KeyColumnId", 8), SqlTypeFacets("int", false)]
        public int KeyColumnId
        {
            get;
            set;
        }

        [SqlColumn("ClientColumnName", 9), SqlTypeFacets("sysname", true)]
        public string ClientColumnName
        {
            get;
            set;
        }

        [SqlColumn("ClientColummnId", 10), SqlTypeFacets("int", false)]
        public int ClientColummnId
        {
            get;
            set;
        }

        [SqlColumn("SupplierColumnName", 11), SqlTypeFacets("sysname", true)]
        public string SupplierColumnName
        {
            get;
            set;
        }

        [SqlColumn("SupplierColumnId", 12), SqlTypeFacets("int", false)]
        public int SupplierColumnId
        {
            get;
            set;
        }

        public ForeignKeyColumn()
        {
        }

        public ForeignKeyColumn(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ForeignKeySchema = (string)items[2];
            ForeignKeyName = (string)items[3];
            ClientTableSchema = (string)items[4];
            ClientTableName = (string)items[5];
            SupplierTableSchema = (string)items[6];
            SupplierTableName = (string)items[7];
            KeyColumnId = (int)items[8];
            ClientColumnName = (string)items[9];
            ClientColummnId = (int)items[10];
            SupplierColumnName = (string)items[11];
            SupplierColumnId = (int)items[12];
        }

        public ForeignKeyColumn(string ServerName, string DatabaseName, string ForeignKeySchema, string ForeignKeyName, string ClientTableSchema, string ClientTableName, string SupplierTableSchema, string SupplierTableName, int KeyColumnId, string ClientColumnName, int ClientColummnId, string SupplierColumnName, int SupplierColumnId)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ForeignKeySchema = ForeignKeySchema;
            this.ForeignKeyName = ForeignKeyName;
            this.ClientTableSchema = ClientTableSchema;
            this.ClientTableName = ClientTableName;
            this.SupplierTableSchema = SupplierTableSchema;
            this.SupplierTableName = SupplierTableName;
            this.KeyColumnId = KeyColumnId;
            this.ClientColumnName = ClientColumnName;
            this.ClientColummnId = ClientColummnId;
            this.SupplierColumnName = SupplierColumnName;
            this.SupplierColumnId = SupplierColumnId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, ForeignKeySchema, ForeignKeyName, ClientTableSchema, ClientTableName, SupplierTableSchema, SupplierTableName, KeyColumnId, ClientColumnName, ClientColummnId, SupplierColumnName, SupplierColumnId };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ForeignKeySchema = (string)items[2];
            ForeignKeyName = (string)items[3];
            ClientTableSchema = (string)items[4];
            ClientTableName = (string)items[5];
            SupplierTableSchema = (string)items[6];
            SupplierTableName = (string)items[7];
            KeyColumnId = (int)items[8];
            ClientColumnName = (string)items[9];
            ClientColummnId = (int)items[10];
            SupplierColumnName = (string)items[11];
            SupplierColumnId = (int)items[12];
        }
    }

    [SqlRecord("SqlT", "ForeignKey")]
    public partial class ForeignKey : SqlTableTypeProxy<ForeignKey>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("sysname", true)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ForeignKeySchema", 2), SqlTypeFacets("sysname", true)]
        public string ForeignKeySchema
        {
            get;
            set;
        }

        [SqlColumn("ForeignKeyName", 3), SqlTypeFacets("sysname", true)]
        public string ForeignKeyName
        {
            get;
            set;
        }

        [SqlColumn("ClientTableSchema", 4), SqlTypeFacets("sysname", true)]
        public string ClientTableSchema
        {
            get;
            set;
        }

        [SqlColumn("ClientTableName", 5), SqlTypeFacets("sysname", true)]
        public string ClientTableName
        {
            get;
            set;
        }

        [SqlColumn("SupplierTableSchema", 6), SqlTypeFacets("sysname", true)]
        public string SupplierTableSchema
        {
            get;
            set;
        }

        [SqlColumn("SupplierTableName", 7), SqlTypeFacets("sysname", true)]
        public string SupplierTableName
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 8), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public ForeignKey()
        {
        }

        public ForeignKey(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ForeignKeySchema = (string)items[2];
            ForeignKeyName = (string)items[3];
            ClientTableSchema = (string)items[4];
            ClientTableName = (string)items[5];
            SupplierTableSchema = (string)items[6];
            SupplierTableName = (string)items[7];
            Documentation = (string)items[8];
        }

        public ForeignKey(string ServerName, string DatabaseName, string ForeignKeySchema, string ForeignKeyName, string ClientTableSchema, string ClientTableName, string SupplierTableSchema, string SupplierTableName, string Documentation)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ForeignKeySchema = ForeignKeySchema;
            this.ForeignKeyName = ForeignKeyName;
            this.ClientTableSchema = ClientTableSchema;
            this.ClientTableName = ClientTableName;
            this.SupplierTableSchema = SupplierTableSchema;
            this.SupplierTableName = SupplierTableName;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, ForeignKeySchema, ForeignKeyName, ClientTableSchema, ClientTableName, SupplierTableSchema, SupplierTableName, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ForeignKeySchema = (string)items[2];
            ForeignKeyName = (string)items[3];
            ClientTableSchema = (string)items[4];
            ClientTableName = (string)items[5];
            SupplierTableSchema = (string)items[6];
            SupplierTableName = (string)items[7];
            Documentation = (string)items[8];
        }
    }

    [SqlRecord("SqlT", "DataTypeDescription")]
    public partial class DataTypeDescription : SqlTableTypeProxy<DataTypeDescription>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("IsUserDefined", 4), SqlTypeFacets("bit", false)]
        public bool IsUserDefined
        {
            get;
            set;
        }

        [SqlColumn("MaxLength", 5), SqlTypeFacets("smallint", false)]
        public short MaxLength
        {
            get;
            set;
        }

        [SqlColumn("Precision", 6), SqlTypeFacets("tinyint", false)]
        public byte Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 7), SqlTypeFacets("tinyint", false)]
        public byte Scale
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 8), SqlTypeFacets("bit", true)]
        public bool? IsNullable
        {
            get;
            set;
        }

        [SqlColumn("IsClrType", 9), SqlTypeFacets("bit", false)]
        public bool IsClrType
        {
            get;
            set;
        }

        public DataTypeDescription()
        {
        }

        public DataTypeDescription(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TypeName = (string)items[3];
            IsUserDefined = (bool)items[4];
            MaxLength = (short)items[5];
            Precision = (byte)items[6];
            Scale = (byte)items[7];
            IsNullable = (bool?)items[8];
            IsClrType = (bool)items[9];
        }

        public DataTypeDescription(string ServerName, string DatabaseName, string SchemaName, string TypeName, bool IsUserDefined, short MaxLength, byte Precision, byte Scale, bool? IsNullable, bool IsClrType)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TypeName = TypeName;
            this.IsUserDefined = IsUserDefined;
            this.MaxLength = MaxLength;
            this.Precision = Precision;
            this.Scale = Scale;
            this.IsNullable = IsNullable;
            this.IsClrType = IsClrType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, SchemaName, TypeName, IsUserDefined, MaxLength, Precision, Scale, IsNullable, IsClrType };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TypeName = (string)items[3];
            IsUserDefined = (bool)items[4];
            MaxLength = (short)items[5];
            Precision = (byte)items[6];
            Scale = (byte)items[7];
            IsNullable = (bool?)items[8];
            IsClrType = (bool)items[9];
        }
    }

    [SqlRecord("SqlT", "TypeTable")]
    public partial class TypeTable : SqlTableTypeProxy<TypeTable>
    {
        [SqlColumn("Identifier", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 1), SqlTypeFacets("nvarchar", true, 75)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 2), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public TypeTable()
        {
        }

        public TypeTable(object[] items)
        {
            Identifier = (string)items[0];
            Label = (string)items[1];
            Description = (string)items[2];
        }

        public TypeTable(string Identifier, string Label, string Description)
        {
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Identifier, Label, Description };
        }

        public override void SetItemArray(object[] items)
        {
            Identifier = (string)items[0];
            Label = (string)items[1];
            Description = (string)items[2];
        }
    }

    [SqlRecord("SqlT", "TinyTypeTable")]
    public partial class TinyTypeTable : SqlTableTypeProxy<TinyTypeTable>
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("tinyint", false)]
        public byte TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 75)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public TinyTypeTable()
        {
        }

        public TinyTypeTable(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public TinyTypeTable(byte TypeCode, string Identifier, string Label, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (byte)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlRecord("SqlT", "TableQueryColumn")]
    public partial class TableQueryColumn : SqlTableTypeProxy<TableQueryColumn>
    {
        [SqlColumn("QueryName", 0), SqlTypeFacets("nvarchar", false, 250)]
        public string QueryName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 1), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 2), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("ColumnAlias", 3), SqlTypeFacets("nvarchar", true, 128)]
        public string ColumnAlias
        {
            get;
            set;
        }

        public TableQueryColumn()
        {
        }

        public TableQueryColumn(object[] items)
        {
            QueryName = (string)items[0];
            ColumnName = (string)items[1];
            ColumnPosition = (int)items[2];
            ColumnAlias = (string)items[3];
        }

        public TableQueryColumn(string QueryName, string ColumnName, int ColumnPosition, string ColumnAlias)
        {
            this.QueryName = QueryName;
            this.ColumnName = ColumnName;
            this.ColumnPosition = ColumnPosition;
            this.ColumnAlias = ColumnAlias;
        }

        public override object[] GetItemArray()
        {
            return new object[] { QueryName, ColumnName, ColumnPosition, ColumnAlias };
        }

        public override void SetItemArray(object[] items)
        {
            QueryName = (string)items[0];
            ColumnName = (string)items[1];
            ColumnPosition = (int)items[2];
            ColumnAlias = (string)items[3];
        }
    }

    [SqlRecord("SqlT", "TableQuery")]
    public partial class TableQuery : SqlTableTypeProxy<TableQuery>
    {
        [SqlColumn("QueryName", 0), SqlTypeFacets("nvarchar", false, 250)]
        public string QueryName
        {
            get;
            set;
        }

        [SqlColumn("TableCatalog", 1), SqlTypeFacets("sysname", true)]
        public string TableCatalog
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 2), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("TableAlias", 4), SqlTypeFacets("nvarchar", true, 128)]
        public string TableAlias
        {
            get;
            set;
        }

        public TableQuery()
        {
        }

        public TableQuery(object[] items)
        {
            QueryName = (string)items[0];
            TableCatalog = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            TableAlias = (string)items[4];
        }

        public TableQuery(string QueryName, string TableCatalog, string TableSchema, string TableName, string TableAlias)
        {
            this.QueryName = QueryName;
            this.TableCatalog = TableCatalog;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.TableAlias = TableAlias;
        }

        public override object[] GetItemArray()
        {
            return new object[] { QueryName, TableCatalog, TableSchema, TableName, TableAlias };
        }

        public override void SetItemArray(object[] items)
        {
            QueryName = (string)items[0];
            TableCatalog = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            TableAlias = (string)items[4];
        }
    }

    [SqlRecord("SqlT", "SmallTypeTable")]
    public partial class SmallTypeTable : SqlTableTypeProxy<SmallTypeTable>
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("smallint", false)]
        public short TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 75)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public SmallTypeTable()
        {
        }

        public SmallTypeTable(object[] items)
        {
            TypeCode = (short)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public SmallTypeTable(short TypeCode, string Identifier, string Label, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (short)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlRecord("SqlT", "ProxyGenerationSpec")]
    public partial class ProxyGenerationSpec : SqlTableTypeProxy<ProxyGenerationSpec>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("sysname", true)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ProfileName", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string ProfileName
        {
            get;
            set;
        }

        [SqlColumn("ProfileText", 3), SqlTypeFacets("nvarchar", false, 0)]
        public string ProfileText
        {
            get;
            set;
        }

        public ProxyGenerationSpec()
        {
        }

        public ProxyGenerationSpec(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ProfileName = (string)items[2];
            ProfileText = (string)items[3];
        }

        public ProxyGenerationSpec(string ServerName, string DatabaseName, string ProfileName, string ProfileText)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ProfileName = ProfileName;
            this.ProfileText = ProfileText;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, ProfileName, ProfileText };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ProfileName = (string)items[2];
            ProfileText = (string)items[3];
        }
    }

    [SqlRecord("SqlT", "LargeTypeTable")]
    public partial class LargeTypeTable : SqlTableTypeProxy<LargeTypeTable>
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("int", false)]
        public int TypeCode
        {
            get;
            set;
        }

        [SqlColumn("Identifier", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 2), SqlTypeFacets("nvarchar", true, 75)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("Description", 3), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public LargeTypeTable()
        {
        }

        public LargeTypeTable(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }

        public LargeTypeTable(int TypeCode, string Identifier, string Label, string Description)
        {
            this.TypeCode = TypeCode;
            this.Identifier = Identifier;
            this.Label = Label;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, Identifier, Label, Description };
        }

        public override void SetItemArray(object[] items)
        {
            TypeCode = (int)items[0];
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    [SqlRecord("SqlT", "FileSystemEntry")]
    public partial class FileSystemEntry : SqlTableTypeProxy<FileSystemEntry>
    {
        [SqlColumn("FilePath", 0), SqlTypeFacets("nvarchar", false, 4000)]
        public string FilePath
        {
            get;
            set;
        }

        [SqlColumn("IsDirectory", 1), SqlTypeFacets("bit", false)]
        public bool IsDirectory
        {
            get;
            set;
        }

        [SqlColumn("CreationTime", 2), SqlTypeFacets("datetime", false)]
        public DateTime CreationTime
        {
            get;
            set;
        }

        [SqlColumn("LastWriteTime", 3), SqlTypeFacets("datetime", false)]
        public DateTime LastWriteTime
        {
            get;
            set;
        }

        [SqlColumn("Size", 4), SqlTypeFacets("bigint", false)]
        public long Size
        {
            get;
            set;
        }

        public FileSystemEntry()
        {
        }

        public FileSystemEntry(object[] items)
        {
            FilePath = (string)items[0];
            IsDirectory = (bool)items[1];
            CreationTime = (DateTime)items[2];
            LastWriteTime = (DateTime)items[3];
            Size = (long)items[4];
        }

        public FileSystemEntry(string FilePath, bool IsDirectory, DateTime CreationTime, DateTime LastWriteTime, long Size)
        {
            this.FilePath = FilePath;
            this.IsDirectory = IsDirectory;
            this.CreationTime = CreationTime;
            this.LastWriteTime = LastWriteTime;
            this.Size = Size;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FilePath, IsDirectory, CreationTime, LastWriteTime, Size };
        }

        public override void SetItemArray(object[] items)
        {
            FilePath = (string)items[0];
            IsDirectory = (bool)items[1];
            CreationTime = (DateTime)items[2];
            LastWriteTime = (DateTime)items[3];
            Size = (long)items[4];
        }
    }

    [SqlRecord("SqlT", "DefaultFilePath")]
    public partial class DefaultFilePath : SqlTableTypeProxy<DefaultFilePath>
    {
        [SqlColumn("DefaultBackupPath", 0), SqlTypeFacets("nvarchar", false, 500)]
        public string DefaultBackupPath
        {
            get;
            set;
        }

        [SqlColumn("DefaultDataPath", 1), SqlTypeFacets("nvarchar", false, 500)]
        public string DefaultDataPath
        {
            get;
            set;
        }

        [SqlColumn("DefaultLogPath", 2), SqlTypeFacets("nvarchar", false, 500)]
        public string DefaultLogPath
        {
            get;
            set;
        }

        public DefaultFilePath()
        {
        }

        public DefaultFilePath(object[] items)
        {
            DefaultBackupPath = (string)items[0];
            DefaultDataPath = (string)items[1];
            DefaultLogPath = (string)items[2];
        }

        public DefaultFilePath(string DefaultBackupPath, string DefaultDataPath, string DefaultLogPath)
        {
            this.DefaultBackupPath = DefaultBackupPath;
            this.DefaultDataPath = DefaultDataPath;
            this.DefaultLogPath = DefaultLogPath;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DefaultBackupPath, DefaultDataPath, DefaultLogPath };
        }

        public override void SetItemArray(object[] items)
        {
            DefaultBackupPath = (string)items[0];
            DefaultDataPath = (string)items[1];
            DefaultLogPath = (string)items[2];
        }
    }

    [SqlRecord("SqlT", "TableRowCount")]
    public partial class TableRowCount : SqlTableTypeProxy<TableRowCount>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("RowCountValue", 4), SqlTypeFacets("int", false)]
        public int RowCountValue
        {
            get;
            set;
        }

        public TableRowCount()
        {
        }

        public TableRowCount(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            RowCountValue = (int)items[4];
        }

        public TableRowCount(string ServerName, string DatabaseName, string TableSchema, string TableName, int RowCountValue)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.RowCountValue = RowCountValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, TableSchema, TableName, RowCountValue };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            RowCountValue = (int)items[4];
        }
    }

    /// <summary>
    /// Specifies the shape of the result set returned when executing RESTORE with the filelistonly option
    /// </summary>
    [SqlRecord("SqlT", "BackupDescription")]
    public partial class BackupDescription : SqlTableTypeProxy<BackupDescription>
    {
        [SqlColumn("LogicalName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string LogicalName
        {
            get;
            set;
        }

        [SqlColumn("PhysicalName", 1), SqlTypeFacets("nvarchar", false, 260)]
        public string PhysicalName
        {
            get;
            set;
        }

        [SqlColumn("Type", 2), SqlTypeFacets("char", false, 1)]
        public string Type
        {
            get;
            set;
        }

        [SqlColumn("FileGroupName", 3), SqlTypeFacets("nvarchar", true, 128)]
        public string FileGroupName
        {
            get;
            set;
        }

        [SqlColumn("Size", 4), SqlTypeFacets("numeric", false, 20, 0)]
        public decimal Size
        {
            get;
            set;
        }

        [SqlColumn("MaxSize", 5), SqlTypeFacets("numeric", false, 20, 0)]
        public decimal MaxSize
        {
            get;
            set;
        }

        [SqlColumn("FileId", 6), SqlTypeFacets("bigint", false)]
        public long FileId
        {
            get;
            set;
        }

        [SqlColumn("CreateLSN", 7), SqlTypeFacets("numeric", false, 25, 0)]
        public decimal CreateLSN
        {
            get;
            set;
        }

        [SqlColumn("DropLSN", 8), SqlTypeFacets("numeric", true, 25, 0)]
        public decimal? DropLSN
        {
            get;
            set;
        }

        [SqlColumn("UniqueId", 9), SqlTypeFacets("uniqueidentifier", false)]
        public Guid UniqueId
        {
            get;
            set;
        }

        [SqlColumn("ReadOnlyLSN", 10), SqlTypeFacets("numeric", true, 25, 0)]
        public decimal? ReadOnlyLSN
        {
            get;
            set;
        }

        [SqlColumn("ReadWriteLSN", 11), SqlTypeFacets("numeric", true, 25, 0)]
        public decimal? ReadWriteLSN
        {
            get;
            set;
        }

        [SqlColumn("BackupSizeInBytes", 12), SqlTypeFacets("bigint", false)]
        public long BackupSizeInBytes
        {
            get;
            set;
        }

        [SqlColumn("SourceBlockSize", 13), SqlTypeFacets("bigint", false)]
        public long SourceBlockSize
        {
            get;
            set;
        }

        [SqlColumn("FileGroupId", 14), SqlTypeFacets("int", false)]
        public int FileGroupId
        {
            get;
            set;
        }

        [SqlColumn("LogGroupGUID", 15), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? LogGroupGUID
        {
            get;
            set;
        }

        [SqlColumn("DifferentialBaseLSN", 16), SqlTypeFacets("numeric", true, 25, 0)]
        public decimal? DifferentialBaseLSN
        {
            get;
            set;
        }

        [SqlColumn("DifferentialBaseGUID", 17), SqlTypeFacets("uniqueidentifier", true)]
        public Guid? DifferentialBaseGUID
        {
            get;
            set;
        }

        [SqlColumn("IsReadOnly", 18), SqlTypeFacets("bit", false)]
        public bool IsReadOnly
        {
            get;
            set;
        }

        [SqlColumn("IsPresent", 19), SqlTypeFacets("bit", false)]
        public bool IsPresent
        {
            get;
            set;
        }

        [SqlColumn("TDEThumbprint", 20), SqlTypeFacets("varbinary", true, 32)]
        public Byte[] TDEThumbprint
        {
            get;
            set;
        }

        [SqlColumn("SnapshotURL", 21), SqlTypeFacets("nvarchar", true, 360)]
        public string SnapshotURL
        {
            get;
            set;
        }

        public BackupDescription()
        {
        }

        public BackupDescription(object[] items)
        {
            LogicalName = (string)items[0];
            PhysicalName = (string)items[1];
            Type = (string)items[2];
            FileGroupName = (string)items[3];
            Size = (decimal)items[4];
            MaxSize = (decimal)items[5];
            FileId = (long)items[6];
            CreateLSN = (decimal)items[7];
            DropLSN = (decimal?)items[8];
            UniqueId = (Guid)items[9];
            ReadOnlyLSN = (decimal?)items[10];
            ReadWriteLSN = (decimal?)items[11];
            BackupSizeInBytes = (long)items[12];
            SourceBlockSize = (long)items[13];
            FileGroupId = (int)items[14];
            LogGroupGUID = (Guid?)items[15];
            DifferentialBaseLSN = (decimal?)items[16];
            DifferentialBaseGUID = (Guid?)items[17];
            IsReadOnly = (bool)items[18];
            IsPresent = (bool)items[19];
            TDEThumbprint = (Byte[])items[20];
            SnapshotURL = (string)items[21];
        }

        public BackupDescription(string LogicalName, string PhysicalName, string Type, string FileGroupName, decimal Size, decimal MaxSize, long FileId, decimal CreateLSN, decimal? DropLSN, Guid UniqueId, decimal? ReadOnlyLSN, decimal? ReadWriteLSN, long BackupSizeInBytes, long SourceBlockSize, int FileGroupId, Guid? LogGroupGUID, decimal? DifferentialBaseLSN, Guid? DifferentialBaseGUID, bool IsReadOnly, bool IsPresent, Byte[] TDEThumbprint, string SnapshotURL)
        {
            this.LogicalName = LogicalName;
            this.PhysicalName = PhysicalName;
            this.Type = Type;
            this.FileGroupName = FileGroupName;
            this.Size = Size;
            this.MaxSize = MaxSize;
            this.FileId = FileId;
            this.CreateLSN = CreateLSN;
            this.DropLSN = DropLSN;
            this.UniqueId = UniqueId;
            this.ReadOnlyLSN = ReadOnlyLSN;
            this.ReadWriteLSN = ReadWriteLSN;
            this.BackupSizeInBytes = BackupSizeInBytes;
            this.SourceBlockSize = SourceBlockSize;
            this.FileGroupId = FileGroupId;
            this.LogGroupGUID = LogGroupGUID;
            this.DifferentialBaseLSN = DifferentialBaseLSN;
            this.DifferentialBaseGUID = DifferentialBaseGUID;
            this.IsReadOnly = IsReadOnly;
            this.IsPresent = IsPresent;
            this.TDEThumbprint = TDEThumbprint;
            this.SnapshotURL = SnapshotURL;
        }

        public override object[] GetItemArray()
        {
            return new object[] { LogicalName, PhysicalName, Type, FileGroupName, Size, MaxSize, FileId, CreateLSN, DropLSN, UniqueId, ReadOnlyLSN, ReadWriteLSN, BackupSizeInBytes, SourceBlockSize, FileGroupId, LogGroupGUID, DifferentialBaseLSN, DifferentialBaseGUID, IsReadOnly, IsPresent, TDEThumbprint, SnapshotURL };
        }

        public override void SetItemArray(object[] items)
        {
            LogicalName = (string)items[0];
            PhysicalName = (string)items[1];
            Type = (string)items[2];
            FileGroupName = (string)items[3];
            Size = (decimal)items[4];
            MaxSize = (decimal)items[5];
            FileId = (long)items[6];
            CreateLSN = (decimal)items[7];
            DropLSN = (decimal?)items[8];
            UniqueId = (Guid)items[9];
            ReadOnlyLSN = (decimal?)items[10];
            ReadWriteLSN = (decimal?)items[11];
            BackupSizeInBytes = (long)items[12];
            SourceBlockSize = (long)items[13];
            FileGroupId = (int)items[14];
            LogGroupGUID = (Guid?)items[15];
            DifferentialBaseLSN = (decimal?)items[16];
            DifferentialBaseGUID = (Guid?)items[17];
            IsReadOnly = (bool)items[18];
            IsPresent = (bool)items[19];
            TDEThumbprint = (Byte[])items[20];
            SnapshotURL = (string)items[21];
        }
    }

    [SqlRecord("SqlT", "ServerCollation")]
    public partial class ServerCollation : SqlTableTypeProxy<ServerCollation>
    {
        [SqlColumn("CollationName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string CollationName
        {
            get;
            set;
        }

        [SqlColumn("CodePage", 1), SqlTypeFacets("int", false)]
        public int CodePage
        {
            get;
            set;
        }

        [SqlColumn("LCID", 2), SqlTypeFacets("int", false)]
        public int LCID
        {
            get;
            set;
        }

        [SqlColumn("ComparisonStyle", 3), SqlTypeFacets("int", false)]
        public int ComparisonStyle
        {
            get;
            set;
        }

        [SqlColumn("Version", 4), SqlTypeFacets("int", false)]
        public int Version
        {
            get;
            set;
        }

        [SqlColumn("Description", 5), SqlTypeFacets("nvarchar", false, 250)]
        public string Description
        {
            get;
            set;
        }

        public ServerCollation()
        {
        }

        public ServerCollation(object[] items)
        {
            CollationName = (string)items[0];
            CodePage = (int)items[1];
            LCID = (int)items[2];
            ComparisonStyle = (int)items[3];
            Version = (int)items[4];
            Description = (string)items[5];
        }

        public ServerCollation(string CollationName, int CodePage, int LCID, int ComparisonStyle, int Version, string Description)
        {
            this.CollationName = CollationName;
            this.CodePage = CodePage;
            this.LCID = LCID;
            this.ComparisonStyle = ComparisonStyle;
            this.Version = Version;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { CollationName, CodePage, LCID, ComparisonStyle, Version, Description };
        }

        public override void SetItemArray(object[] items)
        {
            CollationName = (string)items[0];
            CodePage = (int)items[1];
            LCID = (int)items[2];
            ComparisonStyle = (int)items[3];
            Version = (int)items[4];
            Description = (string)items[5];
        }
    }

    [SqlRecord("SqlT", "PrimaryKeyColumn")]
    public partial class PrimaryKeyColumn : SqlTableTypeProxy<PrimaryKeyColumn>
    {
        [SqlColumn("DatabaseName", 0), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseVersion", 1), SqlTypeFacets("nvarchar", false, 25)]
        public string DatabaseVersion
        {
            get;
            set;
        }

        [SqlColumn("PrimaryKeySchema", 2), SqlTypeFacets("sysname", true)]
        public string PrimaryKeySchema
        {
            get;
            set;
        }

        [SqlColumn("PrimaryKeyName", 3), SqlTypeFacets("sysname", true)]
        public string PrimaryKeyName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 4), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("KeyColumnPosition", 5), SqlTypeFacets("int", false)]
        public int KeyColumnPosition
        {
            get;
            set;
        }

        public PrimaryKeyColumn()
        {
        }

        public PrimaryKeyColumn(object[] items)
        {
            DatabaseName = (string)items[0];
            DatabaseVersion = (string)items[1];
            PrimaryKeySchema = (string)items[2];
            PrimaryKeyName = (string)items[3];
            ColumnName = (string)items[4];
            KeyColumnPosition = (int)items[5];
        }

        public PrimaryKeyColumn(string DatabaseName, string DatabaseVersion, string PrimaryKeySchema, string PrimaryKeyName, string ColumnName, int KeyColumnPosition)
        {
            this.DatabaseName = DatabaseName;
            this.DatabaseVersion = DatabaseVersion;
            this.PrimaryKeySchema = PrimaryKeySchema;
            this.PrimaryKeyName = PrimaryKeyName;
            this.ColumnName = ColumnName;
            this.KeyColumnPosition = KeyColumnPosition;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DatabaseName, DatabaseVersion, PrimaryKeySchema, PrimaryKeyName, ColumnName, KeyColumnPosition };
        }

        public override void SetItemArray(object[] items)
        {
            DatabaseName = (string)items[0];
            DatabaseVersion = (string)items[1];
            PrimaryKeySchema = (string)items[2];
            PrimaryKeyName = (string)items[3];
            ColumnName = (string)items[4];
            KeyColumnPosition = (int)items[5];
        }
    }

    [SqlRecord("SqlT", "SystemDataType")]
    public partial class SystemDataType : SqlTableTypeProxy<SystemDataType>
    {
        [SqlColumn("DbName", 0), SqlTypeFacets("sysname", true)]
        public string DbName
        {
            get;
            set;
        }

        [SqlColumn("DbVersion", 1), SqlTypeFacets("nvarchar", false, 25)]
        public string DbVersion
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 2), SqlTypeFacets("sysname", true)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 3), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        [SqlColumn("Length", 4), SqlTypeFacets("int", true)]
        public int? Length
        {
            get;
            set;
        }

        [SqlColumn("MaxLength", 5), SqlTypeFacets("int", true)]
        public int? MaxLength
        {
            get;
            set;
        }

        [SqlColumn("Precision", 6), SqlTypeFacets("tinyint", true)]
        public byte? Precision
        {
            get;
            set;
        }

        [SqlColumn("MaxPrecision", 7), SqlTypeFacets("tinyint", true)]
        public byte? MaxPrecision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 8), SqlTypeFacets("tinyint", true)]
        public byte? Scale
        {
            get;
            set;
        }

        [SqlColumn("MaxScale", 9), SqlTypeFacets("tinyint", true)]
        public byte? MaxScale
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 10), SqlTypeFacets("bit", false)]
        public bool IsNullable
        {
            get;
            set;
        }

        public SystemDataType()
        {
        }

        public SystemDataType(object[] items)
        {
            DbName = (string)items[0];
            DbVersion = (string)items[1];
            TypeName = (string)items[2];
            Documentation = (string)items[3];
            Length = (int?)items[4];
            MaxLength = (int?)items[5];
            Precision = (byte?)items[6];
            MaxPrecision = (byte?)items[7];
            Scale = (byte?)items[8];
            MaxScale = (byte?)items[9];
            IsNullable = (bool)items[10];
        }

        public SystemDataType(string DbName, string DbVersion, string TypeName, string Documentation, int? Length, int? MaxLength, byte? Precision, byte? MaxPrecision, byte? Scale, byte? MaxScale, bool IsNullable)
        {
            this.DbName = DbName;
            this.DbVersion = DbVersion;
            this.TypeName = TypeName;
            this.Documentation = Documentation;
            this.Length = Length;
            this.MaxLength = MaxLength;
            this.Precision = Precision;
            this.MaxPrecision = MaxPrecision;
            this.Scale = Scale;
            this.MaxScale = MaxScale;
            this.IsNullable = IsNullable;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DbName, DbVersion, TypeName, Documentation, Length, MaxLength, Precision, MaxPrecision, Scale, MaxScale, IsNullable };
        }

        public override void SetItemArray(object[] items)
        {
            DbName = (string)items[0];
            DbVersion = (string)items[1];
            TypeName = (string)items[2];
            Documentation = (string)items[3];
            Length = (int?)items[4];
            MaxLength = (int?)items[5];
            Precision = (byte?)items[6];
            MaxPrecision = (byte?)items[7];
            Scale = (byte?)items[8];
            MaxScale = (byte?)items[9];
            IsNullable = (bool)items[10];
        }
    }

    [SqlRecord("SqlT", "PrimaryKey")]
    public partial class PrimaryKey : SqlTableTypeProxy<PrimaryKey>
    {
        [SqlColumn("DatabaseName", 0), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseVersion", 1), SqlTypeFacets("nvarchar", false, 25)]
        public string DatabaseVersion
        {
            get;
            set;
        }

        [SqlColumn("TableSchemaName", 2), SqlTypeFacets("sysname", true)]
        public string TableSchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("PrimaryKeyName", 4), SqlTypeFacets("sysname", true)]
        public string PrimaryKeyName
        {
            get;
            set;
        }

        [SqlColumn("IsClustered", 5), SqlTypeFacets("bit", false)]
        public bool IsClustered
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 6), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public PrimaryKey()
        {
        }

        public PrimaryKey(object[] items)
        {
            DatabaseName = (string)items[0];
            DatabaseVersion = (string)items[1];
            TableSchemaName = (string)items[2];
            TableName = (string)items[3];
            PrimaryKeyName = (string)items[4];
            IsClustered = (bool)items[5];
            Documentation = (string)items[6];
        }

        public PrimaryKey(string DatabaseName, string DatabaseVersion, string TableSchemaName, string TableName, string PrimaryKeyName, bool IsClustered, string Documentation)
        {
            this.DatabaseName = DatabaseName;
            this.DatabaseVersion = DatabaseVersion;
            this.TableSchemaName = TableSchemaName;
            this.TableName = TableName;
            this.PrimaryKeyName = PrimaryKeyName;
            this.IsClustered = IsClustered;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { DatabaseName, DatabaseVersion, TableSchemaName, TableName, PrimaryKeyName, IsClustered, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            DatabaseName = (string)items[0];
            DatabaseVersion = (string)items[1];
            TableSchemaName = (string)items[2];
            TableName = (string)items[3];
            PrimaryKeyName = (string)items[4];
            IsClustered = (bool)items[5];
            Documentation = (string)items[6];
        }
    }

    [SqlRecord("SqlT", "ColumnGroupMember")]
    public partial class ColumnGroupMember : SqlTableTypeProxy<ColumnGroupMember>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ObjectSchema", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectSchema
        {
            get;
            set;
        }

        [SqlColumn("ObjectName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("GroupTypeName", 5), SqlTypeFacets("nvarchar", false, 75)]
        public string GroupTypeName
        {
            get;
            set;
        }

        public ColumnGroupMember()
        {
        }

        public ColumnGroupMember(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ObjectSchema = (string)items[2];
            ObjectName = (string)items[3];
            ColumnName = (string)items[4];
            GroupTypeName = (string)items[5];
        }

        public ColumnGroupMember(string ServerName, string DatabaseName, string ObjectSchema, string ObjectName, string ColumnName, string GroupTypeName)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ObjectSchema = ObjectSchema;
            this.ObjectName = ObjectName;
            this.ColumnName = ColumnName;
            this.GroupTypeName = GroupTypeName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, ObjectSchema, ObjectName, ColumnName, GroupTypeName };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ObjectSchema = (string)items[2];
            ObjectName = (string)items[3];
            ColumnName = (string)items[4];
            GroupTypeName = (string)items[5];
        }
    }

    [SqlRecord("SqlT", "ProxyProfileDefinition")]
    public partial class ProxyProfileDefinition : SqlTableTypeProxy<ProxyProfileDefinition>
    {
        [SqlColumn("AssemblyDesignator", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string AssemblyDesignator
        {
            get;
            set;
        }

        [SqlColumn("ProfileName", 1), SqlTypeFacets("nvarchar", false, 75)]
        public string ProfileName
        {
            get;
            set;
        }

        [SqlColumn("SourceNode", 2), SqlTypeFacets("nvarchar", false, 75)]
        public string SourceNode
        {
            get;
            set;
        }

        [SqlColumn("SourceDatabase", 3), SqlTypeFacets("nvarchar", true, 128)]
        public string SourceDatabase
        {
            get;
            set;
        }

        [SqlColumn("TargetAssembly", 4), SqlTypeFacets("nvarchar", true, 128)]
        public string TargetAssembly
        {
            get;
            set;
        }

        [SqlColumn("ProfileText", 5), SqlTypeFacets("nvarchar", false, 0)]
        public string ProfileText
        {
            get;
            set;
        }

        public ProxyProfileDefinition()
        {
        }

        public ProxyProfileDefinition(object[] items)
        {
            AssemblyDesignator = (string)items[0];
            ProfileName = (string)items[1];
            SourceNode = (string)items[2];
            SourceDatabase = (string)items[3];
            TargetAssembly = (string)items[4];
            ProfileText = (string)items[5];
        }

        public ProxyProfileDefinition(string AssemblyDesignator, string ProfileName, string SourceNode, string SourceDatabase, string TargetAssembly, string ProfileText)
        {
            this.AssemblyDesignator = AssemblyDesignator;
            this.ProfileName = ProfileName;
            this.SourceNode = SourceNode;
            this.SourceDatabase = SourceDatabase;
            this.TargetAssembly = TargetAssembly;
            this.ProfileText = ProfileText;
        }

        public override object[] GetItemArray()
        {
            return new object[] { AssemblyDesignator, ProfileName, SourceNode, SourceDatabase, TargetAssembly, ProfileText };
        }

        public override void SetItemArray(object[] items)
        {
            AssemblyDesignator = (string)items[0];
            ProfileName = (string)items[1];
            SourceNode = (string)items[2];
            SourceDatabase = (string)items[3];
            TargetAssembly = (string)items[4];
            ProfileText = (string)items[5];
        }
    }

    [SqlRecord("SqlT", "FileTableDescription")]
    public partial class FileTableDescription : SqlTableTypeProxy<FileTableDescription>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("UncParentPath", 4), SqlTypeFacets("nvarchar", true, 512)]
        public string UncParentPath
        {
            get;
            set;
        }

        [SqlColumn("DirectoryName", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string DirectoryName
        {
            get;
            set;
        }

        public FileTableDescription()
        {
        }

        public FileTableDescription(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            UncParentPath = (string)items[4];
            DirectoryName = (string)items[5];
        }

        public FileTableDescription(string ServerName, string DatabaseName, string TableSchema, string TableName, string UncParentPath, string DirectoryName)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.UncParentPath = UncParentPath;
            this.DirectoryName = DirectoryName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, TableSchema, TableName, UncParentPath, DirectoryName };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            UncParentPath = (string)items[4];
            DirectoryName = (string)items[5];
        }
    }

    [SqlRecord("SqlT", "Database")]
    public partial class Database : SqlTableTypeProxy<Database>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseType", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseType
        {
            get;
            set;
        }

        public Database()
        {
        }

        public Database(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseType = (string)items[2];
        }

        public Database(string ServerName, string DatabaseName, string DatabaseType)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.DatabaseType = DatabaseType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, DatabaseType };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            DatabaseType = (string)items[2];
        }
    }

    [SqlRecord("SqlT", "ColumnDefinition")]
    public partial class ColumnDefinition : SqlTableTypeProxy<ColumnDefinition>
    {
        [SqlColumn("ColumnName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnId", 1), SqlTypeFacets("int", false)]
        public int ColumnId
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 2), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("DataTypeName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string DataTypeName
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 4), SqlTypeFacets("bit", false)]
        public bool IsNullable
        {
            get;
            set;
        }

        [SqlColumn("IsIdentity", 5), SqlTypeFacets("bit", false)]
        public bool IsIdentity
        {
            get;
            set;
        }

        [SqlColumn("Length", 6), SqlTypeFacets("int", true)]
        public int? Length
        {
            get;
            set;
        }

        [SqlColumn("Precision", 7), SqlTypeFacets("tinyint", true)]
        public byte? Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 8), SqlTypeFacets("tinyint", true)]
        public byte? Scale
        {
            get;
            set;
        }

        [SqlColumn("ComputationExpression", 9), SqlTypeFacets("nvarchar", true, 250)]
        public string ComputationExpression
        {
            get;
            set;
        }

        [SqlColumn("ComputationPersisted", 10), SqlTypeFacets("bit", true)]
        public bool? ComputationPersisted
        {
            get;
            set;
        }

        [SqlColumn("Description", 11), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public ColumnDefinition()
        {
        }

        public ColumnDefinition(object[] items)
        {
            ColumnName = (string)items[0];
            ColumnId = (int)items[1];
            ColumnPosition = (int)items[2];
            DataTypeName = (string)items[3];
            IsNullable = (bool)items[4];
            IsIdentity = (bool)items[5];
            Length = (int?)items[6];
            Precision = (byte?)items[7];
            Scale = (byte?)items[8];
            ComputationExpression = (string)items[9];
            ComputationPersisted = (bool?)items[10];
            Description = (string)items[11];
        }

        public ColumnDefinition(string ColumnName, int ColumnId, int ColumnPosition, string DataTypeName, bool IsNullable, bool IsIdentity, int? Length, byte? Precision, byte? Scale, string ComputationExpression, bool? ComputationPersisted, string Description)
        {
            this.ColumnName = ColumnName;
            this.ColumnId = ColumnId;
            this.ColumnPosition = ColumnPosition;
            this.DataTypeName = DataTypeName;
            this.IsNullable = IsNullable;
            this.IsIdentity = IsIdentity;
            this.Length = Length;
            this.Precision = Precision;
            this.Scale = Scale;
            this.ComputationExpression = ComputationExpression;
            this.ComputationPersisted = ComputationPersisted;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ColumnName, ColumnId, ColumnPosition, DataTypeName, IsNullable, IsIdentity, Length, Precision, Scale, ComputationExpression, ComputationPersisted, Description };
        }

        public override void SetItemArray(object[] items)
        {
            ColumnName = (string)items[0];
            ColumnId = (int)items[1];
            ColumnPosition = (int)items[2];
            DataTypeName = (string)items[3];
            IsNullable = (bool)items[4];
            IsIdentity = (bool)items[5];
            Length = (int?)items[6];
            Precision = (byte?)items[7];
            Scale = (byte?)items[8];
            ComputationExpression = (string)items[9];
            ComputationPersisted = (bool?)items[10];
            Description = (string)items[11];
        }
    }

    [SqlRecord("SqlT", "TableType")]
    public partial class TableType : SqlTableTypeProxy<TableType>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("Description", 4), SqlTypeFacets("nvarchar", false, 250)]
        public string Description
        {
            get;
            set;
        }

        public TableType()
        {
        }

        public TableType(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TypeName = (string)items[3];
            Description = (string)items[4];
        }

        public TableType(string ServerName, string DatabaseName, string SchemaName, string TypeName, string Description)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TypeName = TypeName;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, SchemaName, TypeName, Description };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TypeName = (string)items[3];
            Description = (string)items[4];
        }
    }

    [SqlRecord("SqlT", "ObjectFacet")]
    public partial class ObjectFacet : SqlTableTypeProxy<ObjectFacet>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("ObjectName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string ObjectName
        {
            get;
            set;
        }

        public ObjectFacet()
        {
        }

        public ObjectFacet(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            ObjectName = (string)items[3];
        }

        public ObjectFacet(string ServerName, string DatabaseName, string SchemaName, string ObjectName)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.ObjectName = ObjectName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, SchemaName, ObjectName };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            ObjectName = (string)items[3];
        }
    }

    [SqlRecord("SqlT", "ColumnFacet")]
    public partial class ColumnFacet : SqlTableTypeProxy<ColumnFacet>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        public ColumnFacet()
        {
        }

        public ColumnFacet(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            ColumnName = (string)items[4];
        }

        public ColumnFacet(string ServerName, string DatabaseName, string SchemaName, string TableName, string ColumnName)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.ColumnName = ColumnName;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, SchemaName, TableName, ColumnName };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            ColumnName = (string)items[4];
        }
    }

    [SqlRecord("SqlT", "UserDataType")]
    public partial class UserDataType : SqlTableTypeProxy<UserDataType>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("TypeSchema", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string TypeSchema
        {
            get;
            set;
        }

        [SqlColumn("TypeName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("BaseTypeName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string BaseTypeName
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 5), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        [SqlColumn("MaxLength", 6), SqlTypeFacets("smallint", false)]
        public short MaxLength
        {
            get;
            set;
        }

        [SqlColumn("Precision", 7), SqlTypeFacets("tinyint", false)]
        public byte Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 8), SqlTypeFacets("tinyint", false)]
        public byte Scale
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 9), SqlTypeFacets("bit", false)]
        public bool IsNullable
        {
            get;
            set;
        }

        public UserDataType()
        {
        }

        public UserDataType(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            TypeSchema = (string)items[2];
            TypeName = (string)items[3];
            BaseTypeName = (string)items[4];
            Documentation = (string)items[5];
            MaxLength = (short)items[6];
            Precision = (byte)items[7];
            Scale = (byte)items[8];
            IsNullable = (bool)items[9];
        }

        public UserDataType(string ServerName, string DatabaseName, string TypeSchema, string TypeName, string BaseTypeName, string Documentation, short MaxLength, byte Precision, byte Scale, bool IsNullable)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.TypeSchema = TypeSchema;
            this.TypeName = TypeName;
            this.BaseTypeName = BaseTypeName;
            this.Documentation = Documentation;
            this.MaxLength = MaxLength;
            this.Precision = Precision;
            this.Scale = Scale;
            this.IsNullable = IsNullable;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, TypeSchema, TypeName, BaseTypeName, Documentation, MaxLength, Precision, Scale, IsNullable };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            TypeSchema = (string)items[2];
            TypeName = (string)items[3];
            BaseTypeName = (string)items[4];
            Documentation = (string)items[5];
            MaxLength = (short)items[6];
            Precision = (byte)items[7];
            Scale = (byte)items[8];
            IsNullable = (bool)items[9];
        }
    }

    [SqlRecord("SqlT", "TableStats")]
    public partial class TableStats : SqlTableTypeProxy<TableStats>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("sysname", true)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("sysname", true)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 2), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("ColumnCount", 4), SqlTypeFacets("int", false)]
        public int ColumnCount
        {
            get;
            set;
        }

        [SqlColumn("RowCount", 5), SqlTypeFacets("int", false)]
        public int RowCount
        {
            get;
            set;
        }

        [SqlColumn("DataStorage", 6), SqlTypeFacets("decimal", false, 19, 3)]
        public decimal DataStorage
        {
            get;
            set;
        }

        [SqlColumn("IndexStorage", 7), SqlTypeFacets("decimal", false, 19, 3)]
        public decimal IndexStorage
        {
            get;
            set;
        }

        [SqlColumn("TableStorage", 8), SqlTypeFacets("decimal", false, 19, 3)]
        public decimal TableStorage
        {
            get;
            set;
        }

        public TableStats()
        {
        }

        public TableStats(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            ColumnCount = (int)items[4];
            RowCount = (int)items[5];
            DataStorage = (decimal)items[6];
            IndexStorage = (decimal)items[7];
            TableStorage = (decimal)items[8];
        }

        public TableStats(string ServerName, string DatabaseName, string TableSchema, string TableName, int ColumnCount, int RowCount, decimal DataStorage, decimal IndexStorage, decimal TableStorage)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.ColumnCount = ColumnCount;
            this.RowCount = RowCount;
            this.DataStorage = DataStorage;
            this.IndexStorage = IndexStorage;
            this.TableStorage = TableStorage;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, TableSchema, TableName, ColumnCount, RowCount, DataStorage, IndexStorage, TableStorage };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            TableSchema = (string)items[2];
            TableName = (string)items[3];
            ColumnCount = (int)items[4];
            RowCount = (int)items[5];
            DataStorage = (decimal)items[6];
            IndexStorage = (decimal)items[7];
            TableStorage = (decimal)items[8];
        }
    }

    [SqlRecord("SqlT", "TableDescription")]
    public partial class TableDescription : SqlTableTypeProxy<TableDescription>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("FileGroupName", 4), SqlTypeFacets("nvarchar", true, 128)]
        public string FileGroupName
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 5), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public TableDescription()
        {
        }

        public TableDescription(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            FileGroupName = (string)items[4];
            Documentation = (string)items[5];
        }

        public TableDescription(string ServerName, string DatabaseName, string SchemaName, string TableName, string FileGroupName, string Documentation)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.FileGroupName = FileGroupName;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, SchemaName, TableName, FileGroupName, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            FileGroupName = (string)items[4];
            Documentation = (string)items[5];
        }
    }

    [SqlRecord("SqlT", "TableColumn")]
    public partial class TableColumn : SqlTableTypeProxy<TableColumn>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", true, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnId", 5), SqlTypeFacets("int", false)]
        public int ColumnId
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 6), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("DataTypeName", 7), SqlTypeFacets("nvarchar", false, 128)]
        public string DataTypeName
        {
            get;
            set;
        }

        [SqlColumn("IsNullable", 8), SqlTypeFacets("bit", false)]
        public bool IsNullable
        {
            get;
            set;
        }

        [SqlColumn("IsIdentity", 9), SqlTypeFacets("bit", false)]
        public bool IsIdentity
        {
            get;
            set;
        }

        [SqlColumn("Length", 10), SqlTypeFacets("int", true)]
        public int? Length
        {
            get;
            set;
        }

        [SqlColumn("Precision", 11), SqlTypeFacets("tinyint", true)]
        public byte? Precision
        {
            get;
            set;
        }

        [SqlColumn("Scale", 12), SqlTypeFacets("tinyint", true)]
        public byte? Scale
        {
            get;
            set;
        }

        [SqlColumn("ComputationExpression", 13), SqlTypeFacets("nvarchar", true, 250)]
        public string ComputationExpression
        {
            get;
            set;
        }

        [SqlColumn("ComputationPersisted", 14), SqlTypeFacets("bit", true)]
        public bool? ComputationPersisted
        {
            get;
            set;
        }

        [SqlColumn("ColumnRole", 15), SqlTypeFacets("nvarchar", true, 75)]
        public string ColumnRole
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 16), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public TableColumn()
        {
        }

        public TableColumn(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            ColumnName = (string)items[4];
            ColumnId = (int)items[5];
            ColumnPosition = (int)items[6];
            DataTypeName = (string)items[7];
            IsNullable = (bool)items[8];
            IsIdentity = (bool)items[9];
            Length = (int?)items[10];
            Precision = (byte?)items[11];
            Scale = (byte?)items[12];
            ComputationExpression = (string)items[13];
            ComputationPersisted = (bool?)items[14];
            ColumnRole = (string)items[15];
            Documentation = (string)items[16];
        }

        public TableColumn(string ServerName, string DatabaseName, string SchemaName, string TableName, string ColumnName, int ColumnId, int ColumnPosition, string DataTypeName, bool IsNullable, bool IsIdentity, int? Length, byte? Precision, byte? Scale, string ComputationExpression, bool? ComputationPersisted, string ColumnRole, string Documentation)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.ColumnName = ColumnName;
            this.ColumnId = ColumnId;
            this.ColumnPosition = ColumnPosition;
            this.DataTypeName = DataTypeName;
            this.IsNullable = IsNullable;
            this.IsIdentity = IsIdentity;
            this.Length = Length;
            this.Precision = Precision;
            this.Scale = Scale;
            this.ComputationExpression = ComputationExpression;
            this.ComputationPersisted = ComputationPersisted;
            this.ColumnRole = ColumnRole;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, SchemaName, TableName, ColumnName, ColumnId, ColumnPosition, DataTypeName, IsNullable, IsIdentity, Length, Precision, Scale, ComputationExpression, ComputationPersisted, ColumnRole, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            ColumnName = (string)items[4];
            ColumnId = (int)items[5];
            ColumnPosition = (int)items[6];
            DataTypeName = (string)items[7];
            IsNullable = (bool)items[8];
            IsIdentity = (bool)items[9];
            Length = (int?)items[10];
            Precision = (byte?)items[11];
            Scale = (byte?)items[12];
            ComputationExpression = (string)items[13];
            ComputationPersisted = (bool?)items[14];
            ColumnRole = (string)items[15];
            Documentation = (string)items[16];
        }
    }

    [SqlRecord("SqlT", "ForeignKeyInfo")]
    public partial class ForeignKeyInfo : SqlTableTypeProxy<ForeignKeyInfo>
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ServerName
        {
            get;
            set;
        }

        [SqlColumn("DatabaseName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string DatabaseName
        {
            get;
            set;
        }

        [SqlColumn("ForeignKeySchema", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string ForeignKeySchema
        {
            get;
            set;
        }

        [SqlColumn("ForeignKeyName", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string ForeignKeyName
        {
            get;
            set;
        }

        [SqlColumn("ClientTableSchema", 4), SqlTypeFacets("nvarchar", false, 128)]
        public string ClientTableSchema
        {
            get;
            set;
        }

        [SqlColumn("ClientTableName", 5), SqlTypeFacets("nvarchar", false, 128)]
        public string ClientTableName
        {
            get;
            set;
        }

        [SqlColumn("SupplierTableSchema", 6), SqlTypeFacets("nvarchar", false, 128)]
        public string SupplierTableSchema
        {
            get;
            set;
        }

        [SqlColumn("SupplierTableName", 7), SqlTypeFacets("nvarchar", false, 128)]
        public string SupplierTableName
        {
            get;
            set;
        }

        [SqlColumn("KeyColumnId", 8), SqlTypeFacets("int", false)]
        public int KeyColumnId
        {
            get;
            set;
        }

        [SqlColumn("ClientColumnName", 9), SqlTypeFacets("nvarchar", false, 128)]
        public string ClientColumnName
        {
            get;
            set;
        }

        [SqlColumn("ClientColummnId", 10), SqlTypeFacets("int", false)]
        public int ClientColummnId
        {
            get;
            set;
        }

        [SqlColumn("SupplierColumnName", 11), SqlTypeFacets("nvarchar", false, 128)]
        public string SupplierColumnName
        {
            get;
            set;
        }

        [SqlColumn("SupplierColumnId", 12), SqlTypeFacets("int", false)]
        public int SupplierColumnId
        {
            get;
            set;
        }

        [SqlColumn("Documentation", 13), SqlTypeFacets("nvarchar", true, 250)]
        public string Documentation
        {
            get;
            set;
        }

        public ForeignKeyInfo()
        {
        }

        public ForeignKeyInfo(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ForeignKeySchema = (string)items[2];
            ForeignKeyName = (string)items[3];
            ClientTableSchema = (string)items[4];
            ClientTableName = (string)items[5];
            SupplierTableSchema = (string)items[6];
            SupplierTableName = (string)items[7];
            KeyColumnId = (int)items[8];
            ClientColumnName = (string)items[9];
            ClientColummnId = (int)items[10];
            SupplierColumnName = (string)items[11];
            SupplierColumnId = (int)items[12];
            Documentation = (string)items[13];
        }

        public ForeignKeyInfo(string ServerName, string DatabaseName, string ForeignKeySchema, string ForeignKeyName, string ClientTableSchema, string ClientTableName, string SupplierTableSchema, string SupplierTableName, int KeyColumnId, string ClientColumnName, int ClientColummnId, string SupplierColumnName, int SupplierColumnId, string Documentation)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.ForeignKeySchema = ForeignKeySchema;
            this.ForeignKeyName = ForeignKeyName;
            this.ClientTableSchema = ClientTableSchema;
            this.ClientTableName = ClientTableName;
            this.SupplierTableSchema = SupplierTableSchema;
            this.SupplierTableName = SupplierTableName;
            this.KeyColumnId = KeyColumnId;
            this.ClientColumnName = ClientColumnName;
            this.ClientColummnId = ClientColummnId;
            this.SupplierColumnName = SupplierColumnName;
            this.SupplierColumnId = SupplierColumnId;
            this.Documentation = Documentation;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, DatabaseName, ForeignKeySchema, ForeignKeyName, ClientTableSchema, ClientTableName, SupplierTableSchema, SupplierTableName, KeyColumnId, ClientColumnName, ClientColummnId, SupplierColumnName, SupplierColumnId, Documentation };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (string)items[0];
            DatabaseName = (string)items[1];
            ForeignKeySchema = (string)items[2];
            ForeignKeyName = (string)items[3];
            ClientTableSchema = (string)items[4];
            ClientTableName = (string)items[5];
            SupplierTableSchema = (string)items[6];
            SupplierTableName = (string)items[7];
            KeyColumnId = (int)items[8];
            ClientColumnName = (string)items[9];
            ClientColummnId = (int)items[10];
            SupplierColumnName = (string)items[11];
            SupplierColumnId = (int)items[12];
            Documentation = (string)items[13];
        }
    }

    [SqlRecord("SqlT", "ColumnComparison")]
    public partial class ColumnComparison : SqlTableTypeProxy<ColumnComparison>
    {
        [SqlColumn("QueryName", 0), SqlTypeFacets("nvarchar", false, 250)]
        public string QueryName
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ComparisonPosition", 2), SqlTypeFacets("int", false)]
        public int ComparisonPosition
        {
            get;
            set;
        }

        [SqlColumn("Junction", 3), SqlTypeFacets("nvarchar", true, 5)]
        public string Junction
        {
            get;
            set;
        }

        [SqlColumn("ComparisonOperator", 4), SqlTypeFacets("nvarchar", false, 5)]
        public string ComparisonOperator
        {
            get;
            set;
        }

        [SqlColumn("OperandValue", 5), SqlTypeFacets("nvarchar", false, 250)]
        public string OperandValue
        {
            get;
            set;
        }

        [SqlColumn("OperandDataType", 6), SqlTypeFacets("sysname", true)]
        public string OperandDataType
        {
            get;
            set;
        }

        public ColumnComparison()
        {
        }

        public ColumnComparison(object[] items)
        {
            QueryName = (string)items[0];
            ColumnName = (string)items[1];
            ComparisonPosition = (int)items[2];
            Junction = (string)items[3];
            ComparisonOperator = (string)items[4];
            OperandValue = (string)items[5];
            OperandDataType = (string)items[6];
        }

        public ColumnComparison(string QueryName, string ColumnName, int ComparisonPosition, string Junction, string ComparisonOperator, string OperandValue, string OperandDataType)
        {
            this.QueryName = QueryName;
            this.ColumnName = ColumnName;
            this.ComparisonPosition = ComparisonPosition;
            this.Junction = Junction;
            this.ComparisonOperator = ComparisonOperator;
            this.OperandValue = OperandValue;
            this.OperandDataType = OperandDataType;
        }

        public override object[] GetItemArray()
        {
            return new object[] { QueryName, ColumnName, ComparisonPosition, Junction, ComparisonOperator, OperandValue, OperandDataType };
        }

        public override void SetItemArray(object[] items)
        {
            QueryName = (string)items[0];
            ColumnName = (string)items[1];
            ComparisonPosition = (int)items[2];
            Junction = (string)items[3];
            ComparisonOperator = (string)items[4];
            OperandValue = (string)items[5];
            OperandDataType = (string)items[6];
        }
    }

    [SqlRecord("SqlT", "ProxyFieldList")]
    public partial class ProxyFieldList : SqlTableTypeProxy<ProxyFieldList>
    {
        [SqlColumn("ListName", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string ListName
        {
            get;
            set;
        }

        [SqlColumn("SourceTableSchema", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string SourceTableSchema
        {
            get;
            set;
        }

        [SqlColumn("SourceTableName", 2), SqlTypeFacets("nvarchar", false, 128)]
        public string SourceTableName
        {
            get;
            set;
        }

        [SqlColumn("IdentifierColumn", 3), SqlTypeFacets("nvarchar", false, 128)]
        public string IdentifierColumn
        {
            get;
            set;
        }

        [SqlColumn("TableTypeSchema", 4), SqlTypeFacets("nvarchar", true, 128)]
        public string TableTypeSchema
        {
            get;
            set;
        }

        [SqlColumn("TableTypeName", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string TableTypeName
        {
            get;
            set;
        }

        [SqlColumn("TypedIdentifierType", 6), SqlTypeFacets("nvarchar", true, 75)]
        public string TypedIdentifierType
        {
            get;
            set;
        }

        [SqlColumn("IdentifierValueColumn", 7), SqlTypeFacets("nvarchar", true, 128)]
        public string IdentifierValueColumn
        {
            get;
            set;
        }

        public ProxyFieldList()
        {
        }

        public ProxyFieldList(object[] items)
        {
            ListName = (string)items[0];
            SourceTableSchema = (string)items[1];
            SourceTableName = (string)items[2];
            IdentifierColumn = (string)items[3];
            TableTypeSchema = (string)items[4];
            TableTypeName = (string)items[5];
            TypedIdentifierType = (string)items[6];
            IdentifierValueColumn = (string)items[7];
        }

        public ProxyFieldList(string ListName, string SourceTableSchema, string SourceTableName, string IdentifierColumn, string TableTypeSchema, string TableTypeName, string TypedIdentifierType, string IdentifierValueColumn)
        {
            this.ListName = ListName;
            this.SourceTableSchema = SourceTableSchema;
            this.SourceTableName = SourceTableName;
            this.IdentifierColumn = IdentifierColumn;
            this.TableTypeSchema = TableTypeSchema;
            this.TableTypeName = TableTypeName;
            this.TypedIdentifierType = TypedIdentifierType;
            this.IdentifierValueColumn = IdentifierValueColumn;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ListName, SourceTableSchema, SourceTableName, IdentifierColumn, TableTypeSchema, TableTypeName, TypedIdentifierType, IdentifierValueColumn };
        }

        public override void SetItemArray(object[] items)
        {
            ListName = (string)items[0];
            SourceTableSchema = (string)items[1];
            SourceTableName = (string)items[2];
            IdentifierColumn = (string)items[3];
            TableTypeSchema = (string)items[4];
            TableTypeName = (string)items[5];
            TypedIdentifierType = (string)items[6];
            IdentifierValueColumn = (string)items[7];
        }
    }

    [SqlView("SqlT", "TimeZoneDescriptor")]
    public partial class TimeZoneDescriptor : SqlViewProxy
    {
        [SqlColumn("Identifier", 0), SqlTypeFacets("nvarchar", true, 4000)]
        public string Identifier
        {
            get;
            set;
        }

        [SqlColumn("Label", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string Label
        {
            get;
            set;
        }

        [SqlColumn("UtcOffset", 2), SqlTypeFacets("decimal", true, 4, 2)]
        public decimal? UtcOffset
        {
            get;
            set;
        }

        [SqlColumn("OffsetDirection", 3), SqlTypeFacets("int", false)]
        public int OffsetDirection
        {
            get;
            set;
        }

        [SqlColumn("ObservervesDST", 4), SqlTypeFacets("bit", false)]
        public bool ObservervesDST
        {
            get;
            set;
        }

        public TimeZoneDescriptor()
        {
        }

        public TimeZoneDescriptor(object[] items)
        {
            Identifier = (string)items[0];
            Label = (string)items[1];
            UtcOffset = (decimal?)items[2];
            OffsetDirection = (int)items[3];
            ObservervesDST = (bool)items[4];
        }

        public TimeZoneDescriptor(string Identifier, string Label, decimal? UtcOffset, int OffsetDirection, bool ObservervesDST)
        {
            this.Identifier = Identifier;
            this.Label = Label;
            this.UtcOffset = UtcOffset;
            this.OffsetDirection = OffsetDirection;
            this.ObservervesDST = ObservervesDST;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Identifier, Label, UtcOffset, OffsetDirection, ObservervesDST };
        }

        public override void SetItemArray(object[] items)
        {
            Identifier = (string)items[0];
            Label = (string)items[1];
            UtcOffset = (decimal?)items[2];
            OffsetDirection = (int)items[3];
            ObservervesDST = (bool)items[4];
        }
    }

    [SqlView("SqlT", "TableStatsView")]
    public partial class TableStatsView : SqlViewProxy
    {
        [SqlColumn("ServerName", 0), SqlTypeFacets("sql_variant", true)]
        public Object ServerName
        {
            get;
            set;
        }

        [SqlColumn("CatalogName", 1), SqlTypeFacets("nvarchar", true, 128)]
        public string CatalogName
        {
            get;
            set;
        }

        [SqlColumn("SchemaName", 2), SqlTypeFacets("sysname", false)]
        public string SchemaName
        {
            get;
            set;
        }

        [SqlColumn("TableName", 3), SqlTypeFacets("sysname", false)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("RecordCount", 4), SqlTypeFacets("int", true)]
        public int? RecordCount
        {
            get;
            set;
        }

        [SqlColumn("DataStorage (MB)", 5), SqlTypeFacets("decimal", true, 10, 3)]
        public decimal? DataStorage_ᐸMBᐳ
        {
            get;
            set;
        }

        [SqlColumn("IndexStorage (MB)", 6), SqlTypeFacets("decimal", true, 10, 3)]
        public decimal? IndexStorage_ᐸMBᐳ
        {
            get;
            set;
        }

        [SqlColumn("Total Storage (MB)", 7), SqlTypeFacets("decimal", true, 11, 3)]
        public decimal? Total_Storage_ᐸMBᐳ
        {
            get;
            set;
        }

        public TableStatsView()
        {
        }

        public TableStatsView(object[] items)
        {
            ServerName = (Object)items[0];
            CatalogName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            RecordCount = (int?)items[4];
            DataStorage_ᐸMBᐳ = (decimal?)items[5];
            IndexStorage_ᐸMBᐳ = (decimal?)items[6];
            Total_Storage_ᐸMBᐳ = (decimal?)items[7];
        }

        public TableStatsView(Object ServerName, string CatalogName, string SchemaName, string TableName, int? RecordCount, decimal? DataStorage_ᐸMBᐳ, decimal? IndexStorage_ᐸMBᐳ, decimal? Total_Storage_ᐸMBᐳ)
        {
            this.ServerName = ServerName;
            this.CatalogName = CatalogName;
            this.SchemaName = SchemaName;
            this.TableName = TableName;
            this.RecordCount = RecordCount;
            this.DataStorage_ᐸMBᐳ = DataStorage_ᐸMBᐳ;
            this.IndexStorage_ᐸMBᐳ = IndexStorage_ᐸMBᐳ;
            this.Total_Storage_ᐸMBᐳ = Total_Storage_ᐸMBᐳ;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ServerName, CatalogName, SchemaName, TableName, RecordCount, DataStorage_ᐸMBᐳ, IndexStorage_ᐸMBᐳ, Total_Storage_ᐸMBᐳ };
        }

        public override void SetItemArray(object[] items)
        {
            ServerName = (Object)items[0];
            CatalogName = (string)items[1];
            SchemaName = (string)items[2];
            TableName = (string)items[3];
            RecordCount = (int?)items[4];
            DataStorage_ᐸMBᐳ = (decimal?)items[5];
            IndexStorage_ᐸMBᐳ = (decimal?)items[6];
            Total_Storage_ᐸMBᐳ = (decimal?)items[7];
        }
    }
}
//This file was generated at 5/12/2018 8:42:08 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.Types.SqlStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SqlStoreViewNames
    {
        public readonly static SqlViewName ColumnComparisionInfo = "[SqlStore].[ColumnComparisionInfo]";
        public readonly static SqlViewName TableQueryColumnInfo = "[SqlStore].[TableQueryColumnInfo]";
    }

    [SqlView("SqlStore", "ColumnComparisionInfo")]
    public partial class ColumnComparisionInfo : SqlViewProxy
    {
        [SqlColumn("QueryId", 0), SqlTypeFacets("int", false)]
        public int QueryId
        {
            get;
            set;
        }

        [SqlColumn("QueryName", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string QueryName
        {
            get;
            set;
        }

        [SqlColumn("TableCatalog", 2), SqlTypeFacets("sysname", true)]
        public string TableCatalog
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 3), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("TableAlias", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string TableAlias
        {
            get;
            set;
        }

        [SqlColumn("StoreKey", 6), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 7), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 8), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("ColumnAlias", 9), SqlTypeFacets("nvarchar", true, 128)]
        public string ColumnAlias
        {
            get;
            set;
        }

        [SqlColumn("ComparisonId", 10), SqlTypeFacets("int", false)]
        public int ComparisonId
        {
            get;
            set;
        }

        [SqlColumn("Operand", 11), SqlTypeFacets("sql_variant", false)]
        public Object Operand
        {
            get;
            set;
        }

        [SqlColumn("ComparisonOp", 12), SqlTypeFacets("nvarchar", false, 5)]
        public string ComparisonOp
        {
            get;
            set;
        }

        public ColumnComparisionInfo()
        {
        }

        public ColumnComparisionInfo(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
            StoreKey = (int)items[6];
            ColumnName = (string)items[7];
            ColumnPosition = (int)items[8];
            ColumnAlias = (string)items[9];
            ComparisonId = (int)items[10];
            Operand = (Object)items[11];
            ComparisonOp = (string)items[12];
        }

        public ColumnComparisionInfo(int QueryId, string QueryName, string TableCatalog, string TableSchema, string TableName, string TableAlias, int StoreKey, string ColumnName, int ColumnPosition, string ColumnAlias, int ComparisonId, Object Operand, string ComparisonOp)
        {
            this.QueryId = QueryId;
            this.QueryName = QueryName;
            this.TableCatalog = TableCatalog;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.TableAlias = TableAlias;
            this.StoreKey = StoreKey;
            this.ColumnName = ColumnName;
            this.ColumnPosition = ColumnPosition;
            this.ColumnAlias = ColumnAlias;
            this.ComparisonId = ComparisonId;
            this.Operand = Operand;
            this.ComparisonOp = ComparisonOp;
        }

        public override object[] GetItemArray()
        {
            return new object[] { QueryId, QueryName, TableCatalog, TableSchema, TableName, TableAlias, StoreKey, ColumnName, ColumnPosition, ColumnAlias, ComparisonId, Operand, ComparisonOp };
        }

        public override void SetItemArray(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
            StoreKey = (int)items[6];
            ColumnName = (string)items[7];
            ColumnPosition = (int)items[8];
            ColumnAlias = (string)items[9];
            ComparisonId = (int)items[10];
            Operand = (Object)items[11];
            ComparisonOp = (string)items[12];
        }
    }

    [SqlView("SqlStore", "TableQueryColumnInfo")]
    public partial class TableQueryColumnInfo : SqlViewProxy
    {
        [SqlColumn("QueryId", 0), SqlTypeFacets("int", false)]
        public int QueryId
        {
            get;
            set;
        }

        [SqlColumn("QueryName", 1), SqlTypeFacets("nvarchar", false, 250)]
        public string QueryName
        {
            get;
            set;
        }

        [SqlColumn("TableCatalog", 2), SqlTypeFacets("sysname", true)]
        public string TableCatalog
        {
            get;
            set;
        }

        [SqlColumn("TableSchema", 3), SqlTypeFacets("sysname", true)]
        public string TableSchema
        {
            get;
            set;
        }

        [SqlColumn("TableName", 4), SqlTypeFacets("sysname", true)]
        public string TableName
        {
            get;
            set;
        }

        [SqlColumn("TableAlias", 5), SqlTypeFacets("nvarchar", true, 128)]
        public string TableAlias
        {
            get;
            set;
        }

        [SqlColumn("StoreKey", 6), SqlTypeFacets("int", false)]
        public int StoreKey
        {
            get;
            set;
        }

        [SqlColumn("ColumnName", 7), SqlTypeFacets("sysname", true)]
        public string ColumnName
        {
            get;
            set;
        }

        [SqlColumn("ColumnPosition", 8), SqlTypeFacets("int", false)]
        public int ColumnPosition
        {
            get;
            set;
        }

        [SqlColumn("ColumnAlias", 9), SqlTypeFacets("nvarchar", true, 128)]
        public string ColumnAlias
        {
            get;
            set;
        }

        public TableQueryColumnInfo()
        {
        }

        public TableQueryColumnInfo(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
            StoreKey = (int)items[6];
            ColumnName = (string)items[7];
            ColumnPosition = (int)items[8];
            ColumnAlias = (string)items[9];
        }

        public TableQueryColumnInfo(int QueryId, string QueryName, string TableCatalog, string TableSchema, string TableName, string TableAlias, int StoreKey, string ColumnName, int ColumnPosition, string ColumnAlias)
        {
            this.QueryId = QueryId;
            this.QueryName = QueryName;
            this.TableCatalog = TableCatalog;
            this.TableSchema = TableSchema;
            this.TableName = TableName;
            this.TableAlias = TableAlias;
            this.StoreKey = StoreKey;
            this.ColumnName = ColumnName;
            this.ColumnPosition = ColumnPosition;
            this.ColumnAlias = ColumnAlias;
        }

        public override object[] GetItemArray()
        {
            return new object[] { QueryId, QueryName, TableCatalog, TableSchema, TableName, TableAlias, StoreKey, ColumnName, ColumnPosition, ColumnAlias };
        }

        public override void SetItemArray(object[] items)
        {
            QueryId = (int)items[0];
            QueryName = (string)items[1];
            TableCatalog = (string)items[2];
            TableSchema = (string)items[3];
            TableName = (string)items[4];
            TableAlias = (string)items[5];
            StoreKey = (int)items[6];
            ColumnName = (string)items[7];
            ColumnPosition = (int)items[8];
            ColumnAlias = (string)items[9];
        }
    }
}
// Emission concluded at 5/12/2018 8:42:10 PM
