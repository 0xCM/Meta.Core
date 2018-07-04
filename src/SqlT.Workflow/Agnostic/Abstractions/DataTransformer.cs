//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;

    using static metacore;

    public abstract class DataTransformer : IDataTransformer
    {
        IDataSource Source { get; }
        IDataTarget Target { get; }

        public TransformationName Name { get; }



        IDataSource IDataFlow.Source
            => Source;

        IDataTarget IDataFlow.Target
            => Target;

        protected DataTransformer(TransformationName Name, IDataSource Source, IDataTarget Target)
        {
            this.Name = Name;
            this.Source = Source;
            this.Target = Target;
        }



        public override string ToString()
            => $"{Name}:{Source} => {Target}";

    }


    /// <summary>
    /// Represents a tranformation F:X->Y
    /// </summary>
    /// <typeparam name="S">The source node</typeparam>
    /// <typeparam name="T">The target node</typeparam>
    /// <remarks>
    /// A transformation in this context is a function, may/may not be injective/surjective
    /// </remarks>
    public abstract class DataTransformer<S, T> : DataTransformer
    {

        protected DataTransformer(IDataSource<S> Source, IDataTarget<T> Target, string Name = null)
            : base(ifBlank(Name, "F"), Source, Target)
        {
            this.Source = Source;
            this.Target = Target;

        }

        public IDataSource<S> Source { get; }


        public IDataTarget<T> Target { get; }


        public override string ToString()
            => $"{Name}:{Source} => {Target}";

    }



}