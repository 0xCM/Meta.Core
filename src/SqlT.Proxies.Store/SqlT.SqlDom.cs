//This file was generated at 5/12/2018 8:42:25 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.SqlStore.SqlDom
{
    using SqlT.Types.SqlDom;
    using SqlT.Types;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SqlDomSequenceNames
    {
        public readonly static SqlSequenceName DocumentSequence = "[SqlDom].[DocumentSequence]";
        public readonly static SqlSequenceName ElementSequence = "[SqlDom].[ElementSequence]";
        public readonly static SqlSequenceName ScriptXmlSequence = "[SqlDom].[ScriptXmlSequence]";
    }

    public sealed class SqlDomProcedureNames
    {
        public readonly static SqlProcedureName LoadScripts = "[SqlDom].[LoadScripts]";
        public readonly static SqlProcedureName LoadScriptXml = "[SqlDom].[LoadScriptXml]";
        public readonly static SqlProcedureName SyncAssociations = "[SqlDom].[SyncAssociations]";
        public readonly static SqlProcedureName SyncAttributes = "[SqlDom].[SyncAttributes]";
        public readonly static SqlProcedureName SyncCollections = "[SqlDom].[SyncCollections]";
        public readonly static SqlProcedureName SyncDataTypes = "[SqlDom].[SyncDataTypes]";
        public readonly static SqlProcedureName SyncElements = "[SqlDom].[SyncElements]";
        public readonly static SqlProcedureName SyncEnumLiterals = "[SqlDom].[SyncEnumLiterals]";
    }

    [SqlProcedure("SqlDom", "SyncCollections")]
    public partial class SyncCollections : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[SqlDom].[Collection]", true)]
        public IEnumerable<Collection> Records
        {
            get;
            set;
        }

        public SyncCollections()
        {
        }

        public SyncCollections(object[] items)
        {
            Records = (IEnumerable<Collection>)items[0];
        }

        public SyncCollections(IEnumerable<Collection> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<Collection>)items[0];
        }
    }

    [SqlProcedure("SqlDom", "SyncAttributes")]
    public partial class SyncAttributes : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[SqlDom].[ElementAttribute]", true)]
        public IEnumerable<ElementAttribute> Records
        {
            get;
            set;
        }

        public SyncAttributes()
        {
        }

        public SyncAttributes(object[] items)
        {
            Records = (IEnumerable<ElementAttribute>)items[0];
        }

        public SyncAttributes(IEnumerable<ElementAttribute> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<ElementAttribute>)items[0];
        }
    }

    [SqlProcedure("SqlDom", "SyncAssociations")]
    public partial class SyncAssociations : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[SqlDom].[Association]", true)]
        public IEnumerable<Association> Records
        {
            get;
            set;
        }

        public SyncAssociations()
        {
        }

        public SyncAssociations(object[] items)
        {
            Records = (IEnumerable<Association>)items[0];
        }

        public SyncAssociations(IEnumerable<Association> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<Association>)items[0];
        }
    }

    [SqlProcedure("SqlDom", "SyncElements")]
    public partial class SyncElements : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[SqlDom].[Element]", true)]
        public IEnumerable<Element> Records
        {
            get;
            set;
        }

        public SyncElements()
        {
        }

        public SyncElements(object[] items)
        {
            Records = (IEnumerable<Element>)items[0];
        }

        public SyncElements(IEnumerable<Element> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<Element>)items[0];
        }
    }

    [SqlProcedure("SqlDom", "SyncEnumLiterals")]
    public partial class SyncEnumLiterals : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[SqlDom].[EnumLiteral]", true)]
        public IEnumerable<EnumLiteral> Records
        {
            get;
            set;
        }

        public SyncEnumLiterals()
        {
        }

        public SyncEnumLiterals(object[] items)
        {
            Records = (IEnumerable<EnumLiteral>)items[0];
        }

        public SyncEnumLiterals(IEnumerable<EnumLiteral> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<EnumLiteral>)items[0];
        }
    }

    [SqlProcedure("SqlDom", "LoadScripts")]
    public partial class LoadScripts : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[SqlDom].[ScriptDocument]", true)]
        public IEnumerable<ScriptDocument> Records
        {
            get;
            set;
        }

        public LoadScripts()
        {
        }

        public LoadScripts(object[] items)
        {
            Records = (IEnumerable<ScriptDocument>)items[0];
        }

        public LoadScripts(IEnumerable<ScriptDocument> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<ScriptDocument>)items[0];
        }
    }

    [SqlProcedure("SqlDom", "SyncDataTypes")]
    public partial class SyncDataTypes : SqlProcedureProxy
    {
        public SyncDataTypes()
        {
        }
    }

    [SqlProcedure("SqlDom", "LoadScriptXml")]
    public partial class LoadScriptXml : SqlProcedureProxy
    {
        [SqlParameter("@ScriptXml", 0, true, false), SqlTypeFacets("[SqlDom].[ScriptXml]", true)]
        public IEnumerable<ScriptXml> ScriptXml
        {
            get;
            set;
        }

        public LoadScriptXml()
        {
        }

        public LoadScriptXml(object[] items)
        {
            ScriptXml = (IEnumerable<ScriptXml>)items[0];
        }

        public LoadScriptXml(IEnumerable<ScriptXml> ScriptXml)
        {
            this.ScriptXml = ScriptXml;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ScriptXml };
        }

        public override void SetItemArray(object[] items)
        {
            ScriptXml = (IEnumerable<ScriptXml>)items[0];
        }
    }

    public sealed class SqlDomViewNames
    {
        public readonly static SqlViewName ElementLineage = "[SqlDom].[ElementLineage]";
        public readonly static SqlViewName ElementMember = "[SqlDom].[ElementMember]";
        public readonly static SqlViewName EnumElement = "[SqlDom].[EnumElement]";
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
// Emission concluded at 5/12/2018 8:42:26 PM
