//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public class FlowMetrics : ValueObject<FlowMetrics>
    {
        public static FlowMetrics operator + (FlowMetrics x, FlowMetrics y) 
            => new FlowMetrics(x.SourceTypeName, x.TargetTypeName, 
                x.SelectionCount + y.SelectionCount, 
                x.QueueLength + y.QueueLength,
                x.EmissionCount + y.EmissionCount,
                x.Duration + (y != null ? y.Duration : TimeSpan.Zero));

        public static FlowMetrics operator + (FlowMetrics x, SelectionCount y) 
            => new FlowMetrics(x.SourceTypeName, x.TargetTypeName, 
                    x.SelectionCount + y, x.QueueLength, x.EmissionCount, x.Duration);

        public static FlowMetrics operator + (FlowMetrics x, EmissionCount y) 
            => new FlowMetrics(x.SourceTypeName, x.TargetTypeName, x.SelectionCount,
                    x.QueueLength, x.EmissionCount + y, x.Duration);

        public static FlowMetrics operator + (FlowMetrics x, QueueLength y) 
            => new FlowMetrics(x.SourceTypeName, x.TargetTypeName, x.SelectionCount, 
                    y, x.EmissionCount,x.Duration);

        public static FlowMetrics operator +(FlowMetrics x, TimeSpan y) 
            => new FlowMetrics(x.SourceTypeName, x.TargetTypeName, x.SelectionCount, 
                x.QueueLength, x.EmissionCount, x.Duration + y);

        public FlowMetrics(string SourceTypeName, string TargetTypeName, SelectionCount SelectionCount = null,
            QueueLength QueueLength = null, EmissionCount EmissionCount = null, TimeSpan? Duration = null)
        {

            this.SourceTypeName = SourceTypeName;
            this.TargetTypeName = TargetTypeName;
            this.SelectionCount = SelectionCount ?? new SelectionCount();
            this.QueueLength = QueueLength ?? new QueueLength();
            this.EmissionCount = EmissionCount ?? new EmissionCount();
            this.Duration = Duration ?? TimeSpan.Zero;
        }

        public TimeSpan Duration { get; }

        public string SourceTypeName { get; }

        public string TargetTypeName { get; }

        public SelectionCount SelectionCount { get; }

        public QueueLength QueueLength { get; }

        public EmissionCount EmissionCount { get; }
    }
}
