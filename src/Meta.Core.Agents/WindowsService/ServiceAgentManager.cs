//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
#if NetFramework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Configuration.Install;
using System.Text.RegularExpressions;


/// <summary>
/// Defines service managment utilities
/// </summary>
public static class ServiceAgentManager
{
    static readonly Regex NamedArgument
        = new Regex(@"\/(?<Name>[a-zA-Z]*)[:](?<Value>(.)*)", RegexOptions.Compiled);

    static void InstallService(Assembly host) 
        => ManagedInstallerClass.InstallHelper(new string[] { host.Location });

    static void UninistallService(Assembly host) 
        => ManagedInstallerClass.InstallHelper(new string[] { "/u", host.Location });

    static ServiceAgentSettings Settings 
        => new ServiceAgentSettings();

    static void Setup(string arg)
    {
        try
        {
            var host = Assembly.GetExecutingAssembly();
            switch (arg)
            {
                case "i":
                case "install":
                    InstallService(host);
                    break;
                case "u":
                case "uninstall":
                    UninistallService(host);
                    break;
                default:
                    Console.WriteLine($"The parameter value {arg} for the setup action is not recognized");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    static void OnAgentCreationError(string identifier, Exception e)
    {
        var color = Console.ForegroundColor;
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error encountered when attempting to create agent {identifier}: {e}");
            Console.WriteLine();
        }
        finally
        {
            Console.ForegroundColor = color;
        }


    }

    static void RunConsoleApp(IEnumerable<IServiceAgent> agents)
    {
        using (var app = new ServiceAgentConsole(agents))
        {
            app.Run();
        }

    }

    static void RunConsoleApp(string[] args)
        => RunConsoleApp(ServiceAgentAdapter.CreateServiceAgents(args, OnAgentCreationError));


    static void RunServiceApp(IEnumerable<IServiceAgent> agents)
    {
        using (var app = new ServiceAgentApp(agents))
        {
            app.Run();
        }

    }

    static void RunServiceApp(string[] args)
        => RunServiceApp(args);

    static string GetGroupValue(Match m, string name)
    {
        if (!m.Groups[name].Success)
            throw new ArgumentException($"The group {name} was not matched successfully");

        return m.Groups[name].Value;
    }

    static IReadOnlyDictionary<string, string> ParseArgs(IEnumerable<string> args)
    {
        var results = new Dictionary<string, string>();
        foreach (var arg in args)
        {
            var m = NamedArgument.Match(arg);
            if (m.Success)
                results[GetGroupValue(m, "Name").ToLower()] = GetGroupValue(m, "Value").ToLower();
        }
        return results;
    }

    /// <summary>
    /// Runs the application as either a windows service or a command shell depending on whether the
    /// environment is interactive
    /// </summary>
    /// <param name="args"></param>
    public static void Manage(string[] args)
    {
        if (Environment.UserInteractive)
        {
            var d = ParseArgs(args);
            if (d.ContainsKey("setup"))
                Setup(d["setup"]);
            else
                RunConsoleApp(args);
        }
        else
            RunServiceApp(args);

    }

    public static void Manage(IEnumerable<IServiceAgent> agents)
    {
        if (Environment.UserInteractive)
            RunConsoleApp(agents);
        else
            RunServiceApp(agents);

    }

}
#endif