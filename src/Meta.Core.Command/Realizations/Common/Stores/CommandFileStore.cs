//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Meta.Core;
using static metacore;
using static CommandStatusMessages;


/// <summary>
/// Manages file system command specification persistence
/// </summary>
[ApplicationService(CommandStoreType.FileStore)]
public class CommandFileStore : ApplicationService<CommandFileStore, ICommandStore>, ICommandStore
{

    static string BuildSearchPattern(params string[] ext)
        => string.Join(";*.", ext.Length == 0 ? array("*.spec") : ext);

    public CommandFileStore(IApplicationContext C)
        : base(C)
    {
        if (Settings.CommandFolder.Exists())
        {
            this.index = dict(
                    from path in Directory.EnumerateFiles(Settings.CommandFolder, BuildSearchPattern(), SearchOption.AllDirectories)
                    let specOption = serializer.Decode(File.ReadAllText(path))
                    where specOption.Exists
                    let spec = specOption.Require()
                    group
                        spec by spec.CommandName into groups
                    select
                        (groups.Key, groups.ToReadOnlyList())
                    );
            this.specs = index.Values.Reduce().ToReadOnlyList();
        }
        else
        {
            this.index = new Dictionary<CommandName, ReadOnlyList<ICommandSpec>>();
            this.specs = ReadOnlyList<ICommandSpec>.Empty;
        }
    }

    IReadOnlyDictionary<CommandName, ReadOnlyList<ICommandSpec>> index { get; }

    ReadOnlyList<ICommandSpec> specs { get; }

    CommandSystemSettings Settings
        => Settings<CommandSystemSettings>();

    ICommandSpecSerializer serializer 
        => Service<ICommandSpecSerializer>();

    Option<ICommandSpec> TryLoadSpec(FilePath path)
    {
        var text = path.TryReadAllText();
        if (text.IsNone())
            return text.ToNone<ICommandSpec>();

        return text.MapValueOrDefault(x => serializer.Decode(x));
    }

    Option<ICommandSpec> TryFindSpec(string specName)
    {
        //The spec may not actually be in the designated store folder but live somewhere else..
        if (File.Exists(specName))
        {
            var spec = TryLoadSpec(specName);
            return spec;
        }
        else
        {
            var path = Settings.CommandFolder.Files(specName, true).FirstOrDefault();
            return path != null ?
                serializer.Decode(path.ReadAllText())
                : none<ICommandSpec>(SpecNotFound(specName));            
        }
    }


    public ReadOnlyList<ICommandSpec> FindSpecs()
        => specs;

    public Option<T> FindSpec<T>(string specName)
        where T : CommandSpec<T>, new()
        => TryFindSpec(specName).Map(csr => csr as T);

    public Option<ICommandSpec> FindSpec(string specName)
        => TryFindSpec(specName);

    public Option<int> SaveSpec(ICommandSpec spec, FileExtension Extension, bool FlattenHierarchy)
    {

        var ext = Extension ?? ".spec";
        var filename = new FileName(spec.SpecName) + ext;
        var outdir =  FlattenHierarchy 
                   ? new FolderPath(Settings.CommandFolder) 
                   : new FolderPath(Path.Combine(Settings.CommandFolder, spec.CommandName));

        if (!Directory.Exists(outdir))
            Directory.CreateDirectory(outdir);

        var outpath = outdir + filename;
        var json = serializer.Encode(spec);
        File.WriteAllText(outpath, json);
        return 1;
    }

    public Option<int> SaveSpecs(IEnumerable<ICommandSpec> specs, FileExtension Extension, bool FlattenHierarchy)
    {
        int count = 0;
        foreach(var spec in specs)
        {
            SaveSpec(spec, Extension, FlattenHierarchy);
            count++;

        }
        return count;        
    }

    public Option<FilePath> ExportSpec(ICommandSpec spec, FolderPath root, FileExtension Extension, bool FlattenHierarchy)
    {

        var ext = Extension ?? ".spec";
        var dstFolder = FlattenHierarchy ? root : root.GetCombinedFolderPath(spec.CommandName.Identifier.Split('/').Last());
        dstFolder.CreateIfMissing().Require();
        var path = dstFolder + (new FileName(spec.SpecName) + ext);
        var json = serializer.Encode(spec);
        File.WriteAllText(path, json);
        return path;

    }

    public Option<int> SaveDefinitions(IEnumerable<ICommandSpec> specs)
        => throw new NotImplementedException();

    public Option<int> PurgeSpecs()
        => throw new NotImplementedException();

    public Option<int> PurgeDefinitions()
        => throw new NotImplementedException();

    public Option<int> Purge()
        => throw new NotImplementedException();
}
