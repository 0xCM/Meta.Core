//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Linq;

    using static metacore;

    public class ShellAdapter  : IShellAdapter
    {
        /// <summary>
        /// Constructs a <see cref="IShellAdapter"/> realization predicated on the supplied data
        /// </summary>
        /// <param name="ExePath">The path to the executable for which IO mediation will occur</param>
        /// <param name="Args">The arguments supplied to creating the associated shell process</param>
        /// <param name="DataReceiver">The data receiver</param>
        /// <param name="ErrorReceiver">The error receiver</param>
        /// <param name="WorkingDir">The working directory to specify when creating the process, if specified. 
        /// If unspecified, the current working directory will be used</param>
        /// <remarks>The adapted process can only be termined by the OS when the spawning process is termined
        /// or when an adaptee-specific command is issued that effects process termination</remarks>
        public static Option<ShellAdapter> make(FilePath ExePath, string Args, Action<string> DataReceiver, 
            Action<string> ErrorReceiver, FolderPath WorkingDir = null)
                => Try(() => new ShellAdapter(ExePath, Args, DataReceiver, ErrorReceiver));
            
        ShellAdapter(FilePath ExePath, string Args, Action<string> DataReceiver, Action<string> ErrorReceiver, FolderPath WorkingDir = null)
        {
            this.ExePath = ExePath;
            this.Args = Args;
            this.DataReceiver = DataReceiver;
            this.ErrorReceiver = ErrorReceiver;
            this.WorkingDir = WorkingDir ?? FolderPath.CurrentDirectory;
            var run = Run();
            this.Control = run.Conrol;
            this.Controlled = run.Controlled;
        }

        FolderPath WorkingDir { get; }

        FilePath ExePath { get; }

        string Args { get; }

        public Action<string> DataReceiver { get; }

        public Action<string> ErrorReceiver { get; }

        public Action<string> DataSender
            => input => Send(input);

        Task<CommandProcessExecutionLog> Control { get; }

        Process Controlled { get; }

        void Send(string Data)
            => Controlled.StandardInput.WriteLineAsync(Data);            

        /// <summary>
        /// Defines the control loop
        /// </summary>
        /// <returns></returns>
        (Task<CommandProcessExecutionLog> Conrol, Process Controlled) Run()            
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ExePath,
                    Arguments = Args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    WorkingDirectory = WorkingDir                                       
                },
                EnableRaisingEvents = true,
            };

            var result = new CommandProcessExecutionLog();
            process.OutputDataReceived += (sender, e) =>
            {
                if (isNotBlank(e.Data))
                {
                    result.StatusMessages.Add(e.Data);
                    DataReceiver(e.Data);                    
                }

            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (isNotBlank(e.Data))
                {
                    result.ErrorMessages.Add(e.Data);
                    ErrorReceiver(e.Data);
                }
            };

            process.Start();

            //Registering the process as a child ensures that when 
            //the spawning process terminates, if the shell process is still running,
            //it will be terminated by the OS
            ChildProcess.Add(process).Require();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            var control = Task.Run(() =>
            {
                process.WaitForExit();
                process.Dispose();
                return result;
            });

            return (control, process);
        }

    }

}