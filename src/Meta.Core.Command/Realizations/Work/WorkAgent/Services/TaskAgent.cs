//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static metacore;

class TaskAgent<A,R> : ITaskAgent<R> 
    where A : IComputationAgent<R>
{

    public TaskAgent(A ComputationAgent, Action<R> PayloadObserver = null, Action<IAppMessage> MessageObserver = null)
    {      
        this.ComputationAgent = ComputationAgent;
        this.MessageObserver = MessageObserver ?? (message => SystemConsole.Get().Write(message));
        this.PayloadObserver = PayloadObserver ?? (payload => { });

        this._Task = defer(() => task(() =>
        {

            iter(Compute(), result => { });
            return Wait();

        }));
    }

    public A ComputationAgent { get; }

    Lazy<Task<IAppMessage>> _Task;

    public Task<IAppMessage> Task
        => _Task.Value;

    Action<IAppMessage> MessageObserver { get; }

    Action<R> PayloadObserver { get; }

    public IAppMessage Wait()
        => Task.Result;

    public void Dispose()
        => ComputationAgent.Dispose();
        
    Option<R> Publish(IAgentComputationResult<R> result)
    {
        MessageObserver(result.Description);
        if (result.Description.IsError())
            return none<R>(result.Description);
        else
        {
            PayloadObserver(result.Payload);
            return result.Payload;
        }                
    }

    public IEnumerable<R> Compute()
        => from result in ComputationAgent.Compute()
           let payload = Publish(result)
           where payload.IsSome()
           select payload.Require();

    void ITaskAgent<R>.Start()
        => Compute();

    void ITaskAgent<R>.Stop()
        => ComputationAgent.Stop();

    void ITaskAgent<R>.Pause()
        => ComputationAgent.Pause();

    void ITaskAgent<R>.Resume()
        => ComputationAgent.Resume();
}

