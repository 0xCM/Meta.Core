//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Reflection;
    using System.Text;

    using SqlT.Core;

    using SqlT.Models;
    using SqlT.SqlSystem;

    

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Formatting;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    using Meta.Core;

    using Templates;
    using static metacore;
    using static ClrStructureSpec;
    using ClrModel;
    using static ClrBehaviorSpec;

    using static GenerationMessages;
   
    static class EmissionExtensions
    {
        static FolderPath GetSourceOutputFolder(this CodeGenerationProfile gp)
        {
            var outdir = FolderPath.Parse(ifBlank(gp.OutputDirectory, Environment.CurrentDirectory));
            if (gp.EmitProject)
            {
                var srcOutDir = outdir + RelativePath.Parse(gp.ProjectName);
                return srcOutDir.CreateIfMissing().Require();
            }
            else
                return outdir.CreateIfMissing().Require();
        }

        public static CodeFileSpec SpecifyCodeFile(this CodeGenerationProfile gp, 
            string baseFileName, NamespaceSpec ns, bool includePreamble)
                => includePreamble
                ? new CodeFileSpec($"{baseFileName}.cs", array<UsingSpec>(), array(ns), gp.SpecifyFilePreamble())
                : new CodeFileSpec($"{baseFileName}.cs", array<UsingSpec>(), ns);


        static IReadOnlyList<FilePath> EmitDependencies(this CodeGenerationProfile gp, 
            IReadOnlyDictionary<string, string> dependencies, StreamWriter writer = null)
        {
            var outpaths = MutableList.Create<FilePath>();
            var srcOutDir = gp.GetSourceOutputFolder();
            if (gp.EmitSingleFile)
            {
                foreach (var dependency in dependencies)
                {
                    writer.WriteLine();
                    writer.Write(dependency.Value);
                    writer.WriteLine();
                }
            }
            else
            {
                foreach (var d in dependencies)
                {
                    var outpath = Path.Combine(srcOutDir, d.Key);
                    File.WriteAllText(outpath, d.Value);
                    outpaths.Add(outpath);
                }
            }

            return outpaths;
        }

        public static FilePath GetProfileOutPath(this CodeGenerationProfile gp)
            => GetSourceOutputFolder(gp) +  FileName.Parse(gp.Name + ".sqlt");


        static void EmitProject(this CodeGenerationProfile gp, 
            IReadOnlyList<FilePath> files, Action<IAppMessage> observer)
        {
            observer?.Invoke(gp.GeneratingProject());

            var projfiles = MutableList.FromItems(files);            
            var projOutDir = gp.GetSourceOutputFolder();
            var profileOutPath = gp.GetProfileOutPath();
            projfiles.Add(Path.Combine(projOutDir, profileOutPath));

            var tProj = ProjectTemplate.Expand
            (
                ProjectName: gp.ProjectName,
                RootNamespace: gp.RootNamespace,
                DistributionLabel: gp.DistributionLabel
            );


            var configFolderName = FolderName.Parse("Configuration");
            var projectConfigDir = (projOutDir + configFolderName).CreateIfMissing().Require();
            var projPath = projOutDir + (FileName.Parse(tProj.ProjectName) + new FileExtension("csproj"));


            var designatorTemplate = new AssemblyDesignation
            {
                Designator = gp.AssemblyDesignatorName,
                AssemblyVersion = gp.AssemblyVersion,
                AssemblyTitle = gp.ProjectName,
                RootNamespace = gp.RootNamespace
            };
            var designatorFileName = FileName.Parse("Designator.cs");
            var designatorOutPath = projectConfigDir + designatorFileName;
            projfiles.Add($"{configFolderName}\\{designatorFileName}");

            designatorOutPath.Write(designatorTemplate.Expand()).Require();

            var sln = tProj.CompanionSolution();
            projPath.Write(tProj.Expand()).Require();

            var slnPath = projOutDir + (FileName.Parse(sln.ProjectName) + new FileExtension("sln"));
            slnPath.Write(sln.Expand()).Require();

            if(gp.BuildProject)
                observer?.Invoke(gp.BuildingProject());

            MsBuild.AddProjectFiles(projPath, projfiles, gp.BuildProject);
        }
                
        public static Option<int> Emit(IEnumerable<CodeFileSpec> files)
        {
            int count = 0;
            foreach (var codeFile in files)
            {

                var result = codeFile.Emit();
                if (result.IsNone())
                    return result;

                count++;
            }
            return count;
        }

        public static Option<int> Emit(this CodeFileSpec fs)
        {
            try
            {
                using (var ws = new AdhocWorkspace())
                {
                    FilePath.Parse(fs.FileName).Folder.CreateIfMissing();

                    using (var writer = new StreamWriter(fs.FileName))
                    {
                        var syntax = fs.BuildSyntax().NormalizeWhitespace();
                        var format = Formatter.Format(syntax, ws);
                        format.WriteTo(writer);
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                return none<int>(e);
            }
        }

        public static string Emit(this ClassSpec spec)
        {
            var syntax = CompilationUnit().WithMembers(spec.BuildSyntax().ToSingletonList());
            var sb = new StringBuilder();

            using (var ws = new AdhocWorkspace())
            {
                using (var writer = new StringWriter(sb))
                {
                    var format = Formatter.Format(syntax.NormalizeWhitespace(), ws);
                    format.WriteTo(writer);

                }
            }

            return sb.ToString();

        }
        public static IReadOnlyList<FilePath> Emit(this CodeGenerationProfile gp, IReadOnlyList<CodeFileSpec> files,
            Action<IAppMessage> observer = null, IReadOnlyDictionary<string, string> dependencies = null)
        {

            var outpaths = MutableList.Create<FilePath>();

            if (files.Count == 0)
                return outpaths;

            var srcOutFolder = GetSourceOutputFolder(gp).CreateIfMissing().Require();
            using (var ws = new AdhocWorkspace())
            {
                if (gp.EmitSingleFile)
                {
                    var outpath = srcOutFolder + FileName.Parse(gp.Name + ".cs");

                    observer?.Invoke(SavingFile(outpath));
                    using (var writer = new StreamWriter(outpath))
                    {

                        foreach (var file in files)
                        {
                            var syntax = file.BuildSyntax().NormalizeWhitespace();
                            var format = Formatter.Format(syntax, ws);
                            format.WriteTo(writer);
                            writer.WriteLine();
                        }

                        if (gp.EmitDependencies && dependencies != null)
                            gp.EmitDependencies(dependencies, writer);


                        writer.WriteLine($"// Emission concluded at {now()}");
                    }
                    outpaths.Add(outpath);

                }
                else
                {
                    foreach (var file in files)
                    {
                        var outpath = srcOutFolder.GetCombinedFilePath(file.FileName.FileName);
                        var format = Formatter.Format(file.BuildSyntax().NormalizeWhitespace(), ws);
                        observer?.Invoke(SavingFile(outpath));
                        using (var writer = new StreamWriter(outpath))
                        {
                            format.WriteTo(writer);
                        }
                        outpaths.Add(outpath);
                    }

                    if (gp.EmitDependencies && dependencies != null)
                    {
                        observer?.Invoke(EmittingDependencyFiles(gp.OutputDirectory));
                        outpaths.AddRange(gp.EmitDependencies(dependencies));
                    }
                }

            }

            if (gp.EmitProject)
                gp.EmitProject(outpaths, observer);

            return outpaths;
        }
    }

}