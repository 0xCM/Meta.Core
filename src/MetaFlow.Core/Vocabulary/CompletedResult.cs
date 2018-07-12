//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;

    using SqlT.Core;
    using MetaFlow.WF;

    using static metacore;

    public struct CompletedResult<R> where R : ITaskResult
    {
        public CompletedResult(R TaskResult, Option<int> CompletionResult)
        {
            this.TaskResult = TaskResult;
            this.CompletionResult = CompletionResult;
        }

        public R TaskResult { get; }

        public Option<int> CompletionResult { get; }

        public override string ToString()
            => ifBlank(TaskResult.ResultDescription, TaskResult.Succeeded ? "Success" : "Fail");
    }

}