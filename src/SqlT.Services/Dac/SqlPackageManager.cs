//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using SqlT.Models;
    using SqlT.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.IO.Packaging;
    using System.Xml;

    using Meta.Core;

    using static metacore;
    using static SqlT.Syntax.SqlSyntax;
    using SqlT.Services;

    using O = SqlT.Services.DacMessageReceiver;
    using CS = SqlT.Core.SqlConnectionString;
    using PR = SqlT.Models.SqlPackageProfile;

    using Dac = Microsoft.SqlServer.Dac;
    using DacM = Microsoft.SqlServer.Dac.Model;
    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;

    using CDATA = SqlT.Models.SqlPackageCustomData;

    class SqlPackageManagerService : ApplicationService<SqlPackageManagerService, ISqlPackageManager>, ISqlPackageManager
    {       
        public SqlPackageManagerService(IApplicationContext C)
            : base(C)
        {
        
        }

        Dac.DacPackage LoadPackage(NodeFilePath path)
            => Dac.DacPackage.Load(path.AbsolutePath, Dac.DacSchemaModelStorageType.Memory);

        static void SendTo(Dac.DacServicesException e, O Observer)
            => iter(e.Messages, m => Observer(m.ToAppMessage()));

        Option<NodeFilePath> EmitDeployScript(NodeFilePath DacPath, PR Profile, CS DstConnector, NodeFilePath DstPath, O Observer)
        {
            var DstDb = SqlDatabaseHandle.Create(DstConnector.GetClientBroker(), DstConnector.DatabaseName);
            var ProfilePath = NodeFilePath.Empty();
            try
            {
                ProfilePath = NodeFilePath.CreateTempFile(DacPath.Node, Profile.ToProfileXml());
                using (var package = LoadPackage(DacPath))
                {
                    var services = new Dac.DacServices(DstDb.Broker.ConnectionString.TrimCatalog());
                    services.Message += (o, x) => Observer(x.Message.ToAppMessage());
                    var profile = Dac.DacProfile.Load(ProfilePath.AbsolutePath);
                    var script = services.GenerateDeployScript(package, DstDb.DatabaseName.UnquotedLocalName, profile.DeployOptions);
                    return DstPath.Write(script);
                }
            }
            catch (Dac.DacServicesException e)
            {
                SendTo(e,Observer);
                return none<NodeFilePath>(e);
            }
            catch (Exception e)
            {
                return none<NodeFilePath>(e);
            }
            finally
            {
                ProfilePath.DeleteIfExists();
            }
        }

        void CopyOptions(Dac.DacDeployOptions SrcOptions, PR DstProfile)
        {
            var srcFlags = dict(typeof(Dac.DacDeployOptions).GetProperties()
                                .Where(p => p.PropertyType == typeof(bool))
                                .Select(p => (p.Name, (bool)p.GetValue(SrcOptions))));
            iter(srcFlags, srcFlag => DstProfile.SetFlag(srcFlag.Key, srcFlag.Value));                           
        }

        public Option<PR> LoadProfile(NodeFilePath SrcPath)
        {
            try
            {
                var dstModel = new PR(false)
                {
                    SourceXml = SrcPath.AbsolutePath.ReadAllText(),
                    SourcePath = SrcPath
                };

                var srcModel = Dac.DacProfile.Load(SrcPath.AbsolutePath);
                CopyOptions(srcModel.DeployOptions, dstModel);
                dstModel.SqlCmdVariables = srcModel.DeployOptions.SqlCommandVariableValues.Select(kvp => new sql_cmd_variable(kvp.Key, kvp.Value)).ToReadOnlySet();
                dstModel.TargetConnectionString = srcModel.TargetConnectionString;
                dstModel.TargetDatabaseName = srcModel.TargetDatabaseName;

                return dstModel;
            }
            catch (Exception e)
            {
                return none<PR>(e);
            }           
        }

        public Option<SqlScriptIndex> GetScriptIndex(NodeFilePath DacPath)
        {
            try
            {
                DacM.TSqlModel ReadUntypedModel(FilePath dacpath)
                    => new DacM.TSqlModel(dacpath);

                using (var model = ReadUntypedModel(DacPath))
                    return model.SpecifyScriptIndex();
            }
            catch (Exception e)
            {
                return none<SqlScriptIndex>(e);
            }
        }

        static Option<NodeFilePath> Deploy(SqlPackageDesignator h, CS TargetServer, SqlDatabaseName TargetDatabase, bool ApplyDbOptions, O Observer)
        {
            try
            {
                if (Observer == null)
                    return none<NodeFilePath>(error($"No observer was specified"));

                using (var package = Dac.DacPackage.Load(h.PackagePath.AbsolutePath, Dac.DacSchemaModelStorageType.Memory))
                {
                    var services = new Dac.DacServices(TargetServer);
                    services.Message += (o, x) => Observer(x.Message.ToAppMessage());

                    services.Deploy
                        (
                            package: package,
                            targetDatabaseName: TargetDatabase.UnqualifiedName,
                            upgradeExisting: true,
                            options: new Dac.DacDeployOptions
                            {
                                IncludeCompositeObjects = true,
                                GenerateSmartDefaults = true,
                                ScriptDatabaseOptions = ApplyDbOptions
                            }
                         );
                    return some(h.PackagePath);
                }
            }
            catch (Dac.DacServicesException e)
            {
                SendTo(e, Observer);
                return none<NodeFilePath>(new PackageDeploymentFailed(h.PackagePath, TargetDatabase, TargetServer, e.ToString()).ToAppMessage());
            }
            catch (Exception e)
            {
                return none<NodeFilePath>(new PackageDeploymentFailed(h.PackagePath, TargetDatabase, TargetServer, e.ToString()).ToAppMessage());
            }
        }

        Option<SqlPackageDescription> ISqlPackageManager.DescribePackage(NodeFilePath SrcPath)
            => DescribePackage(SqlPackageDesignator.Create(SrcPath));

        SqlScriptCollection ISqlPackageManager.LoadScripts(NodeFilePath DacPath)
        {
            var split = rolist(ReadTypedModel(DacPath).SpecifyScripts()).Split();
            if (split.Left.Any())
                throw new Exception();
            return new SqlScriptCollection(split.Right);
        }

        DacX.TSqlTypedModel ReadTypedModel(FilePath dacpath)
        {
            if (!dacpath.Exists())
                throw new FileNotFoundException($"The file {dacpath} could not be found", dacpath);
            return new DacX.TSqlTypedModel(dacpath);
        }

        SqlModelSet ISqlPackageManager.LoadModel(NodeFilePath DacPath)
        {
            using (var model = ReadTypedModel(DacPath.AbsolutePath))
            {
                var xpidx = model.SpecifyExtendedPropertyIndex();
                return new SqlModelSet
                (
                    ModelDescriptor: ModelSetDescriptor(),
                    ExtendedProperties: xpidx,
                    Projectors: model.ModelProjectors(xpidx),
                    Tables: model.SpecifyTable(xpidx),
                    TableTypes: model.SpecifyTableTypes(xpidx),
                    Procedures: model.SpecifyProcedures(xpidx),
                    TableFunctions: model.ModelTableFunctions(xpidx)
                );
            }

            SqlModelSetDescriptor ModelSetDescriptor()
            {
                using (var package = Dac.DacPackage.Load(DacPath.AbsolutePath))
                {
                    return new SqlModelSetDescriptor
                    (
                        ModelIdentifier: package.Name,
                        ModelVersion: package.Version,
                        Description: package.Description
                    );
                }
            }
        }

        Option<NodeFilePath> Publish(NodeFilePath SrcPath, PR Profile, O Observer)
        {
            var ProfilePath = NodeFilePath.CreateTempFile(SrcPath.Node, Profile.ToProfileXml());
            var result = (this as ISqlPackageManager).Publish(SrcPath, ProfilePath, Observer);
            ProfilePath.DeleteIfExists();
            return result;
        }

        Option<NodeFilePath> ISqlPackageManager.Publish(NodeFilePath SrcPath, PR Profile, O Observer)
            => Publish(SrcPath, Profile, Observer);

        Option<NodeFilePath> ISqlPackageManager.Publish(NodeFilePath DacPath, NodeFilePath ProfilePath, O Observer)
        {
            try
            {
                if (Observer == null)
                    throw new ArgumentException($"No observer was specified for the deployment operation");

                using (var package = Dac.DacPackage.Load(DacPath.AbsolutePath, Dac.DacSchemaModelStorageType.Memory))
                {
                    var profile = Dac.DacProfile.Load(ProfilePath.AbsolutePath);
                    var services = new Dac.DacServices(profile.TargetConnectionString);
                    services.Message += (o, x) => Observer(x.Message.ToAppMessage());
                    services.Deploy(package, profile.TargetDatabaseName, true, profile.DeployOptions);
                    return some(DacPath);
                }
            }
            catch (Dac.DacServicesException e)
            {
                SendTo(e, Observer);
                return none<NodeFilePath>(new PackageDeploymentFailed(DacPath, ProfilePath, e.ToString()).ToAppMessage());
            }
            catch (Exception e)
            {
                return none<NodeFilePath>(new PackageDeploymentFailed(DacPath, ProfilePath, e.ToString()).ToAppMessage());
            }
        }

        Option<NodeFilePath> ISqlPackageManager.Publish(NodeFilePath SrcPath, CS DstServer,
                SqlDatabaseName TargetDatabase, bool ApplyDbOptions, O Observer)
                    => Deploy(SqlPackageDesignator.Create(SrcPath), DstServer, TargetDatabase,
                        ApplyDbOptions, Observer);

        Option<NodeFilePath> ISqlPackageManager.Publish(SqlPackagePublication Spec, O Observer)
            => Spec.SqlProfilePath.IsSome()
            ? Spec.SqlProfilePath.MapValue(profilepath => (this as ISqlPackageManager).Publish(Spec.PackagePath, profilepath, Observer))
            : Spec.Profile.MapValueOrDefault(profile => Publish(Spec.PackagePath, profile, Observer));

        Option<NodeFilePath> ISqlPackageManager.EmitDeployScript(NodeFilePath SrcDacPath, PR Profile, 
                CS DstConnector, NodeFilePath DstScriptPath, O Observer)
                    => EmitDeployScript(SrcDacPath, Profile, DstConnector, DstScriptPath, Observer);

        Option<NodeFilePath> ISqlPackageManager.ExportData(CS SrcServer, NodeFilePath DstPath, O Observer)
        {
            try
            {
                if (Observer == null)
                    return none<NodeFilePath>(error($"No observer was specified"));

                var services = new Dac.DacServices(SrcServer);
                services.Message += (o, x) => Observer(x.Message.ToAppMessage());
                services.ExportBacpac(DstPath.AbsolutePath, SrcServer.DatabaseName);
                return DstPath;
            }
            catch (Dac.DacServicesException e)
            {
                SendTo(e, Observer);
                return none<NodeFilePath>();
            }
            catch (Exception e)
            {
                return none<NodeFilePath>(e);
            }
        }

        Option<NodeFilePath> ISqlPackageManager.ImportData(NodeFilePath SrcPath, CS DstServer, SqlDatabaseName DstDatabase, O Observer)
        {
            try
            {
                if (Observer == null)
                    return none<NodeFilePath>(error($"No observer was specified"));

                var services = new Dac.DacServices(DstServer);
                services.Message += (o, x) => Observer(x.Message.ToAppMessage());

                using (var package = Dac.BacPackage.Load(SrcPath.AbsolutePath, Dac.DacSchemaModelStorageType.File))
                {
                    services.ImportBacpac(package, DstDatabase.UnqualifiedName);
                }
                return SrcPath;
            }
            catch (Dac.DacServicesException e)
            {
                SendTo(e, Observer);
                return none<NodeFilePath>(e);
            }
            catch (Exception e)
            {
                return none<NodeFilePath>(e);
            }
        }

        static SqlPackageDescription DescribePackage(SqlPackageDesignator h)
        {
            var assemblyPath = h.PackagePath.ChangeExtension(SqlArtifactExtensions.SqlDacAssemblyExtension);
            var customData = ReadCustomDataSet(h);
            return new SqlPackageDescription(
                h.PackageName,
                customData.GetReferences(),
                customData.GetSqlCmdVariables(),
                PackageLocation: h.PackagePath,
                AssemblyLocation: assemblyPath.Exists() ? assemblyPath : null,
                ProfileLocations: stream<NodeFilePath>()
                );
        }

        static SqlPackageCustomDataSet ReadCustomDataSet(SqlPackageDesignator h)
            => new SqlPackageCustomDataSet(h.PackagePath.FileName.RemoveExtension().ToString(), GetCustomData(h));


        static string GetXmlFile(Package package, string fileName)
        {
            var part = package.GetPart(new Uri(string.Format("/{0}", fileName), UriKind.Relative));
            var stream = part.GetStream();
            return new StreamReader(stream).ReadToEnd();
        }

        /// <summary>
        /// Algorith taken from: https://github.com/GoEddie/Dacpac-References/blob/master/src/GOEddie.Dacpac.References/HeaderParser.cs
        /// </summary>
        static IReadOnlyList<CDATA> GetCustomData(SqlPackageDesignator h)
        {
            using (var package = Package.Open(h.PackagePath.AbsolutePath, FileMode.Open, FileAccess.Read))
            {
                var xml = GetXmlFile(package, "Model.xml");
                var reader = XmlReader.Create(new StringReader(xml));
                reader.MoveToContent();

                var data = MutableList.Create<CDATA>();
                CDATA currentCustomData = null;
                while (reader.Read())
                {
                    if (reader.Name == "CustomData" && reader.NodeType == XmlNodeType.Element)
                    {
                        var cat = reader.GetAttribute("Category");
                        var type = reader.GetAttribute("Type");
                        currentCustomData = new CDATA(cat, type);
                        data.Add(currentCustomData);
                    }
                    if (reader.Name == "Metadata" && reader.NodeType == XmlNodeType.Element)
                    {
                        var name = reader.GetAttribute("Name");
                        var value = reader.GetAttribute("Value");
                        currentCustomData.AddProperty(name, value);
                    }
                    if (reader.Name == "Header" && reader.NodeType == XmlNodeType.EndElement)
                    {
                        break; //gone too far
                    }
                }
                return data;
            }
        }

        static Option<string> TryAddObjects(DacM.TSqlModel model, string script)
        {
            try
            {
                model.AddObjects(script);
            }
            catch (Exception e)
            {
                return none<string>(ApplicationMessage.Error($"{e.Message}. Script: {script}"));
            }
            return script;
        }

        public Option<NodeFilePath> Save(SqlPackage package, NodeFilePath path, O Observer)
        {
            var sqlVersion = package.SqlVersion.ToDac();
            var recoveryModel = package.DatabaseOptions.recovery_model.map(x => x, () => recovery_models.SIMPLE);
            var containment = package.DatabaseOptions.containment_type.map(x => x, () => containment_types.NONE);
            var broker = package.DatabaseOptions.service_broker_option.map(x => x, () => service_broker_options.DISABLE_BROKER);
            var sniffing = package.DatabaseOptions.parameter_sniffing.map(x => x.IsOn, () => (bool?)null);

            var modelOptions = new DacM.TSqlModelOptions
            {
                Containment = containment.ToDac(),
                RecoveryMode = recoveryModel.ToDac(),
                ServiceBrokerOption = broker.ToDac(),
                DbScopedConfigParameterSniffing = sniffing
            };

            try
            {
                using (var model = new DacM.TSqlModel(sqlVersion, modelOptions))
                {
                    foreach (var script in package.Scripts)
                    {
                        var add = TryAddObjects(model,script.ScriptText);
                        if (!add)
                            return add.ToNone<NodeFilePath>();
                    }

                    var packageMetadata = new Dac.PackageMetadata
                    {
                        Name = package.PackageName,
                        Description = package.PackageDescription,
                        Version = package.PackageVersion
                    };

                    Dac.DacPackageExtensions.BuildPackage(path.AbsolutePath, model, packageMetadata, new Dac.PackageOptions());
                    return path;
                }
            }
            catch (Dac.DacServicesException e)
            {
                SendTo(e, Observer);
                return none<NodeFilePath>(e);
            }
            catch (Exception e)
            {
                return none<NodeFilePath>(e);
            }
        }

        public Option<NodeFilePath> SaveToPackage(IEnumerable<ISqlScript> scripts, NodeFilePath DacPath)
        {
            var package = new SqlPackage
                (
                    PackageName: new SqlPackageName(DacPath.FileName.RemoveExtension()),
                    PackageVersion: SemanticVersion.Default,
                    Scripts: scripts,
                    SqlVersion: SqlVersionNames.Sql2016
                );


            return Save(package, DacPath, message => Notify(message));
        }

        IEnumerable<SqlPackageDescription> DescribePackages(NodeFolderPath SrcFolder)
            => from dacpath in SrcFolder.Files("*.dacpac").AsParallel()
               select DescribePackage(SqlPackageDesignator.Create(dacpath));


        ISqlDacRepository ISqlPackageManager.PackageRepository(NodeFolderPath SrcFolder)
            => new SqlDacRepository(C, SrcFolder,DescribePackages(SrcFolder));

        Option<NodeFilePath> ISqlPackageManager.ExtractSchema(CS SourceConnector, NodeFilePath DacPath, O Observer)
        {
            try
            {
                var services = new Dac.DacServices(SourceConnector);
                services.Message += (o, x) => Observer(x.Message.ToAppMessage());
                services.Extract(DacPath.AbsolutePath, SourceConnector.DatabaseName, SourceConnector.DatabaseName, new Version(1, 0));
            }
            catch (Dac.DacServicesException e)
            {
                SendTo(e, Observer);
                return none<NodeFilePath>(e);
            }
            catch (Exception e)
            {
                return none<NodeFilePath>(e);
            }
            return DacPath;
        }
    }
}