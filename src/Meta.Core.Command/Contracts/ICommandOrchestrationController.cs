//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

/// <summary>
/// Defines contract for managing and interrogating a command orchestration agent
/// </summary>
public interface ICommandOrchestrationController : IDisposable
{
    /// <summary>
    /// Initiates orchestration control and is subsequently prepared
    /// to manage orchesrations for an arbitrary collection of specification types
    /// </summary>
    void Start();

    /// <summary>
    /// Initiates orchestration control for a given specification type and configuration
    /// </summary>
    void Start(Type SpecType, CommandOrchestrationSettings Settings = null);

    /// <summary>
    /// Suspends orchestration control
    /// </summary>
    /// <param name="timeout"></param>
    void Stop(int timeout = -1);

    /// <summary>
    /// Suspends orchestration control for an identified specification type
    /// </summary>
    /// <param name="SpecType"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    bool Stop(Type SpecType, int timeout = -1);

    void TryStop(int timeout = -1);

    bool TryStop(Type SpecType, int timeout = -1);

    bool IsRunning();

    bool IsRunning(Type SpecType);
}

