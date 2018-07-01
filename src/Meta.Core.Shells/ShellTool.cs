//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using static metacore;


public static class ShellTool
{

    public static ShellIdentity GetShellIdentity(this TerminateShell command)
        => new ShellIdentity(command.Host, command.ShellName);

    public static Task<CommandProcessExecutionLog> Invoke<T>(string toolPath, ExternalCommand<T> spec)
        where T : ExternalCommand<T>, new()
    {

        var args = spec.FormatArguments();
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = toolPath,
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            },
            EnableRaisingEvents = true,
        };

        var result = new CommandProcessExecutionLog();

        proc.OutputDataReceived += (sender, e) =>
        {

            if (isNotBlank(e.Data))
            {
                result.StatusMessages.Add(e.Data);
                SystemConsole.Get().Write(ApplicationMessage.Inform(e.Data));

            }


        };
        proc.ErrorDataReceived += (sender, e) =>
        {
            if (isNotBlank(e.Data))
            {
                result.ErrorMessages.Add(e.Data);
                SystemConsole.Get().Write(ApplicationMessage.Error(e.Data));
            }

        };

        proc.Start();
        proc.BeginOutputReadLine();
        proc.BeginErrorReadLine();


        return Task.Run(() =>
        {
            proc.WaitForExit();
            proc.Dispose();
            return result;
        });

    }

}

