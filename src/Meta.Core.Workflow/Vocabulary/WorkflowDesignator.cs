//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;    

    /// <summary>
    /// Identifies and describes a transformation workflow
    /// </summary>
    public class WorkflowDesignator
    {
        public static WorkflowDesignator<S, T> Define<S, T>(TransformationName Name)
            => new WorkflowDesignator<S, T>(Name);

        public static WorkflowDesignator<S, T> Compose<S, X, T>(WorkflowDesignator<S, X> Source, WorkflowDesignator<X, T> Target)
            => new WorkflowDesignator<S, T>(new TransformationName(Source.Name, Target.Name));

        public static WorkflowDesignator Define(TransformationName Name, Type SourceType, Type TargetType)
            => new WorkflowDesignator(Name, SourceType, TargetType);

        public static WorkflowDesignator Compose(WorkflowDesignator Source, WorkflowDesignator Target, Type SourceType, Type TargetType)
            => new WorkflowDesignator(new TransformationName(Source.Name, Target.Name), SourceType, TargetType);

        protected WorkflowDesignator(TransformationName Name, Type SourceType, Type TargetType)
        {
            this.Name = Name;
            this.SourceType = SourceType;
            this.TargetType = TargetType;
        }
                                
        /// <summary>
        /// The transformation workflow name
        /// </summary>
        public TransformationName Name { get; }

        /// <summary>
        /// The transformation domain type
        /// </summary>
        public Type SourceType { get; }

        /// <summary>
        /// The transformation codomain type
        /// </summary>
        public Type TargetType { get; }

        public override string ToString()
            => $"{Name}:{SourceType.Name} => {TargetType.Name}";
    }

    public sealed class WorkflowDesignator<S,T>: WorkflowDesignator
    {
        internal WorkflowDesignator(TransformationName Name)
            : base(Name, typeof(S), typeof(T))
        {
            
        }              
    }
}