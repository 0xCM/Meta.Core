//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using MetaFlow.WF;

    public sealed class SystemTaskResult<R> : ISystemTaskResult
        where R : ISystemTaskResult
    {
        ISystemTaskResult Result { get; }

        public SystemTaskResult(ISystemTaskResult Result, R ResultBody)
        {
            this.Result = Result;
            this.ResultBody = ResultBody;
        }

        public R ResultBody { get; }

        long ISystemTaskResult.TaskId
            { get => Result.TaskId; set => Result.TaskId = value; }

        string ISystemTaskResult.SourceNodeId
            { get => Result.SourceNodeId; set => Result.SourceNodeId = value; }

        string ISystemTaskResult.TargetNodeId
            { get => Result.TargetNodeId; set => Result.TargetNodeId = value; }

        bool ISystemTaskResult.Succeeded
            { get => Result.Succeeded; set => Result.Succeeded = value; }

        string ISystemTaskResult.ResultBody
            { get => Result.ResultBody; set => Result.ResultBody = value; }

        string ISystemTaskResult.ResultDescription
            { get => Result.ResultDescription; set => Result.ResultDescription = value; }

        string ISystemTaskResult.CorrelationToken
            { get => Result.CorrelationToken; set => Result.CorrelationToken = value; }
    }

}