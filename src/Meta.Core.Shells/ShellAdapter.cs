//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using static metacore;

    public class ShellAdapter
    {
        public static Option<ShellAdapter> Adapt(FilePath ExePath, string Args, Action<string> DataReceiver, Action<string> ErrorReceiver)
            => Try(() => new ShellAdapter(ExePath, Args, DataReceiver, ErrorReceiver));
            
        ShellAdapter(FilePath ExePath, string Args, Action<string> DataReceiver, Action<string> ErrorReceiver)
        {
            this.ExePath = ExePath;
            this.Args = Args;
            this.DataReceiver = DataReceiver;
            this.ErrorReceiver = ErrorReceiver;
            var run = Run();
            this.Control = run.Conrol;
            this.Controlled = run.Controlled;
        }

        FilePath ExePath { get; }

        string Args { get; }

        Action<string> DataReceiver { get; }


        Action<string> ErrorReceiver { get; }


        Task<CommandProcessExecutionLog> Control { get; }

        Process Controlled { get; }

        public void Send(string Data)
            => Controlled.StandardInput.WriteLineAsync(Data);            

        (Task<CommandProcessExecutionLog> Conrol, Process Controlled) Run()            
        {
            var controlled = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ExePath,
                    Arguments = Args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true
                },
                EnableRaisingEvents = true,
            };

            var result = new CommandProcessExecutionLog();

            controlled.OutputDataReceived += (sender, e) =>
            {
                if (isNotBlank(e.Data))
                {
                    result.StatusMessages.Add(e.Data);
                    DataReceiver(e.Data);                    
                }

            };

            controlled.ErrorDataReceived += (sender, e) =>
            {
                if (isNotBlank(e.Data))
                {
                    result.ErrorMessages.Add(e.Data);
                    ErrorReceiver(e.Data);
                }
            };

            controlled.Start();
            controlled.BeginOutputReadLine();
            controlled.BeginErrorReadLine();


            var control = Task.Run(() =>
            {
                controlled.WaitForExit();
                controlled.Dispose();
                return result;
            });

            return (control, controlled);
        }

    }

}