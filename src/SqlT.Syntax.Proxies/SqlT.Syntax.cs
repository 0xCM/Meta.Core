//This file was generated at 5/27/2018 10:01:42 AM using version 1.2018.3.11161 the SqT data access toolset.
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SyntaxTableTypeNames
    {
        public readonly static SqlTableTypeName Choice = "[Syntax].[Choice]";
        public readonly static SqlTableTypeName DataType = "[Syntax].[DataType]";
        public readonly static SqlTableTypeName Keyword = "[Syntax].[Keyword]";
        public readonly static SqlTableTypeName NativeFunction = "[Syntax].[NativeFunction]";
        public readonly static SqlTableTypeName ObjectType = "[Syntax].[ObjectType]";
    }

    public sealed class SyntaxProcedureNames
    {
        public readonly static SqlProcedureName SyncChoices = "[Syntax].[SyncChoices]";
        public readonly static SqlProcedureName SyncKeywords = "[Syntax].[SyncKeywords]";
        public readonly static SqlProcedureName SyncNativeFunctions = "[Syntax].[SyncNativeFunctions]";
        public readonly static SqlProcedureName SyncObjectTypes = "[Syntax].[SyncObjectTypes]";
    }

    public sealed class SyntaxTableFunctionNames
    {
        public readonly static SqlFunctionName DataTypes = "[Syntax].[DataTypes]";
        public readonly static SqlFunctionName Keywords = "[Syntax].[Keywords]";
        public readonly static SqlFunctionName NativeFunctions = "[Syntax].[NativeFunctions]";
    }

    [SqlTableFunction("Syntax", "DataTypes")]
    public partial class DataTypes : SqlTableFunctionProxy<DataTypes, DataType>
    {
        public DataTypes()
        {
        }
    }

    [SqlTableFunction("Syntax", "NativeFunctions")]
    public partial class NativeFunctions : SqlTableFunctionProxy<NativeFunctions, NativeFunction>
    {
        public NativeFunctions()
        {
        }
    }

    [SqlTableFunction("Syntax", "Keywords")]
    public partial class Keywords : SqlTableFunctionProxy<Keywords, Keyword>
    {
        public Keywords()
        {
        }
    }

    /// <summary>
    /// Routines defined in the Syntax schema
    /// </summary>
    [SqlOperationContract()]
    public partial interface ISyntaxOperations
    {
        [SqlProcedure("Syntax", "SyncKeywords")]
        SqlOutcome<Int32> SyncKeywords([SqlParameter("@Records", 0, true, false), SqlTypeFacets("[Syntax].[Keyword]", true)] IEnumerable<Keyword> Records);
        [SqlProcedure("Syntax", "SyncChoices")]
        SqlOutcome<Int32> SyncChoices([SqlParameter("@Choices", 0, true, false), SqlTypeFacets("[Syntax].[Choice]", true)] IEnumerable<Choice> Choices);
        [SqlProcedure("Syntax", "SyncObjectTypes")]
        SqlOutcome<Int32> SyncObjectTypes([SqlParameter("@Records", 0, true, false), SqlTypeFacets("[Syntax].[ObjectType]", true)] IEnumerable<ObjectType> Records);
        [SqlProcedure("Syntax", "SyncNativeFunctions")]
        SqlOutcome<Int32> SyncNativeFunctions([SqlParameter("@Records", 0, true, false), SqlTypeFacets("[Syntax].[NativeFunction]", true)] IEnumerable<NativeFunction> Records);
        [SqlTableFunction("Syntax", "Keywords")]
        SqlOutcome<IReadOnlyList<Keyword>> Keywords();
        [SqlTableFunction("Syntax", "NativeFunctions")]
        SqlOutcome<IReadOnlyList<NativeFunction>> NativeFunctions();
        [SqlTableFunction("Syntax", "DataTypes")]
        SqlOutcome<IReadOnlyList<DataType>> DataTypes();
    }

    [SqlRecord("Syntax", "DataType")]
    public partial class DataType : SqlTableTypeProxy<DataType>
    {
        [SqlColumn("TypeName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("Description", 1), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public DataType()
        {
        }

        public DataType(object[] items)
        {
            TypeName = (string)items[0];
            Description = (string)items[1];
        }

        public DataType(string TypeName, string Description)
        {
            this.TypeName = TypeName;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeName, Description };
        }
    }

    [SqlRecord("Syntax", "NativeFunction")]
    public partial class NativeFunction : SqlTableTypeProxy<NativeFunction>
    {
        [SqlColumn("FunctionName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string FunctionName
        {
            get;
            set;
        }

        [SqlColumn("Description", 1), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public NativeFunction()
        {
        }

        public NativeFunction(object[] items)
        {
            FunctionName = (string)items[0];
            Description = (string)items[1];
        }

        public NativeFunction(string FunctionName, string Description)
        {
            this.FunctionName = FunctionName;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FunctionName, Description };
        }
    }

    [SqlRecord("Syntax", "ObjectType")]
    public partial class ObjectType : SqlTableTypeProxy<ObjectType>
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("nvarchar", false, 75)]
        public string TypeCode
        {
            get;
            set;
        }

        [SqlColumn("TypeDescription", 1), SqlTypeFacets("nvarchar", true, 250)]
        public string TypeDescription
        {
            get;
            set;
        }

        public ObjectType()
        {
        }

        public ObjectType(object[] items)
        {
            TypeCode = (string)items[0];
            TypeDescription = (string)items[1];
        }

        public ObjectType(string TypeCode, string TypeDescription)
        {
            this.TypeCode = TypeCode;
            this.TypeDescription = TypeDescription;
        }

        public override object[] GetItemArray()
        {
            return new object[] { TypeCode, TypeDescription };
        }
    }

    [SqlRecord("Syntax", "Choice")]
    public partial class Choice : SqlTableTypeProxy<Choice>
    {
        [SqlColumn("ChoiceName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string ChoiceName
        {
            get;
            set;
        }

        [SqlColumn("ChoiceValue", 1), SqlTypeFacets("nvarchar", false, 128)]
        public string ChoiceValue
        {
            get;
            set;
        }

        public Choice()
        {
        }

        public Choice(object[] items)
        {
            ChoiceName = (string)items[0];
            ChoiceValue = (string)items[1];
        }

        public Choice(string ChoiceName, string ChoiceValue)
        {
            this.ChoiceName = ChoiceName;
            this.ChoiceValue = ChoiceValue;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ChoiceName, ChoiceValue };
        }
    }

    [SqlRecord("Syntax", "Keyword")]
    public partial class Keyword : SqlTableTypeProxy<Keyword>
    {
        [SqlColumn("KeywordName", 0), SqlTypeFacets("nvarchar", false, 128)]
        public string KeywordName
        {
            get;
            set;
        }

        [SqlColumn("Description", 1), SqlTypeFacets("nvarchar", true, 250)]
        public string Description
        {
            get;
            set;
        }

        public Keyword()
        {
        }

        public Keyword(object[] items)
        {
            KeywordName = (string)items[0];
            Description = (string)items[1];
        }

        public Keyword(string KeywordName, string Description)
        {
            this.KeywordName = KeywordName;
            this.Description = Description;
        }

        public override object[] GetItemArray()
        {
            return new object[] { KeywordName, Description };
        }
    }

    [SqlProcedure("Syntax", "SyncNativeFunctions")]
    public partial class SyncNativeFunctions : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[Syntax].[NativeFunction]", true)]
        public IEnumerable<NativeFunction> Records
        {
            get;
            set;
        }

        public SyncNativeFunctions()
        {
        }

        public SyncNativeFunctions(object[] items)
        {
            Records = (IEnumerable<NativeFunction>)items[0];
        }

        public SyncNativeFunctions(IEnumerable<NativeFunction> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }
    }

    [SqlProcedure("Syntax", "SyncObjectTypes")]
    public partial class SyncObjectTypes : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[Syntax].[ObjectType]", true)]
        public IEnumerable<ObjectType> Records
        {
            get;
            set;
        }

        public SyncObjectTypes()
        {
        }

        public SyncObjectTypes(object[] items)
        {
            Records = (IEnumerable<ObjectType>)items[0];
        }

        public SyncObjectTypes(IEnumerable<ObjectType> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }
    }

    [SqlProcedure("Syntax", "SyncChoices")]
    public partial class SyncChoices : SqlProcedureProxy
    {
        [SqlParameter("@Choices", 0, true, false), SqlTypeFacets("[Syntax].[Choice]", true)]
        public IEnumerable<Choice> Choices
        {
            get;
            set;
        }

        public SyncChoices()
        {
        }

        public SyncChoices(object[] items)
        {
            Choices = (IEnumerable<Choice>)items[0];
        }

        public SyncChoices(IEnumerable<Choice> Choices)
        {
            this.Choices = Choices;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Choices };
        }
    }

    [SqlProcedure("Syntax", "SyncKeywords")]
    public partial class SyncKeywords : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[Syntax].[Keyword]", true)]
        public IEnumerable<Keyword> Records
        {
            get;
            set;
        }

        public SyncKeywords()
        {
        }

        public SyncKeywords(object[] items)
        {
            Records = (IEnumerable<Keyword>)items[0];
        }

        public SyncKeywords(IEnumerable<Keyword> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }
    }
}
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    [SqlProxyBrokerFactory]
    class ProxyBrokerFactory : SqlProxyBrokerFactory<ProxyBrokerFactory>
    {
        /// <summary>
                /// The name of the catalog that provided the source metadata from
                /// which the proxies were constructed
                /// </summary>
        public const string SourceCatalog = @"SqlT.Syntax";
        public static new ISqlProxyBroker CreateBroker(SqlConnectionString cs) => ((SqlProxyBrokerFactory<ProxyBrokerFactory>)(new ProxyBrokerFactory())).CreateBroker(cs);
    }
}
// Emission concluded at 5/27/2018 10:01:44 AM
