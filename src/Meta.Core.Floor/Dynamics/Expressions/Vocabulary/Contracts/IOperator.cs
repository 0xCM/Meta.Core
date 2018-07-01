//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    public interface IOperator
    {
        string Name { get; }

        string Symbol { get; }

        IOperatorApplication Apply(params object[] args);

        string FormatApply(params object[] args);
    }





}