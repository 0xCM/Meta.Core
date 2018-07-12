//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;
    
    public delegate void DacMessageReceiver(IAppMessage message);

    /// <summary>
    /// Defines collection of operations that facilitate DACPAC manipulation
    /// </summary>
    public interface ISqlPackageManager
    {
        /// <summary>
        /// Loads packaged procs and functions as an indexed collection of <see cref="SqlParameterizedScript"/>
        /// </summary>
        /// <param name="SrcDacPath">The path to the DACPAC</param>
        /// <remarks>
        /// Returns all procs and functions defined in the identified DACPAC as they were literally encoded,
        /// with all SqlCmd and other parameters in-place.
        /// </remarks>
        SqlScriptCollection LoadScripts(NodeFilePath SrcDacPath);

        /// <summary>
        /// Loads and projects package content onto the SqlT model vocabulary where possible
        /// </summary>
        /// <param name="SrcDacPath">The path to the DACPAC</param>
        /// <remarks>
        /// The supported model types are determined by <see cref="SqlModelSet"/> such as
        /// <see cref"SqlTableFunction"/>, <see cref"SqlTable"/> and <see cref"SqlProcedure"/> 
        /// </remarks>
        SqlModelSet LoadModel(NodeFilePath SrcDacPath);

        /// <summary>
        /// Deploys a dacpac as directed by the publication spec
        /// </summary>
        /// <param name="Publication">The publication spec</param>
        /// <param name="Observer">Recieves messages emitted during publication</param>
        /// <returns></returns>
        Option<NodeFilePath> Publish(SqlPackagePublication Publication, DacMessageReceiver Observer);

        /// <summary>
        /// Deploys a dacpac using default configuration parameters
        /// </summary>
        /// <param name="SrcDacPath">The path to the DACPAC</param>
        /// <param name="DstServer">The target server</param>
        /// <param name="DstDb">The target database</param>
        /// <param name="Observer">Recieves messages emitted during publication</param>
        /// <param name="ApplyDbOptions">Whether database options specifications defined in the package are applied to the target</param>
        /// <returns></returns>
        Option<NodeFilePath> Publish(NodeFilePath SrcDacPath, SqlConnectionString DstServer, SqlDatabaseName DstDb, bool ApplyDbOptions, DacMessageReceiver Observer);

        /// <summary>
        /// Deploys a DACPAC using configuration parameters determined by a publish.xml profile
        /// </summary>
        /// <param name="SrcDacPath">The path to the DACPAC</param>
        /// <param name="ProfilePath">The path to the profile</param>
        /// <param name="Observer">Recieves messages emitted during publication</param>
        /// <returns></returns>
        Option<NodeFilePath> Publish(NodeFilePath SrcDacPath, NodeFilePath ProfilePath, DacMessageReceiver Observer);

        /// <summary>
        /// Deploys a DACPAC using the configuration parameters determined by a <see cref="SqlPackageProfile"/> instance
        /// </summary>
        /// <param name="SrcDacPath">The path to the DACPAC</param>
        /// <param name="Profile">Semantic profile representation</param>
        /// <param name="Observer">Recieves messages emitted during publication</param>
        /// <returns></returns>
        Option<NodeFilePath> Publish(NodeFilePath SrcDacPath, SqlPackageProfile Profile, DacMessageReceiver Observer);

        /// <summary>
        /// Exports data from a source database to a target (D|B)ACPAK
        /// </summary>
        /// <param name="SrcConnector">Connection string to source database</param>
        /// <param name="DstDacPath">The path to the DACPAC</param>
        /// <returns></returns>
        Option<NodeFilePath> ExportData(SqlConnectionString SrcConnector, NodeFilePath DstDacPath, DacMessageReceiver Observer);

        /// <summary>
        /// Loads data from a (D|B)ACPAK into a target database
        /// </summary>
        /// <param name="SrcDacPath">The path to the DACPAC</param>
        /// <param name="DstConnector">Connection string to target server</param>
        /// <param name="DstDb"></param>
        /// <returns></returns>
        Option<NodeFilePath> ImportData(NodeFilePath SrcDacPath, SqlConnectionString DstConnector, SqlDatabaseName DstDb, DacMessageReceiver Observer);

        /// <summary>
        /// Saves a <see cref="SqlPackage"/> representation to a DACPAC
        /// </summary>
        /// <param name="SrcPackage">The DACPAC content</param>
        /// <param name="DstDacPath">The path to the DACPAC</param>
        /// <returns></returns>
        Option<NodeFilePath> Save(SqlPackage SrcPackage, NodeFilePath DstDacPath, DacMessageReceiver Observer);

        /// <summary>
        /// Saves a collection of scripts to a package
        /// </summary>
        /// <param name="scripts">The scripts to save</param>
        /// <param name="DacPath">The path to the destination package</param>
        /// <returns></returns>
        Option<NodeFilePath> SaveToPackage(IEnumerable<ISqlScript> scripts, NodeFilePath DacPath);

        /// <summary>
        ///  Loads a collection of <see cref="SqlPackageDescription"/> for all packages in a given folder
        ///  and returns this collection encapsulated by a <see cref="ISqlDacRepository"/> instance,
        ///  that indexes the DACPAC descriptions by name and pairs this collection with the <see cref="FolderPath"/>
        ///  that was searched.
        /// </summary>
        /// <param name="SrcFolder">The path to the folder containing DACPAC files</param>
        ISqlDacRepository PackageRepository(NodeFolderPath SrcFolder);

        /// <summary>
        /// Hydrates a package profile model from a publish XML file
        /// </summary>
        /// <param name="SrcPath"></param>
        /// <returns></returns>
        Option<SqlPackageProfile> LoadProfile(NodeFilePath SrcPath);
        
        /// <summary>
        /// Describes the content of the package including package dependencies and requred <see cref="sql_cmd_variable"/> specifications
        /// </summary>
        /// <param name="SrcDacPath"></param>
        Option<SqlPackageDescription> DescribePackage(NodeFilePath SrcDacPath);

        /// <summary>
        /// Extracts the schema determined by the connector to a DACPAC
        /// </summary>
        /// <param name="SrcConnector">Connection string ot the source database</param>
        /// <param name="DstDacPath">The target output path</param>
        /// <remarks>This produced package is equivalent to what would be produced when invoking
        /// the DACPAC extract wizard with the default parameters</remarks>
        Option<NodeFilePath>  ExtractSchema(SqlConnectionString SrcConnector, NodeFilePath DstDacPath, DacMessageReceiver Observer);

        /// <summary>
        /// Generates a targeted deployment script
        /// </summary>
        /// <param name="SrcDacPath">The path to the DACPAC</param>
        /// <param name="Profile">Semantic profile representation</param>
        /// <param name="DstConnector">The targeted server</param>
        /// <param name="DstScriptPath">The path to the generated script</param>
        /// <returns></returns>
        Option<NodeFilePath> EmitDeployScript(NodeFilePath SrcDacPath, SqlPackageProfile Profile, SqlConnectionString DstConnector, NodeFilePath DstScriptPath, DacMessageReceiver Observer);

        /// <summary>
        /// Extracts and indexes the scripts in a package
        /// </summary>
        /// <param name="DacPath">The path to a DACPAC</param>
        /// <returns></returns>
        Option<SqlScriptIndex> GetScriptIndex(NodeFilePath DacPath);
    }
}
