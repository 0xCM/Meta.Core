//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.IO;

using static metacore;
using Meta.Core;
using Meta.Core.Project;


public static class ProjectX
{

    static Option<int> Render(FolderPath path, TextWriter writer, int level = 0)
    {
        var indentation = new string(' ', 4 + 4 * level);
        var typeName = $"{path.FolderName}".Replace('-', '_').Replace('.', '_').Replace(' ', '_').ToLower();
        if (Char.IsDigit(typeName[0]))
            typeName = $"_{typeName}";

        writer.WriteLine(indentation + $"///<summary>");
        writer.WriteLine(indentation + $"///{path}");
        writer.WriteLine(indentation + $"///<summary>");
        writer.WriteLine(indentation + $"public class {typeName} : {nameof(FileSystemResource)}");
        writer.WriteLine(indentation + "{");


        if (not((path + FileName.Parse(".stop")).Exists()))
            foreach (var subfolder in path.Subfolders())
                Render(subfolder, writer, level + 1);
        writer.WriteLine(indentation + "}");

        return level;

    }


    public static Option<int> RepresentStructure(this FolderPath SrcDir, ClrNamespaceName DstNs, FilePath DstFile)
    {
        using (var writer = new StreamWriter(DstFile))
        {
            writer.WriteLine($"namespace {DstNs}");
            writer.WriteLine("{");
            var result = Render(SrcDir, writer);
            writer.WriteLine("}");
            return result;

        }

    }
    public static IReadOnlyList<FilePath> Emit(this DevProject project, ProjectEmissionOptions options)
    {

        var outpaths = MutableList.Create<FilePath>();
        if (project.CodeFiles.Count == 0)
            return outpaths;

        var projectLocation = ~options.ProjectRootLocation.CreateIfMissing();
        foreach (var codeFile in project.CodeFiles)
        {
            var outpath = projectLocation + codeFile.FileName;
            outpath.Write(codeFile.Content);
            outpaths.Add(outpath);
        }

        return outpaths;        
    }

    public static AssetNavigator Assets(this INodeFileSystem NFS, SystemNode Host = null)
        => NFS.Nav<AssetNavigator>(Host ?? SystemNode.Local);

}

