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

    public string StateName { get; }


    public bool IsNone
        => string.IsNullOrWhiteSpace(StateName);

    public bool IsUnitialized
        => StateName == ServiceAgentStateNames.Uninitialized;

    public bool IsStarting
        => StateName == ServiceAgentStateNames.Starting;

    public bool IsInitializing
        => StateName == ServiceAgentStateNames.Initializing;

    public bool IsInitalized
        => StateName == ServiceAgentStateNames.Initialized;

    public bool IsPaused
        => StateName == ServiceAgentStateNames.Paused;

    public bool IsPausing
        => StateName == ServiceAgentStateNames.Pausing;

    public bool IsStopping
        => StateName == ServiceAgentStateNames.Stopping;

    public bool IsStopped
        => StateName == ServiceAgentStateNames.Stopped;

    public bool IsRunning
        => StateName == ServiceAgentStateNames.Running;

    public bool IsResuming
        => StateName == ServiceAgentStateNames.Resuming;

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


