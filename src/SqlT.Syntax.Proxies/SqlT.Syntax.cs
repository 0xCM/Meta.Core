//This file was generated at 7/5/2018 8:16:29 PM using version 1.1.4.0 the SqT data access toolset.
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class SyntaxTableTypeNames
    {
        public const string Choice = "[Syntax].[Choice]";
        public const string DataType = "[Syntax].[DataType]";
        public const string Keyword = "[Syntax].[Keyword]";
        public const string NativeFunction = "[Syntax].[NativeFunction]";
        public const string ObjectType = "[Syntax].[ObjectType]";
    }

    public sealed class SyntaxProcedureNames
    {
        public const string SyncChoices = "[Syntax].[SyncChoices]";
        public const string SyncKeywords = "[Syntax].[SyncKeywords]";
        public const string SyncNativeFunctions = "[Syntax].[SyncNativeFunctions]";
        public const string SyncObjectTypes = "[Syntax].[SyncObjectTypes]";
    }

    public sealed class SyntaxTableFunctionNames
    {
        public const string DataTypes = "[Syntax].[DataTypes]";
        public const string Keywords = "[Syntax].[Keywords]";
        public const string NativeFunctions = "[Syntax].[NativeFunctions]";
    }

    [SqlRecord("Syntax", "Keyword")]
    public partial class Keyword : SqlTableTypeProxy<Keyword>
    {
        [SqlColumn("KeywordName", 0), SqlTypeFacets("nvarchar", false)]
        public string KeywordName
        {
            get;
            set;
        }

        [SqlColumn("Description", 1), SqlTypeFacets("nvarchar", true)]
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

        public override void SetItemArray(object[] items)
        {
            KeywordName = (string)items[0];
            Description = (string)items[1];
        }
    }

    [SqlRecord("Syntax", "Choice")]
    public partial class Choice : SqlTableTypeProxy<Choice>
    {
        [SqlColumn("ChoiceName", 0), SqlTypeFacets("nvarchar", false)]
        public string ChoiceName
        {
            get;
            set;
        }

        [SqlColumn("ChoiceValue", 1), SqlTypeFacets("nvarchar", false)]
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

        public override void SetItemArray(object[] items)
        {
            ChoiceName = (string)items[0];
            ChoiceValue = (string)items[1];
        }
    }

    [SqlRecord("Syntax", "ObjectType")]
    public partial class ObjectType : SqlTableTypeProxy<ObjectType>
    {
        [SqlColumn("TypeCode", 0), SqlTypeFacets("nvarchar", false)]
        public string TypeCode
        {
            get;
            set;
        }

        [SqlColumn("TypeDescription", 1), SqlTypeFacets("nvarchar", true)]
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

        public override void SetItemArray(object[] items)
        {
            TypeCode = (string)items[0];
            TypeDescription = (string)items[1];
        }
    }

    [SqlRecord("Syntax", "NativeFunction")]
    public partial class NativeFunction : SqlTableTypeProxy<NativeFunction>
    {
        [SqlColumn("FunctionName", 0), SqlTypeFacets("nvarchar", false)]
        public string FunctionName
        {
            get;
            set;
        }

        [SqlColumn("Description", 1), SqlTypeFacets("nvarchar", true)]
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

        public override void SetItemArray(object[] items)
        {
            FunctionName = (string)items[0];
            Description = (string)items[1];
        }
    }

    [SqlRecord("Syntax", "DataType")]
    public partial class DataType : SqlTableTypeProxy<DataType>
    {
        [SqlColumn("TypeName", 0), SqlTypeFacets("nvarchar", false)]
        public string TypeName
        {
            get;
            set;
        }

        [SqlColumn("Description", 1), SqlTypeFacets("nvarchar", true)]
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

        public override void SetItemArray(object[] items)
        {
            TypeName = (string)items[0];
            Description = (string)items[1];
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

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<Keyword>)items[0];
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

        public override void SetItemArray(object[] items)
        {
            Choices = (IEnumerable<Choice>)items[0];
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

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<ObjectType>)items[0];
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

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<NativeFunction>)items[0];
        }
    }

    [SqlTableFunction("Syntax", "Keywords")]
    public partial class Keywords : SqlTableFunctionProxy<Keywords, Keyword>
    {
        public Keywords()
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

    [SqlTableFunction("Syntax", "DataTypes")]
    public partial class DataTypes : SqlTableFunctionProxy<DataTypes, DataType>
    {
        public DataTypes()
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
// Emission concluded at 7/5/2018 8:16:30 PM
