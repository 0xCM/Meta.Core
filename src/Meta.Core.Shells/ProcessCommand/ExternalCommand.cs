//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using Meta.Core;
using static metacore;

public abstract class ExternalCommand<T> : CommandSpec<T, int>
    where T : ExternalCommand<T>, new()
{

    protected readonly string ArgNamePrefix = "/";
    protected readonly string ArgValuePrefix = ":";
    protected readonly string ActionPrefix = String.Empty;
    

    protected ExternalCommand
    (
        string ActionPrefix = null, 
        string ArgNamePrefix = null, 
        string ArgValuePrefix = null
    ) 
    {
        this.ActionPrefix = ActionPrefix ?? String.Empty;
        this.ArgNamePrefix = ArgNamePrefix ?? "/";
        this.ArgValuePrefix = ArgValuePrefix ?? ":";
    }


    protected virtual string ActionName
        => typeof(T).GetCustomAttribute<CommandActionSpecAttribute>()?.ActionName ?? String.Empty;

    protected virtual string FormatArgument(CommandArgument arg)
    {
        if (isBlank(toString(arg.Value)))
        {
            return String.Empty;
        }
        else
        {
            var value = Script.SpecifyEnvironmentParameters(arg.Value.ToString());
            if(isBlank(arg.Name))
            {
                return value;
            }

            if (arg.IsBit)
            {
                if (arg.GetValue<bool>())
                    return arg.Name;
                else
                    return string.Empty;
            }

           return $"{ArgNamePrefix}{arg.Name}{ArgValuePrefix}{value}";
        }         
    }

    protected virtual FileName ExecutableFileName
        => FileName.Empty;

    protected virtual FilePath ExecutablePath
        =>  FilePath.Parse(ExecutableFileName);

    public virtual FileName BatchFileName
        => new FileName(typeof(T).Name, "bat");

    public void SaveCommand(FolderPath location)
        => SaveCommand(location.GetCombinedFilePath(BatchFileName));

    public void SaveCommand(FilePath path)
        => path.Write(FormatValue()); 

    public Task Execute()
    {
        var p = Process.Start(ExecutablePath, FormatArguments());
        return Task.Run(() =>
        {
            p.WaitForExit();
            p.Dispose();
        });

    }


    public virtual string FormatArguments()
    {
        var values = map(Arguments, FormatArgument);
        return string.Join(" ", values);
    }

    public override string ToString() 
        => FormatValue();
}
