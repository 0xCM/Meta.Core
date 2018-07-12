//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Reflection;
    using System.Linq;

    using Meta.Core;

    /// <summary>
    /// Describes the outcome of DAC deployment operation
    /// </summary>
    public class DacDeploymentSummary  : IOption
    {
        public DacDeploymentSummary(NodeFilePath SourcePackage, SystemNodeIdentifier TargetNode, IAppMessage Message, CorrelationToken? CT = null)
        {
            this.SourcePackage = SourcePackage;
            this.TargetNode = TargetNode;
            this.Succeded = !Message.IsError();
            this.Message = Message;
            this.CT = CT;
        }

        public NodeFilePath SourcePackage { get; }

        public SystemNodeIdentifier TargetNode { get; }

        public bool Succeded { get; }

        public IAppMessage Message { get; }

        public CorrelationToken? CT { get; }

        public Type ValueType
            => GetType();

        object IOption.Value
            => Succeded ? this : null;

        bool IOption.IsSome 
            => Succeded;

        bool IOption.IsNone 
            => !Succeded;
    }
}
