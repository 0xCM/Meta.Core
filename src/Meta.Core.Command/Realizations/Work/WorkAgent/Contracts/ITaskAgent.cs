//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface ITaskAgent<P> 
{
    /// <summary>
    /// Initiates agent exececution
    /// </summary>
    void Start();

    /// <summary>
    /// Halts agent execution
    /// </summary>
    void Stop();

    /// <summary>
    /// Halts agent work but retains any accumulated state necessary to resume function and
    /// transitions agent to the Paused state
    /// </summary>
    void Pause();

    /// <summary>
    /// Places the agent in the running state after execution has been paused 
    /// </summary>
    void Resume();

    Task<IAppMessage> Task { get; }

    IAppMessage Wait();

    IEnumerable<P> Compute();


}
