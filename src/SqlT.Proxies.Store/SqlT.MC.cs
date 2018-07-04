//This file was generated at 5/12/2018 8:42:26 PM using version 1.2018.3.3482 the SqT data access toolset.
namespace SqlT.SqlStore.MC
{
    using SqlT.Types;
    using SqlT.Types.MC;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class MCProcedureNames
    {
        public readonly static SqlProcedureName DefineIntrinsicProjectTypes = "[MC].[DefineIntrinsicProjectTypes]";
        public readonly static SqlProcedureName StoreXsdDocuments = "[MC].[StoreXsdDocuments]";
        public readonly static SqlProcedureName SyncCoreDataTypes = "[MC].[SyncCoreDataTypes]";
        public readonly static SqlProcedureName SyncDistributionRegistry = "[MC].[SyncDistributionRegistry]";
        public readonly static SqlProcedureName SyncProjectVariables = "[MC].[SyncProjectVariables]";
        public readonly static SqlProcedureName SyncToolRegistry = "[MC].[SyncToolRegistry]";
    }

    [SqlProcedure("MC", "SyncToolRegistry")]
    public partial class SyncToolRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Entries", 0, true, false), SqlTypeFacets("[MC].[ToolRegistration]", true)]
        public IEnumerable<ToolRegistration> Entries
        {
            get;
            set;
        }

        public SyncToolRegistry()
        {
        }

        public SyncToolRegistry(object[] items)
        {
            Entries = (IEnumerable<ToolRegistration>)items[0];
        }

        public SyncToolRegistry(IEnumerable<ToolRegistration> Entries)
        {
            this.Entries = Entries;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Entries };
        }

        public override void SetItemArray(object[] items)
        {
            Entries = (IEnumerable<ToolRegistration>)items[0];
        }
    }

    [SqlProcedure("MC", "SyncDistributionRegistry")]
    public partial class SyncDistributionRegistry : SqlProcedureProxy
    {
        [SqlParameter("@Distributions", 0, true, false), SqlTypeFacets("[MC].[DistributionMoniker]", true)]
        public IEnumerable<DistributionMoniker> Distributions
        {
            get;
            set;
        }

        public SyncDistributionRegistry()
        {
        }

        public SyncDistributionRegistry(object[] items)
        {
            Distributions = (IEnumerable<DistributionMoniker>)items[0];
        }

        public SyncDistributionRegistry(IEnumerable<DistributionMoniker> Distributions)
        {
            this.Distributions = Distributions;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Distributions };
        }

        public override void SetItemArray(object[] items)
        {
            Distributions = (IEnumerable<DistributionMoniker>)items[0];
        }
    }

    [SqlProcedure("MC", "StoreXsdDocuments")]
    public partial class StoreXsdDocuments : SqlProcedureProxy
    {
        [SqlParameter("@Documents", 0, true, false), SqlTypeFacets("[MC].[XsdDocument]", true)]
        public IEnumerable<XsdDocument> Documents
        {
            get;
            set;
        }

        public StoreXsdDocuments()
        {
        }

        public StoreXsdDocuments(object[] items)
        {
            Documents = (IEnumerable<XsdDocument>)items[0];
        }

        public StoreXsdDocuments(IEnumerable<XsdDocument> Documents)
        {
            this.Documents = Documents;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Documents };
        }

        public override void SetItemArray(object[] items)
        {
            Documents = (IEnumerable<XsdDocument>)items[0];
        }
    }

    [SqlProcedure("MC", "SyncProjectVariables")]
    public partial class SyncProjectVariables : SqlProcedureProxy
    {
        [SqlParameter("@ProjectId", 0, false, false), SqlTypeFacets("nvarchar", true, 75)]
        public string ProjectId
        {
            get;
            set;
        }

        [SqlParameter("@Variables", 1, true, false), SqlTypeFacets("[MC].[ProjectVariable]", true)]
        public IEnumerable<ProjectVariable> Variables
        {
            get;
            set;
        }

        public SyncProjectVariables()
        {
        }

        public SyncProjectVariables(object[] items)
        {
            ProjectId = (string)items[0];
            Variables = (IEnumerable<ProjectVariable>)items[1];
        }

        public SyncProjectVariables(string ProjectId, IEnumerable<ProjectVariable> Variables)
        {
            this.ProjectId = ProjectId;
            this.Variables = Variables;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ProjectId, Variables };
        }

        public override void SetItemArray(object[] items)
        {
            ProjectId = (string)items[0];
            Variables = (IEnumerable<ProjectVariable>)items[1];
        }
    }

    [SqlProcedure("MC", "SyncCoreDataTypes")]
    public partial class SyncCoreDataTypes : SqlProcedureProxy
    {
        [SqlParameter("@Records", 0, true, false), SqlTypeFacets("[MC].[CoreDataTypeInfo]", true)]
        public IEnumerable<CoreDataTypeInfo> Records
        {
            get;
            set;
        }

        public SyncCoreDataTypes()
        {
        }

        public SyncCoreDataTypes(object[] items)
        {
            Records = (IEnumerable<CoreDataTypeInfo>)items[0];
        }

        public SyncCoreDataTypes(IEnumerable<CoreDataTypeInfo> Records)
        {
            this.Records = Records;
        }

        public override object[] GetItemArray()
        {
            return new object[] { Records };
        }

        public override void SetItemArray(object[] items)
        {
            Records = (IEnumerable<CoreDataTypeInfo>)items[0];
        }
    }

    [SqlProcedure("MC", "DefineIntrinsicProjectTypes")]
    public partial class DefineIntrinsicProjectTypes : SqlProcedureProxy
    {
        public DefineIntrinsicProjectTypes()
        {
        }
    }

    public sealed class MCTableFunctionNames
    {
        public readonly static SqlFunctionName ProjectVariables = "[MC].[ProjectVariables]";
    }

    [SqlTableFunction("MC", "ProjectVariables")]
    public partial class ProjectVariables : SqlTableFunctionProxy<ProjectVariables, ProjectVariable>
    {
        [SqlParameter("@ProjectId", 0, false, false), SqlTypeFacets("nvarchar", true, 75)]
        public string ProjectId
        {
            get;
            set;
        }

        public ProjectVariables()
        {
        }

        public ProjectVariables(object[] items)
        {
            ProjectId = (string)items[0];
        }

        public ProjectVariables(string ProjectId)
        {
            this.ProjectId = ProjectId;
        }

        public override object[] GetItemArray()
        {
            return new object[] { ProjectId };
        }

        public override void SetItemArray(object[] items)
        {
            ProjectId = (string)items[0];
        }
    }
}
// Emission concluded at 5/12/2018 8:42:26 PM
