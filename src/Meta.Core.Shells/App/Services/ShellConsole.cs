//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using System.Collections.Concurrent;
using Meta.Core;

using static metacore;

using static ShellMessages;

/// <summary>
/// Mediates access to the system console
/// </summary>
/// <remarks>
/// Access to the system console is serialized via a critical section and messages are 
/// displayed with a color-coding that indicates the trace/severity level of the message
/// </remarks>
public partial class ShellConsole : IShellConsole
{
    static object locker = new object();

    internal static ShellConsole Create(IMetaApp App)
        => new ShellConsole(App);

    ShellConsole(IMetaApp App)
    {
        this.App = App;
        StyleConsole();
    }

    IMetaApp App { get; }

    AutoResetEvent KeyPressSignal = new AutoResetEvent(false);

    char? LastKeyPressValue;

    Thread ConsoleMonitor;

    ConcurrentQueue<ICommandSpec> CommandQueue { get; }
        = new ConcurrentQueue<ICommandSpec>();

    Task ConsoleReceptionTask { get; set; }

    bool EndCommandProcessing()
        => false;

    public char ReadKey()
        => Console.ReadKey().KeyChar;

    static void EmitError(string text)
    {
        if (text.EndsWith(eol()))
            Console.Error.Write(text);
        else
            Console.Error.WriteLine(text);
    }

    static void EmitStandard(string text)
    {
        if (text.EndsWith(eol()))
            Console.Write(text);
        else
            Console.WriteLine(text);
    }

    public void PostCommand(ICommandSpec Command)
        => CommandQueue.Enqueue(Command);

    internal void Run(IApplicationContext context)
    {
        var provider = context.Service<IShellCommandProvider>();
        ConsoleReceptionTask = Task.Factory.StartNew(() => ReceiveConsoleInput(EndCommandProcessing));
        Host(provider, command => Handle(context, command));
    }

    void StyleConsole()
    {
        var settings = new ShellConsoleConfig { Height = 40, Width = 120 };
        settings.Height.OnValue(h => Height = h);
        settings.Width.OnValue(w => Width = w);
        settings.ForegroundColor.OnValue(f => ForegroundColor = f);
        settings.BackgroundColor.OnValue(f => BackgroundColor = f);
        if (settings.Clear.HasValue && settings.Clear.Value)
            Clear();
    }

    public char? ReadKey(int timeout)
    {
        if (ConsoleMonitor == null)
        {
            ConsoleMonitor = new Thread(new ThreadStart(() 
                =>{
                    while (true)
                    {
                        LastKeyPressValue = ReadKey();
                        KeyPressSignal.Set();
                    }
                }))
                {
                    IsBackground = true
                };
            ConsoleMonitor.Start();
        }

        return KeyPressSignal.WaitOne(timeout) 
            ? LastKeyPressValue 
            : (char?)null;
    }

    string EmitPrompt()
    {
        var prompt = $"{EnvironmentVariables.SystemNode.ResolveValue()}>";
        Console.Write(prompt);
        return prompt;
    }

    void ReceiveConsoleInput(Func<bool> cancel)
    {
        var input = string.Empty;
        while(!cancel())
        {
            var prompt = EmitPrompt();
            input = Console.ReadLine().Replace(prompt, String.Empty).Trim();
            if (isNotBlank(input))
            {
                if (input.EndsWith(";"))
                    CommandQueue.Enqueue(new TextCommand(input.Substring(0, input.Length - 1).Trim()));
                else
                    Write(warn("Input must be terminated by a semi-colon"));
            }
        }        
    }

    Option<ICommandSpec> NextCommand()
    {

        ICommandSpec command = null;
        while(!EndCommandProcessing())
        {
            if (CommandQueue.TryDequeue(out command))
                break;

            Task.Delay(250).Wait();
        }

        return isNull(command) 
            ? none<ICommandSpec>() 
            : some(command);
    }

    static bool IsExitCommand(ICommandSpec command)
    {
        if ((command as TextCommand)?.Text?.ToLower() == "exit()")
            return true;
        else if (command is TerminateShell)
            return true;
        else
            return false;      
    }

    static bool IsHelpCommand(ICommandSpec command)
        => ((command as TextCommand)?.Text?.ToLower() == "help()");

    protected virtual void DisplayHelp(IShellCommandProvider provider)
        => iter(provider.GetCommands(), c => WriteLine($"{c.CommandName}\t"));


    static IOption Handle(IApplicationContext context, IConsoleCommand command)
    {
        var subject = command.Subject;                                                           
        if (subject is ICommandSpec)
        {
            var executor = context.Service<IImmediateCommandExecutor>();
            var result = executor.Execute(subject as ICommandSpec);

            if (result.Succeeded)
                return some(result.Payload, result.Message);
            else
                return none<object>(result.Message);
        }

        if (subject is ScriptCommandInvocation)
        {
            try
            {
                var scp = context.Service<IScriptCommandProvider>();
                (subject as ScriptCommandInvocation).Invoke(scp);
                return some(true);
            }
            catch (Exception e)
            {
                return none<object>(e);
            }
        }

        return none<object>(error($"{command} not supported"));
    }

    void Host(IShellCommandProvider provider, Func<IConsoleCommand, IOption> handler)
    {
        var commands = provider.GetCommands().AsList();
        try
        {
            var cmd = NextCommand().ValueOrDefault();                                                            
            while (cmd != null)
            {
                if (IsExitCommand(cmd))
                    break;
                else if (IsHelpCommand(cmd))
                {
                    DisplayHelp(provider);
                    cmd = NextCommand().ValueOrDefault();
                }
                else if(cmd is TextCommand)
                {
                    var cmdExpr = (cmd as TextCommand).Text;

                    var scriptCommands = commands.Where(c => c.Subject is ScriptCommand).Select(c => (ScriptCommand)c.Subject);
                    var invocation = ScriptCommand.MatchInvocation(scriptCommands, cmdExpr)
                                        .OnNone(message => WriteError(message))
                                        .Map(i => new ConsoleScriptInvocation(i));
                    invocation.OnSome(i =>
                    {
                        var result = handler(i);
                        if (not(result.Message.IsEmpty))
                            Write(result.Message);
                        else
                            if (result.IsNone)
                            Write(NoResultOrMessage(i));

                    }).OnNone(() => Write(SpecNotFound(cmdExpr)));

                }
                else
                {
                    var result = handler(cmd.ToShellCommand());
                    if (not(result.Message.IsEmpty))
                        Write(result.Message);
                }

                cmd = NextCommand().ValueOrDefault();
            }
        }
        catch (Exception e)
        {
            Write(HostException(e.Message, e.ToString()));
            Host(provider, handler);
        }
    }


    public ConsoleColor BackgroundColor
    {
        get
        {
            return Console.BackgroundColor;
        }
        set
        {
            try
            {
                Console.BackgroundColor = value;
            }
            catch
            {
                //The right thing to do here is actually eat the exception;
                //Otherwise, errors will be reported when executing in an 
                //interactive window that doesn't respond properly to 
                //configuring window dimensions
            }
        }
    }

    public ConsoleColor ForegroundColor
    {
        get { return Console.ForegroundColor; }
        set
        {
            try
            {
                Console.ForegroundColor = value;
            }
            catch
            {
                //The right thing to do here is actually eat the exception;
                //Otherwise, errors will be reported when executing in an 
                //interactive window that doesn't respond properly to 
                //configuring window dimensions

            }
        }
    }

    public int Height
    {
        get
        {
            return Console.WindowHeight;
        }
        set
        {
            try
            {
                Console.WindowHeight = Math.Min(Console.LargestWindowHeight, value);
            }
            catch
            {
                //The right thing to do here is actually eat the exception;
                //Otherwise, errors will be reported when executing in an 
                //interactive window that doesn't respond properly to 
                //configuring window dimensions
            }
        }
    }

    public int Width
    {
        get
        {
            return Console.WindowWidth;
        }
        set
        {
            try
            {
                Console.WindowWidth = Math.Min(Console.LargestWindowWidth, value);
            }
            catch
            {
                //The right thing to do here is actually eat the exception;
                //Otherwise, errors will be reported when executing in an 
                //interactive window that doesn't respond properly to 
                //configuring window dimensions
            }
        }
    }

    public void WriteLine(string text)
       => Console.WriteLine(text);

    public void WriteError(object o)
        => Console.Error.WriteLine(o);

    public void WriteLine(object o)
        => WriteLine(o.ToString());

    public void Write(string message)
        => Console.Write(message);
    public void Write(IApplicationMessage Message, AppMessageFormatter MessageFormatter = null)
    {
        var text = MessageFormatter?.Invoke(Message) ?? Message.Format();
        Action<string> emit = EmitStandard;
        lock (locker)
        {
            var currentTextColor = ForegroundColor;
            var currentBGColor = BackgroundColor;
            switch (Message.EventLevel)
            {
                case EventLevel.Verbose:
                    ForegroundColor = ConsoleColor.Gray;
                    break;
                case EventLevel.Informational:
                case EventLevel.LogAlways:
                    ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case EventLevel.Warning:
                    ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case EventLevel.Error:
                    ForegroundColor = ConsoleColor.Red;
                    emit = EmitError;
                    break;
                case EventLevel.Critical:
                    ForegroundColor = ConsoleColor.Red;
                    BackgroundColor = ConsoleColor.Yellow;
                    emit = EmitError;
                    break;
            }

            emit(text);
            Console.BackgroundColor = currentBGColor;
            Console.ForegroundColor = currentTextColor;
        }

    }

    public string ReadLine()
        => Console.ReadLine();

    public void Clear()
    {
        try { Console.Clear(); }
        catch { Console.WriteLine("Could not clear the console"); }
    }

    public ConsoleColor TextColor
    {
        get
        {
            return Console.ForegroundColor;
        }
        set
        {
            try
            {
                Console.ForegroundColor = value;
            }
            catch
            {
                Console.WriteLine("Could not set the console foreground");
            }
        }
    }

    public void Write(IApplicationMessage message, Func<IApplicationMessage, string> formatter)
    {

        lock (locker)
        {
            var currentTextColor = TextColor;
            var currentBGColor = BackgroundColor;
            switch (message.EventLevel)
            {
                case EventLevel.Verbose:
                    TextColor = ConsoleColor.Gray;
                    break;
                case EventLevel.Informational:
                case EventLevel.LogAlways:
                    TextColor = ConsoleColor.DarkGreen;
                    break;
                case EventLevel.Warning:
                    TextColor = ConsoleColor.DarkYellow;
                    break;
                case EventLevel.Error:
                    TextColor = ConsoleColor.Red;
                    break;
                case EventLevel.Critical:
                    TextColor = ConsoleColor.Red;
                    BackgroundColor = ConsoleColor.Yellow;
                    break;
            }
            var output = formatter != null ? formatter(message) : message.Format();
            Console.WriteLine(output);
            Console.BackgroundColor = currentBGColor;
            Console.ForegroundColor = currentTextColor;
        }

    }
}
