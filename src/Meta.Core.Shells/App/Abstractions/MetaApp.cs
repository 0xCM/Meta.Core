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
    using System.Threading.Tasks;

    using static ApplicationMessage;

    using static metacore;

    public abstract class MetaApp<A> :  ICompositionRoot, IMetaApp
        where A : MetaApp<A>, new()
    {
        static Lazy<IAssemblyDesignator> _Designator = lazy(GetAssemblyDesignator);

        public static A Instance { get; private set; }

        static IAssemblyDesignator Designator
            => _Designator.Value;

        protected static int HandleMain(string[] args)
            => Run(args).OnMessage(m => Console.WriteLine(m)).Map(x => x.ResultCode ?? 0, () => -1);


        IApplicationContext CreateContext()
        {
            try
            {
                var context = AppDesignator.CreateContext();
                return OnContextComposing(context);
            }
            catch (ReflectionTypeLoadException e)
            {
                iter(e.LoaderExceptions, l => SystemConsole.Get().Write(error(l)));
                throw;
            }
            catch (Exception e)
            {
                Notify(e);
                throw;
            }
        }

        protected MetaApp(IMessageBroker NotificationBroker = null)
        {
            Instance = (A)this;
            Shell = ShellConsole.Create(this);
            this.NotificationBroker = NotificationBroker ?? TransientMessageBroker.Create(message => Shell.Write(message));
            var context = CreateContext();
            this.Root = new ShellRoot(Designator, Shell, context);

                                   
        }

        protected ICommandStore _CommandStore;
        protected ICommandExecStore _ExecStore;

        ShellRoot Root { get; }

        protected IShellConsole Shell { get; }

        protected void Status(string Message)
            => Notify(inform(Message));        

        protected void Notify(Exception e)
            => NotificationBroker.Route(e.DefineExceptionMessage());

        protected void Notify(IApplicationMessage Message)
            => NotificationBroker.Route(Message);

        Type IMetaApp.AppType
            => typeof(A);

        public IAssemblyDesignator AppDesignator
            => Designator;

        static IAssemblyDesignator GetAssemblyDesignator()
        {
            var dType = (from t in typeof(A).Assembly.GetTypes()
                         let i = t.GetInterfaces()
                         where i.Contains(typeof(IAssemblyDesignator))
                         select t).Single();

            return (IAssemblyDesignator)Activator.CreateInstance(dType);
        }


        protected static Option<AppExec> Run(params string[] args)
        {
            try
            {
                return new A().Execute(args);
            }
            catch (Exception e)
            {
                return none<AppExec>(e.DefineExceptionMessage());
            }
        }

        protected static Option<AppExec> Run(IMessageBroker NotificationBroker, params string[] args)
        {
            try
            {
                var app = new A();
                if(NotificationBroker != null)
                    app.NotificationBroker = NotificationBroker;

                return app.Execute(args);
            }
            catch (Exception e)
            {
                return none<AppExec>(e.DefineExceptionMessage());
            }
        }

        FolderPath CurrentDirectory
            =>  FolderPath.Parse(Environment.CurrentDirectory);

        RelativePath StorageLocation(string ContentType)
            => FolderName.Parse("storage")
            + FolderName.Parse(typeof(A).Assembly.GetSimpleName())
            + FolderName.Parse(ContentType)
            ;

        protected FolderPath ExecutionFolder
            => FilePath.Parse(Assembly.GetEntryAssembly().Location).Folder;

        protected FolderPath AppStorage(string ContentType)
            => ExecutionFolder
                         .GetCombinedFolderPath(StorageLocation(ContentType))
                         .CreateIfMissing().Require();
        
        IMessageBroker NotificationBroker { get; set; }

        protected virtual bool EnableRepresentationMetadataProvider
            => true;

        protected virtual bool EnableCommandProviders
            => true;

        protected Option<SystemNode> TryFindNode(string identifier)
        {
            var host = EnvironmentVariables.SystemNode.ResolveValue();
            if (host)
            {
                if (host == identifier || host == identifier)
                    return SystemNode.Local;
                else
                    throw new NotSupportedException();
            }
            return none<SystemNode>();
        }

        protected SystemNode FindNode(string identifier)
            => TryFindNode(identifier).Require();

        protected SystemNode ExecutingNode
            => FindNode(EnvironmentVariables.SystemNode.ResolveValue().ValueOrDefault());


        protected IApplicationContext C
            => Root.Context;

        protected ICommandPatternSystem CPS
            => C.CPS();

        IApplicationContext CreateAppContext()
        {
            try
            {
                var context = ApplicationContext.Create(AppDesignator?.ModuleDependencies);
                return OnContextComposing(context);
            }
            catch (ReflectionTypeLoadException e)
            {
                iter(e.LoaderExceptions, l => SystemConsole.Get().Write(error(l)));
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }


        public char? WaitForUser(string prompt = null, int? timeout = null)
        {
            if (isNotBlank(prompt))
                Shell.WriteLine(prompt);
            return Shell.ReadKey(timeout ?? 2500);
        }

        public void Initialized(IApplicationContext C)
        {           
            _CommandStore = C.Service<ICommandStore>();
            _ExecStore = C.Service<ICommandExecStore>();
        }

        public Task<IOption> ExecuteCommandAsync(ICommandSpec spec, CorrelationToken? ct)
            => Task.Factory.StartNew(() => ExecuteCommand(spec, ct));

        public Task<IOption> ExecuteCommandAsync(FilePath path, CorrelationToken? ct)
            => Task.Factory.StartNew(() => ExecuteCommand(path,ct));

        public IOption ExecuteCommand(ICommandSpec spec, CorrelationToken? ct)
        {

            var exec = CPS.ExecuteCommand(spec);
            if (exec.IsNone)
            {
                if (exec.Message.IsEmpty)
                    C.PostMessage(Error("Execution failed for unknown reason"));
                else
                    C.PostMessage(exec.Message);
            }
            else
            {
                if (not(exec.Message.IsEmpty))
                    C.PostMessage(exec.Message);
            }
            return exec;
        }        

        public IOption ExecuteCommand(FilePath path, CorrelationToken? ct)
        {
            
            C.NotifyStatus($"Executing command specified by {path}");
            try
            {
                var spec = _CommandStore.FindSpec(path);
                if (!spec)
                    return spec;

                return ExecuteCommand(~spec,ct);
            }
            catch (Exception e)
            {
                C.PostMessage(Error(e));
                return none<int>(e);
            }
        }

        public IOption SubmitCommand(ICommandSpec Command, SystemNode DstNode, CorrelationToken? ct)
        {
            C.NotifyStatus($"Submitting {Command.CommandName} command to {DstNode}");
            try
            {
                return _ExecStore.Submit(stream(Command), DstNode,ct);
            }
            catch (Exception e)
            {
                C.PostMessage(Error(e));
                return none<int>(e);
            }

        }

        public IOption SubmitCommand(FilePath CommandFile, SystemNode DstNode, CorrelationToken? ct)
        {            
            
            C.NotifyStatus($"Submitting command specified by {CommandFile}");
            try
            {
                return from spec in _CommandStore.FindSpec(CommandFile)
                       from exec in _ExecStore.Submit(stream(spec), null,ct)
                       select exec;

            }
            catch (Exception e)
            {
                C.PostMessage(Error(e));
                return none<int>(e);
            }
        }

        public string ComponentName
            => AppDesignator.ModuleName;

        protected AppMessageFormatter MessageFormatter
            => FormatMessage;

        protected virtual void OnNotificationReceived(IApplicationMessage message)
            => Display(message);

        protected virtual string GetPromptName(IApplicationMessage message)
            => ifBlank(message.SourceComponent, "status");

        string FormatMessage(IApplicationMessage message)                    
            => $"{GetPromptName(message)}> {message.Format(false)}";        

        protected virtual void Display(IApplicationMessage message)
            => SystemConsole.Get().Write(message);

        public virtual IConfigurationProvider ConfigurationProvider
            => new ProvidedConfigurationSet(stream<ConfigurationSetting>());
        
        protected virtual IEnumerable<IShellSession> SupportedSessions
            => stream<IShellSession>();

        public string EnvironmentName
            => RuntimeEnvironments.Local;

        public IReadOnlyList<ServiceDescriptor> ProvidedServices 
            => throw new NotImplementedException();

        public IReadOnlyDictionary<string, string> Arguments 
            => throw new NotImplementedException();

        protected virtual IEnumerable<IConsoleCommand> GetProvidedCommands()
            => from set in SupportedSessions
               from cmd in ScriptCommand.Discover(set)
               select cmd.Adapt();

        IEnumerable<IConsoleCommand> IShellCommandProvider.GetCommands()
            => GetProvidedCommands();

        protected virtual IMutableContext OnContextComposing(IMutableContext C)
        {
            C.ReplaceService<IShellCommandProvider>(this);
            C.WithConfigurationProvider(ConfigurationProvider);
            C.InjectService<IMessageBroker>(NotificationBroker);            
            return C;
        }

        protected Option<AppExec> Interactive(params string[] args)
        {
            Status($"Launching the interactive shell");
            try
            {
                return new AppExec(Shell, Task.Factory.StartNew(() => (Shell as ShellConsole).Run(this)));

            }
            catch (Exception e)
            {
                C.NotifyError(e);
                return none<AppExec>();
            }
        }

        protected void SubmitCsxScript(FilePath csx)
        {            
            Status($"Executing {csx}");
            foreach (var commandLine in csx.ReadAllLines().Stream())
                Shell.PostCommand(new TextCommand(commandLine));
        }

        protected virtual Option<int> HandleArgs(IReadOnlyList<string> args)
        {
            try
            {
                foreach (var arg in args)
                {
                    var commandFile = FilePath.Parse(arg);
                    if (not(commandFile.Exists()))
                        Notify(error($"The file {commandFile} does not exist"));

                    if (commandFile.Extension.Equals("csx"))
                        SubmitCsxScript(commandFile);
                    else
                    {
                        Status($"Submitting {arg}");
                        var result = SubmitCommand(arg, ExecutingNode, null);

                        if (!result.Message.IsEmpty)
                            Notify(result.Message);

                        if (result.IsNone)
                            Shell.ReadKey();

                    }
                }

                Status($"Completed execution of {args.Count} commands");
                return some(0);
            }
            catch(Exception e)
            {
                return none<int>(e);
            }

        }

        protected virtual bool RunTerminal
             => true;

        protected virtual Option<AppExec> Execute(IReadOnlyList<string> args)
        {
            if (args.Count == 0)
            {
                Status("No arguments were supplied from the command prompt");

                var argPath = FolderPath.Parse(Environment.CurrentDirectory) + FileName.Parse("args.txt");
                if (argPath.Exists())
                {
                    Status($"Inspecting the argument file {argPath} for command specifications");

                    var specNames = MutableList.Create<string>();
                    foreach (var line in metacore.rolist(map(argPath.ReadAllLines().Stream(), l => l.Trim())
                                   .Where(l => !String.IsNullOrWhiteSpace(l))))
                    {
                        var folder = new FolderPath(line);
                        if (folder.Exists())
                            specNames.AddRange(map(folder.Files(), file => file.FileSystemPath));
                        else
                            specNames.Add(line);
                    }


                    args = specNames.ToArray();
                    if (args.Count == 0)
                        Status("No arguments were supplied by file");
                    else
                        Status($"Found {args.Count} file-supplied arguments");
                }
                else
                    Status($"There is no argument file at {argPath}");
            }
            else
            { 
                var exec = HandleArgs(args);
                if (!exec)
                {
                    Error(exec.Message.Format());
                    return new AppExec(-1);
                }
            }

            return RunTerminal ? Interactive().Map(OnAppExec) : new AppExec(0);
                
        }

        protected virtual AppExec OnAppExec(AppExec exec)
        {
            exec.ShellTask.OnSome(t => t.Wait());
            return exec;
        }

        public T Service<T>()
            => Root.Service<T>();

        public T Service<T>(string ImplementationName)
           => Root.Service<T>(ImplementationName);

        public Option<T> TryGetService<T>()
            => Root.TryGetService<T>();

        public Option<object> TryGetService(ServiceIdentifier Identifier)
            => TryGetService(Identifier);

        public Option<T> TryGetService<T>(string ImplementationName)
            => TryGetService<T>(ImplementationName);

        public T Setting<T>(string SettingName)
            => Root.Setting<T>(SettingName);

        public T Settings<T>()
            => Root.Settings<T>();

        public void PostMessage(IApplicationMessage message)
            => Root.PostMessage(message);

        public bool IsServiceProvided<T>(string ImplementationName = "Default")
            => Root.IsServiceProvided<T>(ImplementationName);

        public Option<T> TryGetValue<T>(string name)
            => Root.TryGetValue<T>(name);

        public void Dispose()
            => Root.Dispose();

        protected T Step<T>(Func<T> f, Func<T, IApplicationMessage> After)
        {
            var result = f();
            Notify(After(result));
            return result;
        }

        protected T Step<T>(IApplicationMessage Before, Func<T> f)
        {
            Notify(Before);
            return f();
        }

        protected T Step<T>(IApplicationMessage Before, Func<T> f, Func<T, IApplicationMessage> After)
        {
            Notify(Before);
            var result = f();
            Notify(After(result));
            return result;
        }
        protected Y Step<X, Y>(X input, Action<X> Before, Func<X, Y> F, Action<Y> After)
        {
            Before(input);
            var output = F(input);
            After(output);
            return output;
        }

        protected Y Step<B, X, Y>(B ambient, X input, Action<B, X> Before, Func<B, X, Y> F, Action<B, Y> After)
        {
            Before(ambient, input);
            var output = F(ambient, input);
            After(ambient, output);
            return output;
        }

    }

    public abstract class MetaApp<T, A> : MetaApp<T>
        where T : MetaApp<T, A>, new()
        where A : new()
    {

        protected static Option<AppExec> Run(T App, A Args)
        {
            try
            {
                return App.Execute(Args);
            }
            catch (Exception e)
            {
                return none<AppExec>(e);
            }

        }

        protected A Args;

        protected MetaApp(IMessageBroker NotificationBroker = null)
            : base(NotificationBroker)
        {
            Args = new A();
        }

        protected MetaApp(A Args, IMessageBroker NotificationBroker = null)
            : base(NotificationBroker)
        {
            this.Args = Args;
        }

        A save(A Args)
        {
            this.Args = Args;
            return this.Args;
        }

        protected abstract Option<AppExec> Execute(A args);

        protected override sealed Option<AppExec> Execute(IReadOnlyList<string> args)
        {
            var csxFiles = list(from arg in args where arg.EndsWith(".csx") select arg);
            if(csxFiles.Count != 0)
            {
                foreach (var csxFile in csxFiles.Stream())
                     SubmitCsxScript(csxFile);

                return Execute(new A());
            }

            try
            {
              
                Func<FilePath, A> toObject = path
                    => save(C.JsonSerializer().ObjectFromFile<A>(path));

                Func<FilePath, Option<AppExec>> exec = path
                    => Execute(toObject(path));

                Option<FilePath> jsonConfig = none<FilePath>();
                if (args.Any())
                {
                    var candidiate = FilePath.Parse(args.First());
                    if (candidiate.Exists())
                        jsonConfig = candidiate;
                }
                if (jsonConfig)
                    return jsonConfig.MapValueOrDefault(exec);


                var tries = stream(
                    FilePath.Parse($"{GetType().Name}.json"),
                    FilePath.Parse($"{GetType().Assembly.GetSimpleName()}.exe.json"),
                    FilePath.Parse($"{GetType().Assembly.GetSimpleName()}.json"),
                    FilePath.Parse("App.json"),
                    FilePath.Parse("App.config.json"),
                    FilePath.Parse("Service.json")
                    );

                foreach (var @try in tries)
                {
                    if (@try.Exists())
                    {
                        C.NotifyStatus("Initiating execution");
                        var result = exec(@try);
                        if (result.IsNone())
                            C.NotifyError($"Execution failed: {result.Message})");
                        else
                            C.NotifyStatus("Completed execution");
                        return result;

                    }
                }

            }
            catch (Exception e)
            {
                C.NotifyError(e);
            }

            return Execute(Args);
        }
    }

    public abstract class MetaApp<H, A, S> : MetaApp<H, A>
        where H : MetaApp<H, A, S>, new()
        where A : new()

    {
        protected MetaApp(A args, IMessageBroker NotificationBroker = null)
            : base(args, NotificationBroker)
        {
            this.ServiceDescription = ClrInterfaceDescription.Create<S>();
            this.Service = C.Service<S>();
        }

        protected MetaApp(IMessageBroker NotificationBroker = null)
            : this(new A(), NotificationBroker)
        {

        }

        protected S Service { get; private set; }

        protected ClrInterfaceDescription ServiceDescription { get; }

        protected void Notify(IOption result)
            => C.Notify(result.Message);

        protected virtual void HandleResult(IOption result)
        {
            Notify(result.Message);
        }
    }
}