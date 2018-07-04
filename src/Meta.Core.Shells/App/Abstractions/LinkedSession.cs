//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using static metacore;
    using static ShellMessages;

    using N = SystemNode;
       
    public abstract class LinkedSession : LinkedComponent, ILinkedShellSession
    {
        public static IApplicationMessage ListedItem(string ItemName)
            => ApplicationMessage.Inform(ItemName);

        static bool IsFileSystemResource(SystemUri uri)
            => roset("lib", "unc").Intersect(uri.Scheme.Components).Any();

        protected LinkedSession(ILinkedContext C)
            : base(C)
        {
            this.CommandBasePath = SystemUri.PathSegment.Parse("commands");
            this.TargetNodeConnected += OnTargetNodeConnected;
            this.SourceNodeConnected += OnSourceNodeConnected;
            this.CommandController = new ShellCommandController(Context, () => AvailableNodes);
        }

        protected FolderPath CurrentDir { get; set; }

        SystemUri.PathSegment CommandBasePath { get; set; }

        public IShellCommandController CommandController { get; }

        public ICommandOrchestrationController Orchestrator { get; set; }

        protected event Action<N> SourceNodeConnected;
        protected event Action<N> TargetNodeConnected;

        ConcurrentSet<CorrelationToken> _Correlations { get; }
            = new ConcurrentSet<CorrelationToken>();

        bool AddCorrelation(CorrelationToken ct)
            => _Correlations.Add(ct);

        CorrelationToken CorrelateIfMissing(CorrelationToken? ct)
        {
            ct = ct ?? CorrelationToken.Create();
            AddCorrelation(ct.Value);
            return ct.Value;
        }

        bool RemoveCorrelation(CorrelationToken ct)
            => _Correlations.Remove(ct).IsSome();

        protected IReadOnlySet<CorrelationToken> Correlations
            => _Correlations.ToReadOnlySet();

        SystemNodeIdentifier NodeId { get; }
            = EnvironmentVariables.SystemNode.ResolveValue()
                    .Map(x => SystemNodeIdentifier.Parse(x), 
                            () => SystemNodeIdentifier.Empty);

        Option<N> TryFindNode(string designator)
            => SystemNodeIdentifier.IsLocal(designator) ? N.Local :  
                AvailableNodes.FirstOrDefault(n =>
                    string.Compare(n.NodeName, designator, true) == 0
                 || string.Compare(n.NodeIdentifier, designator, true) == 0);

        protected N node(string designator)
            => TryFindNode(designator).OnNone(_ => Notify(error($"Node {designator} not found"))).ValueOrDefault(SourceNode);

        protected N node(N Host)
            => Host;

        protected virtual IReadOnlyList<N> AvailableNodes
            => metacore.roitems(N.Local);

        protected N ExecutingNode 
            => node(NodeId);

        protected IEnumerable<ShellCommandDescriptor> AvailableCommands
            => ShellCommand.DiscoverCommands(GetType());

        protected void Connect(NodeLink NewLink)
        {
            var currentSource = Context.SourceNode;
            var currentTarget = Context.TargetNode;

            bool changeSource = true;
            if (not(NewLink.Source.NodeIdentifier.Equals(currentSource.NodeIdentifier)))
                Notify(inform($"Changing source node from {currentSource} to {NewLink.Source}"));
            else
            {
                Notify(inform($"Already connected to {currentSource}"));
                changeSource = false;
            }

            bool changeTarget = true;
            if (not(NewLink.Target.NodeIdentifier.Equals(currentTarget.NodeIdentifier)))
                Notify(inform($"Changing source node from {currentTarget} to {NewLink.Target}"));
            else
            {
                Notify(inform($"Already connected to {currentTarget}"));
                changeTarget = false;

            }

            if (!changeTarget && !changeSource)
                return;

            Relink(NewLink);

            if (changeSource)
                SourceNodeConnected(Context.SourceNode);
            if(changeTarget)
                TargetNodeConnected(Context.TargetNode);                        
        }
             
        void OnSourceNodeConnected(N ConnectedSource)
        {
            Context.ReplaceSource(ConnectedSource);
            Notify(inform($"Connected to node {ConnectedSource.NodeIdentifier}"));
        }

        void OnTargetNodeConnected(N ConnectedTarget)
        {
            Context.ReplaceTarget(ConnectedTarget);
            Notify(inform($"Connected to node {ConnectedTarget.NodeIdentifier}"));
        }

        public void SetCommandSubject(string subject)
            => CommandBasePath = SystemUri.PathSegment.Parse(subject);

        protected FolderPath DistributionFolder(DistributionIdentifier distId)
            => CommonFolders.DistRootDir + distId;

        public void SubmitCommand(Type CommandType, SystemUri uri, CorrelationToken? ct)
        {
                        

            var dstNode = TryFindNode(uri.Host)
                            .OnNone(_ => Notify(error($"Node {uri.Host} not found")))
                            .Require();

            var args = map(uri.Query.Criteria,
                criterion => new CommandArgument(criterion.Key, criterion.Value));

            var command = args.CreateCommand(CommandType);

            var result = CommandController.SubmitCommand(command, dstNode, CorrelateIfMissing(ct));
            if (result.IsNone)
            {
                if (result.Message.IsEmpty)
                    Notify(error($"Submission of command {command.CommandName} failed for reasons unknown"));
                else
                    Notify(result.Message);
            }
            else
                Notify(inform($"Submitted {command.CommandName} to {dstNode}"));
            
        }

        protected void NotifySubmissionStatus(N DstNode, ICommandSubmission submission)
            => NotifyStatus($"The {submission.CommandName} command was submitted to {DstNode}; submission id: {submission.SubmissionId}");


        protected ICommandPatternSystem CPS
            => C.CPS();

        public Option<CommandSubmission<TSpec>> SubmitCommand<TSpec>(TSpec Command, N DstNode, CorrelationToken? ct)
            where TSpec : CommandSpec<TSpec>, new()
            => CPS.Submit(Command, node(DstNode), CorrelateIfMissing(ct))
                            .OnNone(Notify)
                            .OnSome(submission => NotifySubmissionStatus(DstNode, submission));


        public Option<CommandSubmission> SubmitCommand(N CommandNode, ICommandSpec spec, CorrelationToken? ct)
            => CPS.Submit(spec, CommandNode, CorrelateIfMissing(ct))
                  .OnNone(Notify)
                  .OnSome(s => NotifySubmissionStatus(CommandNode, s));

        public Option<ReadOnlyList<CommandSubmission<TSpec>>> SubmitCommands<TSpec>(N DstNode, IEnumerable<TSpec> Commands, CorrelationToken? ct)
            where TSpec : CommandSpec<TSpec>, new()
            => CPS.Submit(Commands, DstNode, CorrelateIfMissing(ct))
                    .OnNone(Notify)
                    .OnSome(submissions
                        => NotifyStatus($"Submitted {submissions.Count} {submissions.First().CommandName} commands"));


        public Option<int> SaveCommand(ICommandSpec command)
            => CPS.SaveSpecs(command);


        public Option<TResult> ExecuteCommand<TSpec, TResult>(TSpec command, CorrelationToken? ct)
            where TSpec : CommandSpec<TSpec, TResult>, new()
            => CPS.Execute(command);


        public IOption ExecuteCommand(ICommandSpec command, CorrelationToken? ct)
            => CommandController.ExecuteCommand(command, ct);

        public IApplicationMessage ListItem(object item)
            => ListedItem(toString(item));


        public IReadOnlyList<IApplicationMessage> ListItems(IEnumerable<object> items)
            => map(items, item => ListedItem(toString(item)));


        public IReadOnlyList<IApplicationMessage> ListItems<T>(IEnumerable<T> items, Func<T, string> formatter)
            => map(items, item => ListedItem(formatter(item)));


        protected IEnumerable<ClrAssembly> RegisteredAssemblies
            => C.AssemblyRegistrar().GetRegisteredAssemblies().Select(ClrAssembly.Get);

        //[ScriptCommandMethod(Description: "Submits a command")]
        //public void SubmitCommandUri(string uriText, CorrelationToken? ct)
        //{
        //    var uri = SystemUri.Parse(uriText);
        //    var commandPath = CommandBasePath + uri.Path;
        //    var commandName = CommandName.Parse(commandPath.Text.Trim('/'));
        //    var commandType = CommandLibrary.SpecDescriptor(commandName);
        //    commandType.OnNone(()
        //        => Notify(ApplicationMessage.Error($"The {commandName} command type could not be found")))
        //               .OnSome(t => SubmitCommand(t.SpecType, uri, ct));
        //}

        [ScriptCommandMethod(Description: "Submits an identified command from the libray to a specified node")]
        public void SubmitLibraryCommand(string SpecName, string DstNode, CorrelationToken? ct)
            => CPS.StoredSpec(SpecName)
                   .OnNone(() => Notify(CommandSpecNotFound(SpecName)))
                   .OnSome(spec => CPS.Submit(spec, TryFindNode(DstNode).Require(),ct))
                   .OnNone(message => Notify(message))
                   .OnSome(spec => Notify(SubmittedSpec(spec.SpecName)));


        [ScriptCommandMethod(Description: "Updated command definitions based on the current context")]
        public void UpdateCommandDescriptors()
            => CPS.UpdateCommandDescriptors();

        protected void StartOrchestrationController()
        {
            if (Orchestrator != null && Orchestrator.IsRunning())
            {
                C.Notify(ControllerAlreadyRunning());
                return;
            }

            if (Orchestrator != null)
            {

                Orchestrator.Start();
                return;
            }

            Orchestrator = C.Service<ICommandOrchestrationController>();
            Orchestrator.Start();

            CPS.Patterns().Iterate(pattern
                => Orchestrator.Start(pattern.SpecType));
        }

        [ShellCommand, Description("Lists the controlling and the linked connection")]
        public virtual void who()
            => Print(inform($"{ExecutingNode}:{Link}"));


        [ShellCommand, Description("Lists the available nodes")]
        public void nodes()
            => iter(AvailableNodes, Print);



        [ShellCommand, Description("Connects to source/target")]
        public void connect(string Source, string Target)
            => Connect(node(Source).LinkTo(node(Target)));


        [ShellCommand, Description("Lists the commands known to the shell")]
        public void commands()
            => iter(AvailableCommands.OrderBy(x => x.LocalName.IdentifierText), Print);

        [ShellCommand, Description("Lists the assemblies known to the registrar")]
        public void assemblies()
            => iter(RegisteredAssemblies,
                a => Notify(ListedItem(a.ReflectedElement.Designator()?.ModuleName ?? a.ReflectedElement.GetSimpleName())));

        [ShellCommand, Description("Lists the current configuration settings")]
        public void settings()
        {
            var settings = C.ConfigurationProvider.GetSettings();
            if (settings.Count != 0)
            {
                var maxlen = settings.Select(x => x.Key).Max(x => x.Length);
                var fmt = "{0," + maxlen + "}: {1}";
                iter(settings,
                    x => C.Notify(ListedItem(String.Format(fmt, x.Key, x.Value))));
            }
        }

        [ShellCommand, Description("Assigns a setting value via the configuration provider")]
        public void setValue(string SettingName, string SettingValue)
        {
            C.ConfigurationProvider.PutSetting(SettingName, SettingValue);
            var setValue = C.ConfigurationProvider.GetSetting<string>(SettingName);
            Notify(ListedItem($"{SettingName} : = {setValue}"));
        }


        [ShellCommand, Description("Begins orchestration for a specified command")]
        public void orchestrate(string CommandName)
        {
            if (Orchestrator == null)
                StartOrchestrationController();

            CPS.DescribeCommand(CommandName)
               .OnNone(message => C.Notify(CommandNotFound(CommandName)))
               .OnSome(descriptor => Orchestrator.Start(descriptor.SpecType));

        }


        [ShellCommand, Description("Displays the location of a specified distribution segment")]
        public FolderPath distSeg(string distId, string segment)
            => Inspect(DistributionFolder(distId) + FolderName.Parse(segment));

        [ShellCommand, Description("Lists known CPS commands")]
        public void cpsCommands()
            => iter(ListItems(CPS.DescribeCommands()), Notify);

        [ShellCommand, Description("Lists the parameters for a uri-identified command")]
        public void cmdparms(string name)
            => CPS.AvailableCommands()
                  .TryGetFirst(spec => spec.CommandName == name)
                  .OnSome(c => iter(ListItems(c.Arguments), Notify));



        [ShellCommand, Description("Lists the contents of the current directory")]
        public void dir(string path)
        {
            var d = isBlank(path) ? CurrentDir : FolderPath.Parse(path);
            PrintSequence(d.GetFolders());
            PrintSequence(d.Files());
        }

        
        [ShellCommand, Description("Gets/Sets the current directory")]
        public void cd(string path)
        {
            if (isBlank(path))
                Print(Environment.CurrentDirectory);
            else
            {
                Environment.CurrentDirectory = path;
                Print(Environment.CurrentDirectory);
            }

        }

        public virtual void RunShellSession()
        {

        }

        void ILinkedShellSession.Notify(IApplicationMessage m)
            => Notify(m);

    }


    public abstract class LinkedSession<T> : LinkedSession
        where T : LinkedSession<T>

    {
        protected LinkedSession(ILinkedContext C)
            : base(C)
        { }

        protected LinkedSession(IApplicationContext C, N ActiveNode)
            : this(new LinkedContext(C, ActiveNode.LinkToSelf()))
        {
        }

    }


}