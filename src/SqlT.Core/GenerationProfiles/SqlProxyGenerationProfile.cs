//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using static metacore;

    /// <summary>
    /// Defines settings that modulate the proxy generation process
    /// </summary>
    [Description("Defines settings that modulate the proxy generation process")]
    public class SqlProxyGenerationProfile : CodeGenerationProfile
    {

        void SetDefaults()
        {
            ProfileType = CodeGenerationProfileKind.Default;
            ExcludedColumns = new string[] { };
            Schemas = new SqlProxySchemaSelection[] { };

            AlwaysEmitNames = false;

            EmitIndexes = false;
            EmitIndexNames = false;

            EmitPrimaryKeys = false;
            EmitPrimaryKeyNames = false;

            EmitTables = true;
            EmitTableNames = true;

            EmitViews = true;
            EmitViewNames = true;

            EmitTableTypes = true;
            EmitTableTypeNames = true;

            EmitStoredProcedures = true;
            EmitStoredProcedureNames = true;

            EmitSequences = true;
            EmitSequenceNames = true;           

            ExcludeSystemObjects = true;

            EmitTableFunctions = true;
            EmitSingleFile = true;

            EmitTypeContracts = true;            
            EmitOperationContracts = true;
            EmitServiceBrokerTypes = false;

            EmitEnums = false;
            EmitBrokerFactory = true;
            BrokerFactoryName = "ProxyBrokerFactory";
            BrokerFactoryFileName = "BF.cs";
            SqlVersionCompatibility = "13.00";

        }

        public SqlProxyGenerationProfile()
            => SetDefaults();
        

        public SqlProxyGenerationProfile
        (
            string Name,
            FolderPath OutputDirectory,
            string AssemblyDesignatorName,
            string RootNamespace,
            params SqlProxySchemaSelection[] Schemas
        ): base(Name, OutputDirectory, AssemblyDesignatorName, RootNamespace)
        {
            SetDefaults();
            this.Schemas = Schemas;
            this.ExcludedColumns = array("DbCreateUser", "DbCreateTime", "DbUpdateUser", "DbUpdateTime");
            this.DefaultUsings = array("System", "System.Collections.Generic");
        }


        /// <summary>
        /// Specifies whether names of elements in the specified schemas should be emitted irrespective of whether proxies of the elements are generated
        /// </summary>
        [
            Description("Specifies whether names of elements in the specified schemas should be emitted irrespective of whether proxies of the elements are generated")
        ]
        public bool AlwaysEmitNames { get; set; }

        /// <summary>
        /// Schemas that will be included for consideration during the generation process
        /// </summary>
        [
            Description("Schemas that will be included for consideration during the generation process")    
        ]
        public SqlProxySchemaSelection[] Schemas { get; set; }


        /// <summary>
        /// The columns that will be ignored during the generation process
        /// </summary>
        [
            Description("The columns that will be ignored during the generation process")
        ]
        public string[] ExcludedColumns { get; set; }

        /// <summary>
        /// Specifies whether system objects, such as catalog views and other intrinsics should be ignored
        /// </summary>
        [
            Description("Specifies whether system objects, such as catalog views and other intrinsics should be ignored")
        ]
        public bool ExcludeSystemObjects { get; set; }

        /// <summary>
        /// Specifies whether types representing tables should be generated
        /// </summary>
        [
            Description("Specifies whether types representing tables should be generated")
        ]
        public bool EmitTables { get; set; }

        /// <summary>
        /// Specifies whether types representing enumerations should be generated
        /// </summary>
        [
            Description("Specifies whether types representing enumerations should be generated")
        ]
        public bool EmitEnums { get; set; }

        /// <summary>
        /// Specifies whether table name lists should be emitted, but ignored if AlwaysEmitNames is true
        /// </summary>
        [
            Description("Specifies whether table name lists should be emitted, but ignored if AlwaysEmitNames is true")
        ]
        public bool EmitTableNames { get; set; }

        /// <summary>
        /// Specifies whether types representing views should be generated
        /// </summary>
        [
            Description("Specifies whether types representing views should be generated")
        ]
        public bool EmitViews { get; set; }

        /// <summary>
        /// Specifies whether view name lists should be emitted, but ignored if AlwaysEmitNames is true
        /// </summary>
        [
            Description("Specifies whether view name lists should be emitted, but ignored if AlwaysEmitNames is true")
        ]
        public bool EmitViewNames { get; set; }


        /// <summary>
        /// Specifies whether types representing service broker message types should be generated
        /// </summary>
        [
            Description("Specifies whether types representing service broker aspects should be generated")
        ]
        public bool EmitServiceBrokerTypes { get; set; }

        /// <summary>
        /// Specifies whether types representing primary keys should be generated
        /// </summary>
        [
            Description("Specifies whether types representing primary keys should be generated")
        ]
        public bool EmitPrimaryKeys { get; set; }

        /// <summary>
        /// Specifies whether primary key name lists should be emitted, but ignored if AlwaysEmitNames is true
        /// </summary>
        [
            Description("Specifies whether primary key name lists should be emitted, but ignored if AlwaysEmitNames is true")
        ]
        public bool EmitPrimaryKeyNames { get; set; }

        /// <summary>
        /// Specifies whether types representing indexes should be emitted
        /// </summary>
        [
            Description("Specifies whether types representing indexes should be emitted"),
            DefaultValue(false)
        ]
        public bool EmitIndexes { get; set; }

        /// <summary>
        /// Specifies whether index name lists should be emitted, but ignored if AlwaysEmitNames is true
        /// </summary>
        [
            Description("Specifies whether index name lists should be emitted, but ignored if AlwaysEmitNames is true"),
            DefaultValue(false)
        ]
        public bool EmitIndexNames { get; set; }

        /// <summary>
        /// Specifies whether types and interface contracts related to stored procedures should be emitted
        /// </summary>
        [
            Description("Specifies whether types and interface contracts related to stored procedures should be emitted"),
            DefaultValue(true)
        ]
        public bool EmitStoredProcedures { get; set; }

        /// <summary>
        /// Specifies whether stored procedure name lists should be emitted, but ignored if AlwaysEmitNames is true
        /// </summary>
        [
            Description("Specifies whether stored procedure name lists should be emitted, but ignored if AlwaysEmitNames is true")
        ]
        public bool EmitStoredProcedureNames { get; set; }

        /// <summary>
        /// Specifies whether types and interface contracts related to TVF's should be emitted
        /// </summary>
        [
            Description("Specifies whether types and interface contracts related to TVF's should be emitted"),
            DefaultValue(true)
        ]
        public bool EmitTableFunctions { get; set; }

        /// <summary>
        /// Specifies whether types representing UDTT's should be emitted
        /// </summary>
        [
            Description("Specifies whether types representing UDTT's should be emitted"),
            DefaultValue(true)
        ]
        public bool EmitTableTypes { get; set; }

        /// <summary>
        /// Specifies whether item name lists for UDTT's should be emitted, but ignored if AlwaysEmitNames is true
        /// </summary>
        [
            Description("Specifies whether types representing UDTT's should be emitted, but ignored if AlwaysEmitNames is true"),
            DefaultValue(true)
        ]
        public bool EmitTableTypeNames { get; set; }

        /// <summary>
        /// Specifies whether generated artifacts related to SQL Sequences should be produced
        /// </summary>
        /// <remarks>
        /// This currently only impacts whether a class gets emitted that defines literals corresponding to the names of the defined sequences
        /// </remarks>
        [
            Description("Specifies whether generated artifacts related to SQL Sequences should be produced"),
            DefaultValue(true)
        ]
        public bool EmitSequences { get; set; }

        /// <summary>
        /// Specifies whether sequence name lists should be emitted, but ignored if AlwaysEmitNames is true
        /// </summary>
        [
            Description("Specifies whether sequence name lists should be emitted, but ignored if AlwaysEmitNames is true"),
            DefaultValue(true)
        ]
        public bool EmitSequenceNames { get; set; }



        /// <summary>
        /// Specifies whether to emit operation contracts that define signature proxies for procedures and functions
        /// </summary>
        [
            Description("Specifies whether to emit operation contracts that define signature proxies for procedures and functions"),
            DefaultValue(true)
        ]
        public bool EmitOperationContracts { get; set; }

        /// <summary>
        /// Specifies whether to emit a broker factory
        /// </summary>
        [
            Description("Specifies whether to emit a broker factory"),
            DefaultValue(true)
        ]
        public bool EmitBrokerFactory { get; set; }

        /// <summary>
        /// The name of the broker factory, scoped to the root namespace, if applicable
        /// </summary>
        [
            Description("The name of the broker factory, scoped to the root namespace, if applicable"),
            DefaultValue("ProxyBrokerFactory")
        ]
        public string BrokerFactoryName { get; set; }

        /// <summary>
        /// The name of the broker factory, scoped to the root namespace, if applicable
        /// </summary>
        [
            Description("The name of the broker factory output file, if applicable"),
            DefaultValue("BF.cs")
        ]
        public string BrokerFactoryFileName { get; set; }

        /// <summary>
        /// The minimum SQL Server version with which the proxies should be compatible
        /// </summary>
        [
            Description("The minimum SQL Server version with which the proxies should be compatible"),
            DefaultValue(SqlVersionNames.Sql2016)
        ]
        public string SqlVersionCompatibility { get; set; }

        /// <summary>
        /// Specifies whether to emit operation contract implementations
        /// </summary>
        /// <remarks>
        /// This is a TODO item; currently contract implementations are specified by-hand
        /// </remarks>
        [
            Description("Specifies whether to emit operation contract implementations; is ignored if EmitOperationContracts is FALSE"), 
            DefaultValue(false)
        ]
        public bool EmitOperationImplementations { get; set; }

        /// <summary>
        /// Gets the names of the selected schemas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> SchemaNames()
            => Schemas.Select(x => x.SchemaName);

        public IReadOnlyDictionary<SqlSchemaName, SqlProxySchemaSelection> SchemaIndex()
            => Schemas.ToDictionary(x => new SqlSchemaName(x.SchemaName));

        public string ServerName()
            => SqlConnectionString.Parse(ConnectionString).ServerName;

        public string DatabaseName()
            => SqlConnectionString.Parse(ConnectionString).DatabaseName;

        public override string ToString()
            => concat(Name, space(), 
                bracket(ServerName()), dot(), bracket(DatabaseName()), 
                "(", join(",", SchemaNames().ToArray()), ")");



    }

}