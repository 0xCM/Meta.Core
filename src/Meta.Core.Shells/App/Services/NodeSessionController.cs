//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static metacore;

    using N = SystemNode;
    using static ShellMessages;

    class NodeSessionController : NodeComponent, IShellCommandController
    {
        ConcurrentSet<CorrelationToken> _Correlations { get; }
            = new ConcurrentSet<CorrelationToken>();

        CorrelationToken CorrelateIfMissing(CorrelationToken? ct)
        {
            ct = ct ?? CorrelationToken.Create();
            AddCorrelation(ct.Value);
            return ct.Value;
        }


        bool RemoveCorrelation(CorrelationToken ct)
            => _Correlations.Remove(ct).IsSome();

        static bool IsFileSystemResource(SystemUri uri)
            => roset("lib", "unc").Intersect(uri.Scheme.Components).Any();

        bool AddCorrelation(CorrelationToken ct)
            => _Correlations.Add(ct);



        public NodeSessionController(INodeContext C, Func<IEnumerable<N>> NodeProvider)
            : base(C)
        {
            this.CommandBasePath = SystemUri.PathSegment.Parse("commands");
            this.Serializer = C.CommandSerializer();
            this.AvailableNodes = NodeProvider;
        }

        SystemUri.PathSegment CommandBasePath { get; set; }

        ICommandOrchestrationController Orchestrator { get; set; }

        ICommandSpecSerializer Serializer { get; }

        Func<IEnumerable<N>> AvailableNodes { get; }

        IReadOnlySet<CorrelationToken> Correlations
            => _Correlations.ToReadOnlySet();

        void NotifySubmissionStatus(N cmdNode, ICommandSubmission submission)
            => NotifyStatus($"The {submission.CommandName} command was submitted to {cmdNode}; submission id: {submission.SubmissionId}");

        ICommandPatternSystem CPS
            => C.CPS();

        public IOption SubmitCommand(FilePath SpecFile, N DstNode, CorrelationToken? ct)
            => from cmd in Serializer.Decode(SpecFile.ReadAllText())
               select CPS.Submit(cmd, SystemNode.Local, CorrelateIfMissing(ct));

        public IOption SubmitCommand(ICommandSpec command, N DstNode, CorrelationToken? ct)
            => CPS.Submit(command, DstNode, CorrelateIfMissing(ct));

        public IOption ExecuteCommand(FilePath SpecFile, CorrelationToken? ct)
            => from cmd in Serializer.Decode(SpecFile.ReadAllText())
               select CPS.ExecuteCommands(cmd);

        public IOption ExecuteCommand(ICommandSpec command, CorrelationToken? ct)
            => CPS.ExecuteCommand(command);

        public Task<IOption> ExecuteCommandAsync(ICommandSpec Command, CorrelationToken? ct)
            => Task.Factory.StartNew(() => CPS.ExecuteCommand(Command));

        public Task<IOption> ExecuteCommandAsync(FilePath SpecFile, CorrelationToken? ct)
            => ExecuteCommandAsync(Serializer.Decode(SpecFile.ReadAllText())
                    .ValueOrDefault(new TextCommand($"Could not decode the spec file {SpecFile}")), CorrelateIfMissing(ct));

        Option<N> TryFindNode(string identifier)
            => AvailableNodes().TryGetFirst(
                x => x.NodeIdentifier.IdentifierText == identifier
                    || x.NodeName == identifier);

        public void SubmitCommand(Type CommandType, SystemUri uri, CorrelationToken? ct)
        {
            var dstNode = TryFindNode(uri.Host)
                            .OnNone(_ => Notify(error($"Node {uri.Host} not found")))
                            .Require();

            var args = map(uri.Query.Criteria,
                criterion => new CommandArgument(criterion.Key, criterion.Value));

            var command = args.CreateCommand(CommandType);

            var result = SubmitCommand(command, dstNode, CorrelateIfMissing(ct));
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

        public Option<CommandSubmission<TSpec>> SubmitCommand<TSpec>(TSpec Command, N DstNode, CorrelationToken? ct)
            where TSpec : CommandSpec<TSpec>, new()
            => CPS.Submit(Command, SystemNode.Local, CorrelateIfMissing(ct))
                            .OnNone(Notify)
                            .OnSome(submission => NotifySubmissionStatus(DstNode, submission));


        public Option<CommandSubmission> SubmitCommand(N CommandNode, ICommandSpec Command, CorrelationToken? ct)
            => CPS.Submit(Command, CommandNode, CorrelateIfMissing(ct))
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

        public Option<TResult> ExecuteCommand<TSpec, TResult>(TSpec command)
            where TSpec : CommandSpec<TSpec, TResult>, new()
            => CPS.Execute(command);

        public ICommandOrchestrationController StartOrchestrationController()
        {
            if (Orchestrator != null && Orchestrator.IsRunning())
            {
                C.Notify(ControllerAlreadyRunning());
                return Orchestrator;
            }

            if (Orchestrator != null)
            {

                Orchestrator.Start();
                return Orchestrator;
            }

            Orchestrator = C.Service<ICommandOrchestrationController>();
            Orchestrator.Start();

            CPS.Patterns().Iterate(pattern
                => Orchestrator.Start(pattern.SpecType));
            return Orchestrator;
        }



        public void StartOrchestration(CommandName CommandName)
        {
            if (Orchestrator == null)
            {
                Orchestrator = C.Service<ICommandOrchestrationController>();
                Orchestrator.Start();
            }

            CPS.DescribeCommand(CommandName)
               .OnNone(message => C.Notify(CommandNotFound(CommandName)))
               .OnSome(descriptor => Orchestrator.Start(descriptor.SpecType));

        }

        public IEnumerable<CommandSpecDescriptor> CommandDescriptions()
            => CPS.DescribeCommands();

        public void UpdateCommandDescriptors()
            => CPS.UpdateCommandDescriptors();

        public NamedValue PutSetting(string SettingName, string SettingValue)
        {
            C.ConfigurationProvider.PutSetting(SettingName, SettingValue);
            var setValue = C.ConfigurationProvider.GetSetting<string>(SettingName);
            return new NamedValue(SettingName, SettingValue);
        }

        public void SubmitLibraryCommand(string SpecName, N DstNode, CorrelationToken? ct)
            => CPS.StoredSpec(SpecName)
           .OnNone(() => Notify(CommandSpecNotFound(SpecName)))
           .OnSome(spec => CPS.Submit(spec, DstNode, ct))
           .OnNone(message => Notify(message))
           .OnSome(spec => Notify(SubmittedSpec(spec.SpecName)));

        public void ListRegisteredComponents()
            => iter(C.AssemblyRegistrar().GetRegisteredAssemblies(),
                a => Notify(LinkedSession.ListedItem(a.Designator()?.ModuleName ?? a.GetSimpleName())));

        public IEnumerable<CommandSpecDescriptor> KnownCommands()
            => CPS.DescribeCommands();


        public IEnumerable<CommandArgument> CommandUriParameters(CommandName CommandName)

            => from c in CPS.AvailableCommands()
               where c.CommandName == CommandName
               from arg in c.Arguments
               select arg;


        public void WorkingDir(string path = null)
        {
            if (isBlank(path))
                Print(Environment.CurrentDirectory);
            else
            {
                Environment.CurrentDirectory = path;
                Print(Environment.CurrentDirectory);
            }
        }
    }

}