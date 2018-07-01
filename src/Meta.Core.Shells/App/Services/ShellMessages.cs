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

using static metacore;
using Meta.Core;

public static class ShellMessages
{

    public static IApplicationMessage CompletedCommand(ICommandResult result)
        => result.Succeeded
        ? ApplicationMessage.Inform("Successfully completed execution of the @CommandName with submission id @SubmissionId", new
        {
            result.Spec.CommandName,
            result.SubmissionId
        })
        : result.Message;

    public static IApplicationMessage ListedNamedValue(string ItemName, object ItemValue)
        => ApplicationMessage.Inform($"{ItemName}:{ItemValue}");

    public static IApplicationMessage ControllerAlreadyRunning()
        => ApplicationMessage.Warn("Controller already running");

    public static IApplicationMessage CommandSpecNotFound(string SpecName)
        => ApplicationMessage.Error($"The '@SpecName' specification could not be found",
            new
            {
                SpecName
            });

    public static IApplicationMessage CommandNotFound(string CommandName)
        => ApplicationMessage.Error($"The @CommandName command could not be found",
            new
            {
                CommandName
            });

    public static IApplicationMessage SubmittedSpec(string SpecName)
        => ApplicationMessage.Inform($"The @SpecName specification was submitted",
            new
            {
                SpecName
            });


    public static IApplicationMessage HostException(string Summary, string Detail)
        => ApplicationMessage.Error("Error: @Summary - @Detail",
            new
            {
                Summary,
                Detail
            });

    public static IApplicationMessage SpecNotFound(string SpecName)
        => ApplicationMessage.Inform("The @SpecName command specification doesn't exist",
                new
                {
                    SpecName
                }
            );

    public static IApplicationMessage CommandLibraryUnspecified()
        => ApplicationMessage.Error("The Command Library cannot be instantiated",
                new
                {

                }
            );

    public static IApplicationMessage NoResultOrMessage(IConsoleCommand command)
        => ApplicationMessage.Warn("The @CommandName command had no result but had no explanation as to why",
                new
                {
                    CommandName = command.CommandName.ToString()
                }
            );




}