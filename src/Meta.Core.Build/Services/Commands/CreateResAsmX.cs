//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Reflection;
    using System.Globalization;
    using System.Reflection.Emit;
    using System.Resources;

#if FULL
    using MSE = Microsoft.Build.Execution;
    using static BuildSyntax;

    using static metacore;    

    [CommandPattern]
    class CreateResAsmX : CommandExecutionService<CreateResAsmX, CreateResAsm, FilePath>
    {
        static RelativeFileSet GetProjectFileSet(FilePath ProjectFile)
        {
            var isSqlProj = ProjectFile.Extension == "sqlproj";

            var project = new MSE.ProjectInstance(ProjectFile);
            var items = isSqlProj
                ? project.FindItems(StandardItemTypes.Build, StandardItemTypes.None)
                : project.FindItems(StandardItemTypes.Compile, StandardItemTypes.None);

            var files = items.Map(item => new RelativePath(item.EvaluatedInclude));
            return new RelativeFileSet(ProjectFile.Folder, files);
        }

        public static IReadOnlyDictionary<string, string> LoadResources(FilePath asmpath)
        {
            var assembly = Assembly.LoadFile(asmpath);
            var resmgr = new ResourceManager(assembly.GetName().Name, assembly);
            var resources = resmgr.GetResourceSet(CultureInfo.InvariantCulture, true, true);
            var residx = resources.IndexTextResources();
            return residx;
        }

        static bool IsSqlProject(FilePath ProjectFile)
            => ProjectFile.Extension == CommonFileExtensions.SqlProject;

        static IEnumerable<(string resname, string content)> DefineResources(FilePath projectFile, RelativeFileSet fileset)
            => from z in fileset.Files.Select( relpath => {
                    var resname = relpath.Value.Replace(Path.DirectorySeparatorChar, '.');
                    var file = fileset.RootFolder.GetCombinedFilePath(relpath);
                    var isSqlProj = projectFile.Extension == CommonFileExtensions.SqlProject;
                    if (IsSqlProject(projectFile))
                        resname = $"[SqlTest].[{file.FileName.RemoveExtension()}]";
                    if (!resname.Contains("AssemblyInfo.cs") && !resname.Contains("SqlT.Core.cs"))
                        return (resname, file.ReadAllText());
                    return (string.Empty, string.Empty);            
                }) where isNotBlank(z) select z;

        static Option<FilePath> SaveAssembly(CreateResAsm spec, IEnumerable<(string resname, string content)> resources)
            => Try(() =>
            {
                return 
                    from assemblyFileName in some(FileName.Define(spec.SimpleAssemblyName, CommonFileExtensions.Dll))
                    from OutputFolder in spec.OutputFolder.CreateIfMissing()
                    from assemblyPath in (OutputFolder + assemblyFileName).DeleteIfExists()
                    let assembly =  AssemblyBuilder.DefineDynamicAssembly
                        (
                            new AssemblyName
                            {
                                Name = spec.SimpleAssemblyName,
                                CodeBase = assemblyPath,
                                CultureInfo = CultureInfo.InvariantCulture,
                                Version = new Version(spec.AssemblyVersion)
                            },
                            AssemblyBuilderAccess.RunAndSave
                        )
                    let resourceDescription = $"Resources embedded from VS project file"
                    let resourceName = spec.SimpleAssemblyName + ".resources"
                    let module = assembly.DefineDynamicModule(assemblyFileName, assemblyFileName)
                    let writer = module.DefineResource(resourceName, resourceDescription, ResourceAttributes.Public)
                    from t in Try(() =>
                    {
                        iter(resources, f => writer.AddResource(f.Item1, f.Item2));
                        var e = module.DefineEnum("CodeResourceAssembly", TypeAttributes.Public, typeof(int));
                        e.DefineLiteral("ResourcePattern", 1);
                        e.CreateType();
                        assembly.Save(assemblyFileName);

                    })
                    select assemblyPath;
            });

        /// <summary>
        /// Executes the <see cref="CreateResAsm"/> command
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public static Option<FilePath> Execute(CreateResAsm spec)
            => from resources in some( DefineResources(spec.ProjectFile, GetProjectFileSet(spec.ProjectFile)))
               from saved in SaveAssembly(spec, resources)
               select saved;

        public CreateResAsmX(IApplicationContext context)
                : base(context)
        { }

        protected override Option<FilePath> TryExecute(CreateResAsm spec)
            => Execute(spec);
    }
#endif
}