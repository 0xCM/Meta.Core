//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

using Meta.Core;

using static metacore;

public class CommandProcessPattern
{
    public static Task<CommandProcessExecutionLog> Invoke(FilePath ExecutablePath, string args, string workdir = null)
    {
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = ExecutablePath,
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = workdir ?? Environment.CurrentDirectory
            },
            EnableRaisingEvents = true,
        };

        var result = new CommandProcessExecutionLog();

        proc.OutputDataReceived += (sender, e) =>
        {
            if (isNotBlank(e.Data))
            {
                result.StatusMessages.Add(e.Data);
                SystemConsole.Get().Write(AppMessage.Inform(e.Data));
            }
        };
        proc.ErrorDataReceived += (sender, e) =>
        {
            if (isNotBlank(e.Data))
            {
                result.ErrorMessages.Add(e.Data);
                SystemConsole.Get().Write(AppMessage.Error(e.Data));
            }

        };

        proc.Start();
        proc.BeginOutputReadLine();
        proc.BeginErrorReadLine();


        return Task.Run(() =>
        {
            proc.WaitForExit();
            result.ExitCode = proc.ExitCode;

            proc.Dispose();

            return result;
        });

    }

}

public abstract class CommandProcessPattern<I, TSpec, TPayload> : CommandExecutionService<I, TSpec, TPayload>
    where I : CommandProcessPattern<I, TSpec, TPayload>
    where TSpec : CommandSpec<TSpec, TPayload>, new() 
{


    protected static T SupplyDefaults<T>(T input)
        where T : new()
    {
        var output = new T();
        foreach (var prop in props<T>())
        {
            var outputval = prop.GetValue(input);
            if (outputval is null)
            {
                outputval = prop.GetOptionalAttribute<DefaultValueAttribute>()
                               .Map(attrib => attrib.Value)
                               .ValueOrDefault();

            }
            if (isNotNull(outputval))
                prop.SetValue(output, outputval);
        }
        return output;
    }


    protected override Option<TPayload> TryExecute(TSpec spec)
    {
        var args = FormatArguments(spec);
        var log = CommandProcessPattern.Invoke(ExecutableName.ToString(), args).Result;
        return InterpretOutome(log);
    }

    protected abstract string FormatArguments(TSpec spec);

    protected virtual string GetWorkingDirectory(TSpec spec)
        => Environment.CurrentDirectory;

    protected abstract Option<TPayload> InterpretOutome(CommandProcessExecutionLog log);

    protected abstract FileName ExecutableName { get; }

    public CommandProcessPattern(IApplicationContext context)
        : base(context)
    {

    }
}
