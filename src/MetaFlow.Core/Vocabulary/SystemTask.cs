//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    using MetaFlow.WF;
    using N = SystemNodeIdentifier;

    public sealed class SystemTask<C> : ISystemTask
        where C : ISystemCommand
    {

        ISystemTask Task { get; }

        public SystemTask(ISystemTask Task, C Command)
        {
            this.Task = Task;
            this.Command = Command;
        }

        public N SourceNode
            => Task.SourceNodeId;

        public N TargetNode
            => Task.SourceNodeId;

        public SystemIdentifier TargetSystem
            => Task.TargetSystemId;

        public SystemUri CommandUri
            => SystemUri.Parse(Task.CommandUri);

        public C Command { get; }

        long ISystemTask.TaskId
        {
            get { return Task.TaskId; }
            set { }
        }

        string ISystemTask.SourceNodeId
        {
            get { return Task.SourceNodeId; }
            set { }
        }

        string ISystemTask.TargetNodeId
        {
            get { return Task.TargetNodeId; }
            set { }
        }

        string ISystemTask.TargetSystemId
        {
            get { return Task.TargetSystemId; }
            set { }
        }

        string ISystemTask.CommandUri
        {
            get { return Task.CommandUri; }
            set { }
        }

        string ISystemTask.CommandBody
        {
            get { return Task.CommandBody; }
            set { }
        }

        DateTime ISystemTask.SubmittedTS
        {
            get { return Task.SubmittedTS; }
            set { }
        }

        DateTime? ISystemTask.DispatchTS
        {
            get { return Task.DispatchTS; }
            set { }
        }

        string ISystemTask.CorrelationToken
        {
            get { return Task.CorrelationToken; }
            set { }
        }
    }



}