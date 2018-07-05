//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Agent state descriptor
/// </summary>
public struct ServiceAgentState : IEquatable<ServiceAgentState>
{
    public static implicit operator ServiceAgentState(string StateName)
        => new ServiceAgentState(StateName);


    internal ServiceAgentState(string StateName)
    {
        this.StateName = StateName;
    }

    /// <summary>
    /// Specifies the name of the agent's current state
    /// </summary>
    public string StateName { get; }


    /// <summary>
    /// Specifies whether the agent is uninitialized
    /// </summary>
    public bool IsUnitialized
        => StateName == ServiceAgentStateNames.Uninitialized;

    /// <summary>
    /// Specifies whether the agent is starting
    /// </summary>
    public bool IsStarting
        => StateName == ServiceAgentStateNames.Starting;

    /// <summary>
    /// Specifies whether the agent is initializing
    /// </summary>
    public bool IsInitializing
        => StateName == ServiceAgentStateNames.Initializing;

    /// <summary>
    /// Specifies whether the agent is currently in the initialized state
    /// </summary>
    public bool IsInitalized
        => StateName == ServiceAgentStateNames.Initialized;

    /// <summary>
    /// Specifies whether the agent is paused
    /// </summary>
    public bool IsPaused
        => StateName == ServiceAgentStateNames.Paused;

    /// <summary>
    /// Specifies whether the agent is attempting to pause
    /// </summary>
    public bool IsPausing
        => StateName == ServiceAgentStateNames.Pausing;

    /// <summary>
    /// Specifies whether the agent is attempting to stop
    /// </summary>
    public bool IsStopping
        => StateName == ServiceAgentStateNames.Stopping;

    /// <summary>
    /// Specifies whether the agent is stopped
    /// </summary>
    public bool IsStopped
        => StateName == ServiceAgentStateNames.Stopped;

    /// <summary>
    /// Specifies whether the agent is executing its primary set of functions
    /// </summary>
    public bool IsRunning
        => StateName == ServiceAgentStateNames.Running;

    /// <summary>
    /// Specifies whether the agent is attempting to resume execution after pause
    /// </summary>
    public bool IsResuming
        => StateName == ServiceAgentStateNames.Resuming;

    /// <summary>
    /// Specifies whether the agent is in an error state
    /// </summary>
    public bool IsError
        => StateName == ServiceAgentStateNames.Error;

    /// <summary>
    /// Determines whether the agent has reached an end-state
    /// </summary>
    public bool IsTerminal
        => IsError || IsStopped;

    public bool IsOneOf(params ServiceAgentState[] candidates)
        => candidates.Contains(this);

    public override string ToString()
        => StateName;

    public override bool Equals(object obj)
        => obj is ServiceAgentState 
            ? Equals((ServiceAgentState)obj)
            : false;

    public override int GetHashCode()
        => StateName.ToLower().GetHashCode();

    public bool Equals(ServiceAgentState other)
        => string.Compare(this.StateName, other.StateName, true) == 0;
    
}


