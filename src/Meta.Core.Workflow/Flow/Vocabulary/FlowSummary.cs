//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public struct FlowSummary
    {
        public static FlowSummary operator + (FlowSummary x, FlowSummary y) 
            => new FlowSummary(x.TransformationName, x.Metrics + y.Metrics, x.ErrorMessages.Union(y.ErrorMessages));

        public FlowSummary(string TransformationName)
        {
            this.TransformationName = TransformationName;
            this.Metrics = new FlowMetrics(TransformationName, this.TransformationName);
            this.ErrorMessages = rolist<IApplicationMessage>();
        }

        public FlowSummary(string TransformationName, FlowMetrics metrics, IEnumerable<IApplicationMessage> ErrorMessages = null)
        {
            this.TransformationName = TransformationName;
            this.Metrics = metrics;
            this.ErrorMessages = rolist(ErrorMessages ?? array<IApplicationMessage>());
        }

        public FlowMetrics Metrics { get; set; }

        public string TransformationName { get; set; }

        public IReadOnlyList<IApplicationMessage> ErrorMessages { get; set; }

        public override string ToString() 
            => $"Emitted {Metrics.EmissionCount} target records from {Metrics.SelectionCount} source records";
    }




}