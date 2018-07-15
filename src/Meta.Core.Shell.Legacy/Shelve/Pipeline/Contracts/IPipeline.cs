//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface IPipeline
    {

        object Flow(object item);

        Seq<object> Flow(Seq<object> items);
    }

    public interface IPipeline<X, Y> : IPipeline
    {
        Y Flow(X item);

        Seq<Y> Flow(Seq<X> items);
    }
}
