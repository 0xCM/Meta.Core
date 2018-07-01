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

    class PipelineService : Pipeline<object,object>
    {
        public PipelineService(IApplicationContext C, ITransformer Transformer)
            : base(C, Transformer)
        {
            
        }

    }


    class PipelineService<X,Y> : Pipeline<X,Y>
    {
        public PipelineService(IApplicationContext C, ITransformer<X,Y> Transformer)
            : base(C, Transformer)
        {

        }

    }

}