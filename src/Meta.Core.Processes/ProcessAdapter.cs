//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

using static metacore;

using Meta.Core.Messaging;
      
/// <summary>
/// Mediates access to a console process
/// </summary>
public class ProcessAdapter : IProcess
{
    static bool IsExec(IMessage message)
        => message.Type == "exec";

    static FilePath ConEmuCommandProcessor
        => (CommonFolders.DevTools + FolderName.Parse("conmu")) 
                + FileName.Parse("ConEmu64.exe");

    static FilePath NativeCommandProcessor
        => "cmd.exe";

    static FilePath SelectedCommandProcessor
        => NativeCommandProcessor;

    public static ProcessAdapter ExecuteCmd
        (
            Action<MessagePacket> StandardReceiver,
            Action<MessagePacket> ErrorReceiver,
            Func<IMessage, IMessage> TransmissionInspector
        ) => ExecuteProcess(SelectedCommandProcessor,
            StandardReceiver,
            ErrorReceiver,
            TransmissionInspector,
            "/K");
        

    public static ProcessAdapter ExecuteProcess
        (
            string exepath,
            Action<MessagePacket> StandardReceiver,
            Action<MessagePacket> ErrorReceiver,
            Func<IMessage, IMessage> TransmissionInspector,
            params string[] initArgs
        ) => new ProcessAdapter(exepath, 
            StandardReceiver, 
            ErrorReceiver,
            TransmissionInspector, 
            initArgs);

    static void ConfigureStart(ProcessStartInfo si, string exepath, params string[] initArgs)
    {
        si.FileName = exepath;
        si.Arguments = string.Join(" ", initArgs);
        si.RedirectStandardError = true;
        si.RedirectStandardInput = true;
        si.RedirectStandardOutput = true;
        si.CreateNoWindow = true;
        si.UseShellExecute = false;
        si.StandardErrorEncoding = Encoding.UTF8;
        si.StandardOutputEncoding = Encoding.UTF8;
    }

    Process AdaptedProcess { get; }

    Action<MessagePacket> StandardReceiver { get; }

    Action<MessagePacket> ErrorReceiver { get; }

    Func<IMessage, IMessage> TransmissionInspector { get; }

    ConcurrentQueue<IMessage> messages = new ConcurrentQueue<IMessage>();
    IMessage lastMessage;

    void Start()
    {
        AdaptedProcess.Start();
            
        Task.Factory.StartNew(RunStandardReceptionLoop)
            .ContinueWith(t => Console.WriteLine("Standard Reception Loop Terminated"));
        Task.Factory.StartNew(RunErrorReceptionLoop)
            .ContinueWith(t => Console.WriteLine("Error Reception Loop Terminated"));
        Task.Factory.StartNew(RunTransmissionLoop)
            .ContinueWith(t => Console.WriteLine("Dispatch Loop Terminated"));
    }



    ProcessAdapter(string exepath,
            Action<MessagePacket> StandardReceiver,
            Action<MessagePacket> ErrorReceiver,
            Func<IMessage,IMessage> TransmisionInspector,
            params string[] initArgs
        )
    {
        AdaptedProcess = new Process();
        this.StandardReceiver = StandardReceiver;
        this.ErrorReceiver = ErrorReceiver;
        this.TransmissionInspector = TransmisionInspector;
        ConfigureStart(AdaptedProcess.StartInfo, exepath, initArgs);
        AdaptedProcess.EnableRaisingEvents = true;
        AdaptedProcess.Exited += (sender, args) => Console.WriteLine($"Process exited");          
        Start();
    }


    enum Succeeded
    {
        No,
        Yes
    }

    static Succeeded Try(Action a, [CallerMemberName] string member = null)
    {
        try
        {
            a();
            return Succeeded.Yes;
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error occurred in {member}: {e.Message}");
            return Succeeded.No;
        }
    }

    MessagePacket Pack(string payload)
        => new MessagePacket(
            CorrelationToken: lastMessage?.MessageId ?? Guid.Empty,
            Payload: payload,
            Label: 
                (IsExec(lastMessage) && lastMessage.Payload.Contains(' ')) 
                ? lastMessage.Payload.Split(' ').First() 
                : lastMessage.Type
            );

    bool Running()
        => !AdaptedProcess.HasExited;

    Task<string> ErrorOutput
        => AdaptedProcess.StandardError.ReadLineAsync();

    Task<string> StandarOutput
        => AdaptedProcess.StandardOutput.ReadLineAsync();

    void RunStandardReceptionLoop()
    {
        try
        {
            while (Running()
                && Try(() =>
                    StandardReceiver(Pack(StandarOutput.Result))) == Succeeded.Yes)
            {
                //Yes, I'm empty
            }
        }
        catch(Exception e)
        {
            ErrorReceiver(Pack(e.ToString()));
        }
    }

    void RunErrorReceptionLoop()
    {
        while (Running()
            && Try(() => ErrorReceiver(Pack(ErrorOutput.Result))) == Succeeded.Yes)
        {
            //So am I

        }
    }

    public CorrelationToken Transmit(IMessage command)
    {
        var token = CorrelationToken.Create();
        messages.Enqueue(stream(command, new Message("",$"echo command {token} completed")));
        return token;

    }

    public int ExitCode
        => AdaptedProcess.ExitCode;

    public int Id
        => AdaptedProcess.Id;

    public int WaitForExit()
    {
        AdaptedProcess.WaitForExit();
        return ExitCode;
    }

    void RunTransmissionLoop()
    {
        while (Running())
        {
            while (messages.TryDequeue(out IMessage m))
            {
                try
                {
                    lastMessage = m;
                    var text = IsExec(m) ? $"{m.Body}" : $"{m.Type} {m.Body}";
                    AdaptedProcess.StandardInput.WriteLine(text);
                    AdaptedProcess.StandardInput.Flush();
                    TransmissionInspector?.Invoke(m);
                }
                catch(Exception e)
                {
                    TransmissionInspector?.Invoke(new Message("error", e.ToString()));
                }

            }
            Task.Delay(1000).Wait();
        }
    }

}

