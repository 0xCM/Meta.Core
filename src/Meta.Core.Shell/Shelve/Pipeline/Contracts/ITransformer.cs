//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public interface ITransformer
    {
        object Transform(object item);

        Seq<object> Transform(Seq<object> items);
    }

    public interface ITransformer<X,Y> : ITransformer
    {
        Y Transform(X item);

        Seq<Y> Transform(Seq<X> items);
    }

}