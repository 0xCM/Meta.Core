//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    using static metacore;

    class LocalCommandStore : ApplicationComponent, ILocalCommandStore
    {

        public LocalCommandStore(IApplicationContext C, FolderPath StorageRoot, 
                Action<FilePath, ICommandSpec> Process = null,
                Action<IAppMessage> Observe = null
                )
            : base(C)
        {

            this.FileMonitor = C.FileMonitorAgent().StartIfNotRunning().Require();
            this.StorageRoot = StorageRoot;
            this.Serializer = Service<ICommandSpecSerializer>();
            this.MonitorToken = FileMonitor.Watch(StorageRoot, OnFileChange).Require();

            if (Process != null)
                this.Process = Process;

            if (Observe != null)
                this.Observe = Observe;
        }

        Action<FilePath, ICommandSpec> Process { get; }
            = (path, spec) => {};

        Action<IAppMessage> Observe { get; }
            = msg => { };


        ConcurrentDictionary<FilePath, ICommandSpec> Commands { get; }
            = new ConcurrentDictionary<FilePath, ICommandSpec>();

        bool IsIndexed(ICommandSpec spec)
            => Commands.Values.Contains(spec);

        Option<ICommandSpec> FindIndexedCommand(string SpecName)
            => Commands.Values.TryGetFirst(c => c.SpecName == SpecName);

        ICommandSpecSerializer Serializer { get; }

        IFileMonitor FileMonitor { get; }

        CorrelationToken MonitorToken { get; }

        Option<ICommandSpec> LoadCommand(FilePath SrcPath)
            => Serializer.Decode(SrcPath.ReadAllText());

        bool Cancelling { get; set; }


        FolderPath CmdSubmissionFolder { get; set; }

        FolderPath CmdDispatchedFolder { get; set; }

        FolderPath CmdCompletedFolder { get; set; }

        Task SubmissionMonitor { get; set; }

        public bool Babble { get; set; }

        void ConfigureStore()
        {
            
            CmdSubmissionFolder = (StorageRoot + FolderName.Parse("submission")).CreateIfMissing().OnNone(Notify).Require();
            CmdDispatchedFolder = (StorageRoot + FolderName.Parse("dispatched")).CreateIfMissing().OnNone(Notify).Require();
            CmdCompletedFolder = (StorageRoot + FolderName.Parse("completed")).CreateIfMissing().OnNone(Notify).Require();

            SubmissionMonitor = Task.Factory.StartNew(() =>
            {
                while (not(Cancelling))
                {

                    var commands = list(CmdSubmissionFolder.Files("*.json"));
                    iter(commands, command =>
                    {
                        Notify(inform($"Received {command}"));
                        command.MoveTo(CmdDispatchedFolder + command.FileName,FilePath.Parse).OnNone(Notify);
                    });

                    Task.Delay(1000).ContinueWith(
                        _ =>
                        {
                            if (Babble)
                                Notify(babble("Checking for submissions"));
                        }).Wait();
                }

            });

        }

        void OnFileChange(FileChangeDescription Change)
        {
            Observe(babble($"Command store changed: {Change}"));

            if(Change.Added)
            {

                LoadCommand(Change.File)
                    .OnSome(command => 
                    {
                        Commands.TryAdd(Change.File, command);
                        Observe(babble($"Invoking processor for new command {command.SpecName}"));
                        Process(Change.File, command);
                    })
                    .OnNone(Notify);
            }
            else if(Change.Modified)
            {
                Commands.TryRemove(Change.File, out ICommandSpec value);

                LoadCommand(Change.File)
                    .OnSome(command =>
                    {
                        Commands.TryAdd(Change.File, command);
                        Observe(babble($"Invoking processor for updated command {command.SpecName}"));
                        Process(Change.File, command);
                    })                    
                    .OnNone(Notify);
            }
            else if(Change.Removed)
            {
                Commands.TryRemove(Change.File, out ICommandSpec value);
            }

        }

        
        public Option<ICommandSpec> FindCommand(string SpecName)
            => FindIndexedCommand(SpecName);

        public FolderPath StorageRoot { get; }

        public Option<FilePath> DeleteCommand(string SpecName)
        {
            return (from c in Commands
                       where c.Value.SpecName == SpecName
                       select c.Key).TryGetFirst().OnSome(path => path.DeleteIfExists());                       
        }
                
        
        public IEnumerable<ICommandSpec> StoredCommands
            => Commands.Values;

        public Option<T> FindCommand<T>(string SpecName)
            where T : CommandSpec<T>, new()
            => FindCommand(SpecName).Map(csr => csr as T);
         

        public Option<FolderPath> PurgeStore()
            => StorageRoot.DeleteIfExists();


        static FileName DefineCommandFileName(ICommandSpec Command, FileExtension FileExt)
        {
            var ext = FileExt ?? new FileExtension("cps.json");
            var unsafeName = ifBlank(Command.SpecName, concat(Command.CommandName, now().Ticks.ToString()));
            var saferName = unsafeName.Replace('/', '~');
            return FileName.Parse(saferName).AddExtension(ext);

        }
        public Option<FilePath> SaveCommand(ICommandSpec Command, FileExtension Extension = null, bool FlattenHierarchy = true)
        {
            var filename = DefineCommandFileName(Command, Extension);
            var outdir = FlattenHierarchy
                       ? new FolderPath(StorageRoot)
                       : new FolderPath(Path.Combine(StorageRoot, Command.CommandName));

            var outpath = outdir + filename;
            return outpath.Write(Serializer.Encode(Command)).ToFileOption();
        }

        void IDisposable.Dispose()
            => FileMonitor.EndWatch(MonitorToken);
    }
}
