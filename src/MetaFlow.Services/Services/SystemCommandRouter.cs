//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;

    using static metacore;
    using static StatusMessages;

    using MetaFlow.WF;
    using SqlT.Core;

    class SystemCommandRouter : PlatformService<SystemCommandRouter, ISystemCommandRouter>, ISystemCommandRouter
    {

        ISystemTaskResult RoutingFailed(ISystemTaskDefinition task, IAppMessage reason)
            => new SystemTaskResult
            (
                TaskId: task.TaskId,
                SourceNodeId: task.SourceNodeId,
                TargetNodeId: task.TargetNodeId,
                Succeeded: false,
                ResultBody: null,
                ResultDescription: reason.Format(false),
                CorrelationToken: task.CorrelationToken
           );

        ISystemTaskResult RoutingFailed(ISystemTask task, IAppMessage reason)
            => new SystemTaskResult
            (
                TaskId: task.TaskId,
                SourceNodeId: task.SourceNodeId,
                TargetNodeId: task.TargetNodeId,
                Succeeded: false,
                ResultBody: null,
                ResultDescription: reason.Format(false),
                CorrelationToken: task.CorrelationToken

           );


        IReadOnlyDictionary<SystemCommandUri, ISystemTaskHandler> HandlerLookup { get; }


        public SystemCommandRouter(INodeContext C)
            : base(C)
        {

            HandlerLookup = dict(from h in Reflector.SystemTaskHandlers from c in h.SupportedCommands select (c, h));
        }

        Option<ISystemTaskHandler> LookupReceiver(string commandUri)
        {

            var refUri = SystemCommandUri.Parse(commandUri).ToReferenceUri();
            if (HandlerLookup.TryGetValue(refUri, out ISystemTaskHandler executor))
                return some(executor);
            else
                return none<ISystemTaskHandler>(ExecutorNotFound(commandUri));
        }


        IEnumerable<SystemCommandUri> ISystemCommandRouter.SupportedCommands
            => HandlerLookup.Keys;

        SystemNode INodeComponent.Host
            => C.Host;

        ISystemTaskResult ISystemCommandRouter.Route(ISystemTaskDefinition task)
        {
            Notify(Executing(task.CommandUri, task.TaskId));

            var result = LookupReceiver(task.CommandUri)
                        .MapValueOrElse(e => e.ExecuteTask(task),
                            reason => RoutingFailed(task, reason));

            if (result.Succeeded)
            {
                Notify(ExecutionSuccess(task.CommandUri, task.TaskId));
                if (isNotBlank(result.ResultDescription))
                    Notify(inform(result.ResultDescription));
            }
            else
                Notify(ExecutionFailure(task.CommandUri, task.TaskId, result.ResultDescription));

            return result;

        }

        ISystemTaskResult ISystemCommandRouter.Route(ISystemTask task)
        {
            Notify(Executing(task.CommandUri, task.TaskId));

            var result = LookupReceiver(task.CommandUri)
                        .MapValueOrElse(e => e.ExecuteTask(task),
                            reason => RoutingFailed(task, reason));

            if (result.Succeeded)
            {
                Notify(ExecutionSuccess(task.CommandUri, task.TaskId));
                if (isNotBlank(result.ResultDescription))
                    Notify(inform(result.ResultDescription));
            }
            else
                Notify(ExecutionFailure(task.CommandUri, task.TaskId, result.ResultDescription));

            return result;
        }
    }    
}