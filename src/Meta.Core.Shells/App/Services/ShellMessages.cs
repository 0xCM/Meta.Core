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

    public static IAppMessage CompletedCommand(ICommandResult result)
        => result.Succeeded
        ? AppMessage.Inform("Successfully completed execution of the @CommandName with submission id @SubmissionId", new
        {
            result.Spec.CommandName,
            result.SubmissionId
        })
        : result.Message;

    public static IAppMessage ListedNamedValue(string ItemName, object ItemValue)
        => AppMessage.Inform($"{ItemName}:{ItemValue}");

    public static IAppMessage ControllerAlreadyRunning()
        => AppMessage.Warn("Controller already running");

    public static IAppMessage CommandSpecNotFound(string SpecName)
        => AppMessage.Error($"The '@SpecName' specification could not be found",
            new
            {
                SpecName
            });

    public static IAppMessage CommandNotFound(string CommandName)
        => AppMessage.Error($"The @CommandName command could not be found",
            new
            {
                CommandName
            });

    public static IAppMessage SubmittedSpec(string SpecName)
        => AppMessage.Inform($"The @SpecName specification was submitted",
            new
            {
                SpecName
            });


    public static IAppMessage HostException(string Summary, string Detail)
        => AppMessage.Error("Error: @Summary - @Detail",
            new
            {
                Summary,
                Detail
            });

    public static IAppMessage SpecNotFound(string SpecName)
        => AppMessage.Inform("The @SpecName command specification doesn't exist",
                new
                {
                    SpecName
                }
            );

    public static IAppMessage CommandLibraryUnspecified()
        => AppMessage.Error("The Command Library cannot be instantiated",
                new
                {

                }
            );

    public static IAppMessage NoResultOrMessage(IConsoleCommand command)
        => AppMessage.Warn("The @CommandName command had no result but had no explanation as to why",
                new
                {
                    CommandName = command.CommandName.ToString()
                }
            );




}