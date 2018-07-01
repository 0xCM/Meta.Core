//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Defines the possible states in which a <see cref="IServiceAgent"/> can be
/// </summary>
public static class ServiceAgentStateNames
{
    /// <summary>
    /// The empty/unspecified state
    /// </summary>
    public const string None = nameof(None);

    /// <summary>
    /// Agent has not been initialized
    /// </summary>
    public const string Uninitialized = nameof(Uninitialized);

    /// <summary>
    /// Agent is beginning operations
    /// </summary>
    public const string Starting = nameof(Starting);

    /// <summary>
    /// Agent is executing preconditions to enter the Initialized state
    /// </summary>
    public const string Initializing = nameof(Initializing);

    /// <summary>
    /// Agent has been initalized and is poised to enter the Started state
    /// </summary>
    public const string Initialized = nameof(Initialized);

    /// <summary>
    /// Agent has been started and will immediately enter the <see cref="Running"/> state
    /// </summary>
    public const string Started = nameof(Started);

    /// <summary>
    /// Agent is directing operations to carry out tasks for which it is responsible
    /// </summary>
    public const string Running = nameof(Running);

    /// <summary>
    /// Agent is in the process of attempting to stop execution
    /// </summary>
    public const string Stopping = nameof(Stopping);

    /// <summary>
    /// Agent has successfully entered the stopped state
    /// </summary>
    public const string Stopped = nameof(Stopped);

    /// <summary>
    /// Agent is in the process of attempting to pause execution
    /// </summary>
    public const string Pausing = nameof(Pausing);

    /// <summary>
    /// Agent has successfully entered the Paused state
    /// </summary>
    public const string Paused = nameof(Paused);

    /// <summary>
    /// Agent encountered an error
    /// </summary>
    public const string Error = nameof(Error);

    /// <summary>
    /// Agent is in the process of restarting operations after having been Paused
    /// </summary>
    public const string Resuming = nameof(Resuming);
}
