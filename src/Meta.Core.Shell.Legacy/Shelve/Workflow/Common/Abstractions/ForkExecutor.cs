﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Collections.Generic;
    public abstract class ForkExecutor<S, T> : ConnectorExecutor, IForkExecutor<S, T>
    {
        protected ForkExecutor(string Label = null)
            : base(Label)
        {

        }


        public abstract IEnumerable<T> Flow(IEnumerable<S> input);



    }


}