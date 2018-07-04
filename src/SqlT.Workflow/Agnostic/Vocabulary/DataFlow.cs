//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;

    using static metacore;

    public class DataFlow : DataTransformer
    {
        public static DataFlow<S, T> Define<S, T>(IDataSource<S> Source, IDataTarget<T> Target, Func<S, T> Transform, TransformationName Name = null)
            => new DataFlow<S, T>(Source, Target, Transform, Name);

        protected DataFlow(IDataSource Source, IDataTarget Target, TransformationName Name)
            : base(Name, Source, Target)
        {
        
        }
       

    }

    public class DataFlow<S, T> : DataFlow, IDataFlow<S, T>
    {
        
        

        public DataFlow(IDataSource<S> Source, IDataTarget<T> Target, Func<S,T> Transform = null, TransformationName Name = null)
            : base(Source,Target,Name)
        {
            this.Source = Source;
            this.Target = Target;
            this.Transform = Transform;
        }


        
        protected virtual Func<S,T> Transform { get; }            

        public void Start()
        {
            foreach(var batch in Source.Batch(DefaultBatchSize))
            {
                Target.Receive(map(batch, Transform));
                            
            }
        }

        public int DefaultBatchSize { get; } = 5000;


        public IDataSource<S> Source { get; }

        public IDataTarget<T> Target { get; }

    }




}
