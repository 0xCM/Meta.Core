//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using N = SystemNodeIdentifier;


    public class NodeVariable
    {

        public NodeVariable(N NodeId, string VariableName, string VariableValue)
        {
            this.NodeId = NodeId;
            this.VariableName = VariableName;
            this.VariableValue = VariableValue;

        }

        public N NodeId { get; }

        public string VariableName { get; }

        public string VariableValue { get; }

        public override string ToString()
            => $"{NodeId}::{VariableName}={VariableValue}";
    }



}