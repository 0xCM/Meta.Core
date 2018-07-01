//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    public interface IBinaryOperator : IOperator
    {
        IOperatorApplication Apply(object Left, object Right);
    }


    public interface IBinaryOperator<T>
    {
        T Apply(T x, T y);
    }

    public interface IBinaryPredicate<T>
    {
        bool Apply(T x, T y);
    }

}