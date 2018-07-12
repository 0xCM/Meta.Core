//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using Meta.Core;

    using static metacore;
    using MetaFlow.WF;

    public static class SystemTaskX
    {
        public static SystemTaskResult DeclareFailure(this ISystemTask task, IAppMessage reason)
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

        public static SystemTaskResult DeclareFailure(this ISystemTaskDefinition task, IAppMessage reason)
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

        public static SystemTaskResult DeclareSuccess(this ISystemTask task, string ResultBody, IAppMessage message)
            => new SystemTaskResult
            (
                TaskId: task.TaskId,
                SourceNodeId: task.SourceNodeId,
                TargetNodeId: task.TargetNodeId,
                Succeeded: true,
                ResultBody: ResultBody,
                ResultDescription: message.IsEmpty ? null : message.Format(false),
                CorrelationToken: task.CorrelationToken
           );

        public static SystemTaskResult DeclareSuccess(this ISystemTaskDefinition task, string ResultBody, IAppMessage message)
            => new SystemTaskResult
            (
                TaskId: task.TaskId,
                SourceNodeId: task.SourceNodeId,
                TargetNodeId: task.TargetNodeId,
                Succeeded: true,
                ResultBody: ResultBody,
                ResultDescription: message.IsEmpty ? null : message.Format(false),
                CorrelationToken: task.CorrelationToken
           );

        public static SystemTaskResult Adjudicate(this ISystemTaskDefinition task, object @return)
        {
            if (@return is IOption)
            {
                var o = @return as IOption;
                if (o.IsNone)
                    return DeclareFailure(task, o.Message);
                else
                    return DeclareSuccess(task, null, o.Message);
            }
            else
                return DeclareSuccess(task, null, AppMessage.Empty);
        }

        public static SystemTaskResult Adjudicate(this ISystemTask task, object @return)
        {
            if (@return is IOption)
            {
                var o = @return as IOption;
                if (o.IsNone)
                    return DeclareFailure(task, o.Message);
                else
                    return DeclareSuccess(task, null, o.Message);
            }
            else
                return DeclareSuccess(task, null, AppMessage.Empty);

        }

        public static SystemEventReaction Adjudicate(this ISystemEventCapture @event, object @return)
        {
            if (@return is IOption)
            {
                var o = @return as IOption;
                if (o.IsNone)
                    return new SystemEventReaction(@event, false, o.Message);
                else
                    return new SystemEventReaction(@event, true, o.Message);
            }
            else
                return new SystemEventReaction(@event, true, AppMessage.Empty);
        }
    }
}