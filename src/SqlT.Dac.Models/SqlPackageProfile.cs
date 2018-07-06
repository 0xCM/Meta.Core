//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;
    using static SqlT.Syntax.SqlSyntax;

    using static metacore;

    /// <summary>
    /// Models a DAC profile
    /// </summary>
    public class SqlPackageProfile
    {
        public static readonly FileExtension DefaultFileExtension = SqlArtifactExtensions.SqlDacProfileExtension;

        public static IEnumerable<ClrProperty> FlagProperties
            => from p in ClrClass.Get<SqlPackageProfile>().DeclaredPublicInstanceProperties
               where p.PropertyType.UnderlyingSystemType == typeof(bool)
               select ClrProperty.Get(p);

        public SqlPackageProfile(bool setDefaults = true)
        {
            SqlCmdVariables = MutableSet.Empty<sql_cmd_variable>();
            DropExclusions = MutableSet.Empty<SqlPackageObjectType>();
            IgnoredObjects = MutableSet.Empty<SqlPackageObjectType>();
            TargetDatabaseName = SqlDatabaseName.Empty;
            SourceXml = string.Empty;
            if (setDefaults)
            {
                
                IncludeCompositeObjects = true;
                DropObjectsNotInSource = true;
                BlockOnPossibleDataLoss = true;
                DropConstraintsNotInSource = false;
                DropDmlTriggersNotInSource = false;
                DropExtendedPropertiesNotInSource = false;
                DropIndexesNotInSource = false;
                ScriptDatabaseOptions = true;

            }
        }

        public IReadOnlySet<sql_cmd_variable> SqlCmdVariables { get; set; }

        public  IReadOnlySet<SqlPackageObjectType> DropExclusions { get; set; }

        public IReadOnlySet<SqlPackageObjectType> IgnoredObjects { get; set; }

        /// <summary>
        /// Specifies the name of the destination database
        /// </summary>
        public SqlDatabaseName TargetDatabaseName { get; set; }

        /// <summary>
        /// Specifies the name of the deployment script to be generated
        /// </summary>
        public FileName DeployScriptFileName { get; set; }

        /// <summary>
        /// Specifies the target database connector
        /// </summary>
        public SqlConnectionString TargetConnectionString { get; set; }

        /// <summary>
        /// If specified, the original XML from which the profile was derived
        /// </summary>
        public string SourceXml { get; set; }

        /// <summary>
        /// If specified, the path to the profile XML file from which the profile was derived
        /// </summary>
        public Option<NodeFilePath> SourcePath { get; set; }

        public string AdditionalDeploymentContributorArguments { get; set; }

        public bool? IncludeCompositeObjects { get; set; }

        public bool? BlockOnPossibleDataLoss { get; set; }
        
        public bool? GenerateSmartDefaults { get; set; }

        public bool? DropObjectsNotInSource { get; set; }

        public bool? CreateNewDatabase { get; set; }

        public bool? DropConstraintsNotInSource { get; set; }

        public bool? DropDmlTriggersNotInSource { get; set; }

        public bool? DropExtendedPropertiesNotInSource { get; set; }

        public bool? DropIndexesNotInSource { get; set; }

        public bool? ScriptDatabaseOptions { get; set; }

        public bool? DropPermissionsNotInSource { get; set; }

        public bool? DropRoleMembersNotInSource { get; set; }

        public bool? DropStatisticsNotInSource { get; set; }

        public bool? IgnoreAnsiNulls { get; set; }

        public bool? IgnoreSemicolonBetweenStatements { get; set; }

        public bool? IgnoreRouteLifetime { get; set; }

        public bool? IgnoreRoleMembership { get; set; }

        public bool? IgnoreQuotedIdentifiers { get; set; }

        public bool? IgnorePermissions { get; set; }

        public bool? IgnorePartitionSchemes { get; set; }

        public bool? IgnoreObjectPlacementOnPartitionScheme { get; set; }

        public bool? IgnoreTableOptions { get; set; }

        public bool? IgnoreNotForReplication { get; set; }

        public bool? IgnoreLoginSids { get; set; }

        public bool? IgnoreLockHintsOnIndexes { get; set; }

        public bool? IgnoreKeywordCasing { get; set; }

        public bool? IgnoreIndexPadding { get; set; }

        public bool? IgnoreIndexOptions { get; set; }

        public bool? IgnoreIncrement { get; set; }

        public bool? IgnoreIdentitySeed { get; set; }

        public bool? IgnoreUserSettingsObjects { get; set; }

        public bool? IgnoreWhitespace { get; set; }

        public bool? IgnoreWithNocheckOnCheckConstraints { get; set; }

        public bool? VerifyCollationCompatibility { get; set; }

        public bool? UnmodifiableObjectWarnings { get; set; }

        public bool? TreatVerificationErrorsAsWarnings { get; set; }

        public bool? ScriptRefreshModule { get; set; }

        public bool? ScriptNewConstraintValidation { get; set; }

        public bool? ScriptFileSize { get; set; }

        public bool? ScriptDeployStateChecks { get; set; }

        public bool? ScriptDatabaseCompatibility { get; set; }

        public bool? ScriptDatabaseCollation { get; set; }

        public bool? RunDeploymentPlanExecutors { get; set; }

        public bool? RegisterDataTierApplication { get; set; }

        public bool? PopulateFilesOnFileGroups { get; set; }

        public bool? NoAlterStatementsToChangeClrTypes { get; set; }

        public bool? IncludeTransactionalScripts { get; set; }

        public bool? IgnoreWithNocheckOnForeignKeys { get; set; }

        public bool? IgnoreFullTextCatalogFilePath { get; set; }

        public bool? IgnoreFillFactor { get; set; }

        public bool? IgnoreFileSize { get; set; }

        public bool? IgnoreFilegroupPlacement { get; set; }

        public bool? DoNotAlterReplicatedObjects { get; set; }

        public bool? DoNotAlterChangeDataCaptureObjects { get; set; }

        public bool? DisableAndReenableDdlTriggers { get; set; }

        public bool? DeployDatabaseInSingleUserMode { get; set; }

        public bool? CompareUsingTargetCollation { get; set; }

        public bool? CommentOutSetVarDeclarations { get; set; }

        public int? CommandTimeout { get; set; }

        public bool? BlockWhenDriftDetected { get; set; }

        public bool? BackupDatabaseBeforeChanges { get; set; }

        public bool? AllowIncompatiblePlatform { get; set; }

        public bool? AllowDropBlockingAssemblies { get; set; }

        public string AdditionalDeploymentContributors { get; set; }

        public bool? VerifyDeployment { get; set; }

        public bool? IgnoreFileAndLogFilePath { get; set; }

        public bool? IgnoreExtendedProperties { get; set; }

        public bool? IgnoreDmlTriggerState { get; set; }

        public bool? IgnoreDmlTriggerOrder { get; set; }

        public bool? IgnoreDefaultSchema { get; set; }

        public bool? IgnoreDdlTriggerState { get; set; }

        public bool? IgnoreDdlTriggerOrder { get; set; }

        public bool? IgnoreCryptographicProviderFilePath { get; set; }

        public bool? IgnoreComments { get; set; }

        public bool? IgnoreColumnCollation { get; set; }

        public bool? IgnoreAuthorizer { get; set; }

        public override string ToString()
            => this.ToProfileXml();

        public void SetFlag(string Name, bool Value)
            => FlagProperties.TryGetFirst(p => p.Name == Name)
                             .OnSome(p => p.SetValue(this, Value));                    
           
        public bool? GetFlag(string Name)        
            => FlagProperties.TryGetFirst(p => p.Name == Name)
                             .Map(p => (bool?)p.GetValue(this)).ValueOrDefault();       
    }

}
