//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;
    using System.ComponentModel;

    /// <summary>
    /// Specifies a schema, and related options, to include for consideration during the proxy generation process
    /// </summary>
    [
        Description("Specifies a schema to include for consideration during the proxy generation process")
    ]
    public class SqlProxySchemaSelection
    {
        public static implicit operator SqlProxySchemaSelection(string SchemaName)
            => new SqlProxySchemaSelection(SchemaName, true);

        public static SqlProxySchemaSelection[] Select(params string[] SchemaNames)
            => SchemaNames.Select(n => new SqlProxySchemaSelection(n,true)).ToArray();

        public SqlProxySchemaSelection()
        {
            SchemaName = string.Empty;
            SpecializeNamespace = true;
            ImplicitTableContractNames = new string[] { };
            ImplicitTableContractExclusions = new string[] { };
            OperationContractName = string.Empty;
            LiteralClassNamePrefix = String.Empty;
            ProxySchemaName = String.Empty;
        }

        public SqlProxySchemaSelection(string SchemaName, bool SpecializeNamespace, string OperationContractName = null)
            : this()
        {
            this.SchemaName = SchemaName;
            this.SpecializeNamespace = SpecializeNamespace;
            this.OperationContractName = OperationContractName;

        }

        /// <summary>
        /// The names of the interfaces, if any, that the table proxies should implicitly realize
        /// </summary>
        [
            Description("The names of the interfaces, if any, that the table proxies should implicitly realize"),
        ]
        public string[] ImplicitTableContractNames { get; set; }


        /// <summary>
        /// The tables that will be excluded from realizing any implicit table contracts specified for the schema
        /// </summary>
        [
            Description("The tables that will be excluded from realizing any implicit table contracts specified for the schema")
        ]
        public string[] ImplicitTableContractExclusions { get; set; }

        /// <summary>
        /// The name of the selected schema
        /// </summary>
        [
            Description("The name of the selected schema"),
        ]
        public string SchemaName { get; set; }

        /// <summary>
        /// The emitted schema name, if specified; otherwise, SchemaName is used
        /// </summary>
        [
            Description("The emitted schema name, if specified; otherwise, SchemaName is used"),
        ]
        public string ProxySchemaName { get; set; }
        
        /// <summary>
        /// Determines whether the proxies should be emitted into a namespace directly below a chosen root namespace and
        /// eponymous with the name of the schema
        /// </summary>
        [
            Description("Determines whether the proxies should be emitted into a namespace directly below the root namespace and eponymous with the name of the schema"),
            DefaultValue(true)
        ]
        public bool SpecializeNamespace { get; set; }

        /// <summary>
        /// The name of the operation contract that will be defined for routines in the schema
        /// </summary>
        [
            Description("The name of the operation contract that will be defined for routines in the schema"),
        ]
        public string OperationContractName { get; set; }

        /// <summary>
        /// The name upon which the literal element name classes are based
        /// </summary>
        [
            Description("The name upon which the literal element name classes are based"),
        ]
        public string LiteralClassNamePrefix { get; set; }

        /// <summary>
        /// Specifies the name that should be used for the schema proxy
        /// </summary>
        public string EmittedSchemaName()
            => String.IsNullOrWhiteSpace(ProxySchemaName) 
            ? SchemaName 
            : ProxySchemaName;

        public override string ToString()
            => SchemaName;
    }


}