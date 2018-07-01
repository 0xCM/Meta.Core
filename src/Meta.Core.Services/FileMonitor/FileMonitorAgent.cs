//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Monitors changes in the file system
    /// </summary>
    [ServiceAgent(AgentId), ApplicationService(AgentId)]
    class FileMonitorAgent : ServiceAgent<FileMonitorAgent, FileMonitorSettings>, IFileMonitor
    {
        public const string AgentId = nameof(FileMonitorAgent);

        public FileMonitorAgent(IApplicationContext C)
            : base(C)
        {
            var ts = now();
            AgentCreateTS = ts;
            AgentRuntimeId = string.Join("/", AgentId, ts.ToString("yyyyMMddhhmmssmmm"));
            C.Notify(inform($"{AgentRuntimeId} agent created"));
        }

        public DateTime AgentCreateTS { get; }

        public string AgentRuntimeId { get; }

        protected override string AgentName
            => AgentRuntimeId;

        ConcurrentDictionary<CorrelationToken, FolderTree> FolderIndex { get; }
            = new ConcurrentDictionary<CorrelationToken, FolderTree>();

        ConcurrentDictionary<CorrelationToken, Dictionary<FilePath, FileDescription>> FileIndex { get; }
            = new ConcurrentDictionary<CorrelationToken, Dictionary<FilePath, FileDescription>>();

        ConcurrentDictionary<CorrelationToken, Action<FileChangeDescription>> Listeners { get; }
            = new ConcurrentDictionary<CorrelationToken, Action<FileChangeDescription>>();
        
        IEnumerable<FileChangeDescription> MergeChanges(CorrelationToken token)
        {
            var indexedFiles = FileIndex[token];
            var currentFiles = FolderIndex[token].ListFiles(null, true);

            foreach(var file in currentFiles)
            {
                if (!indexedFiles.ContainsKey(file))
                {
                    indexedFiles.Add(file, new FileDescription(file));                    
                    yield return new FileChangeDescription(file, token, FileChangeKind.Added);
                }
                else
                {
                    if (indexedFiles[file].HasChanged() == true)
                        yield return new FileChangeDescription(file, token, FileChangeKind.Modifed);
                }
            }

            foreach (var file in rolist(indexedFiles.Keys.Except(currentFiles)))
            {
                indexedFiles.Remove(file);
                yield return new FileChangeDescription(file, token, FileChangeKind.Removed);

            }
        }

        void WalkTree(CorrelationToken token)
        {
            var listener = Listeners.TryFind(token);
            iter(MergeChanges(token), change => listener.OnSome(l => l(change)));            
        }

        public Option<FolderPath> EndPathMonitor(CorrelationToken MonitorToken)
        {
            if (FolderIndex.TryRemove(MonitorToken, out FolderTree tree))
            {
                FileIndex.TryRemove(MonitorToken, out Dictionary<FilePath, FileDescription> content);
                Listeners.TryRemove(MonitorToken, out Action<FileChangeDescription> listener);                                      
                return tree.Root;
            }
               
           return none<FolderPath>();

        }
        public Option<CorrelationToken> Listen(CorrelationToken MonitorToken, Action<FileChangeDescription> Listener)
        {
            if (Listeners.TryAdd(MonitorToken, Listener))
                C.Notify(inform($"{AgentRuntimeId} registered correlated listener {MonitorToken}"));
            return MonitorToken;
        }

        public Option<CorrelationToken> Watch(FolderPath Path, Action<FileChangeDescription> Listener)
            => MonitorPath(Path).OnSome(ct => Listen(ct, Listener));

        public Option<FolderPath> EndWatch(CorrelationToken MonitorToken)
            => EndPathMonitor(MonitorToken);

        internal static Dictionary<FilePath, FileDescription> ToMutableIndex(FolderTree tree, string match = null, bool recursive = false)
            => tree.ListFiles(match,recursive).ToDictionary(f => f, f => new FileDescription(f));

        public Option<CorrelationToken> MonitorPath(FolderPath Path)
        {
            var token = CorrelationToken.Create(Path);
            if (FolderIndex.TryAdd(token, new FolderTree(Path)))
            {
                FolderIndex.TryFind(token)
                            .OnNone(Notify)
                            .OnSome(tree =>
                            {
                                var index = ToMutableIndex(tree);
                                FileIndex.TryAdd(token, index);
                                iter(index.Keys, file => Notify(inform($"Indexed {file}")));

                            });
            }

            C.Notify(inform($"{AgentRuntimeId} completed indexing {token}"));
            return token;
        }


        void ExamineFiles()
        {            
            iter(FolderIndex.Keys, WalkTree, true);
        }

        protected override Option<int> DoWork()
        {
            try
            {
                ExamineFiles();
                return 0;
            }
            catch (Exception e)
            {
                return none<int>(e);
            }
        }

        public override string ToString()
             => AgentName;

    }
}
