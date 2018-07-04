//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public interface ISqlRoutineProxy : ISqlObjectProxy
    {

    }

    public interface ISqlRoutineProxy<in P> : ISqlRoutineProxy
    {

    }

    /// <summary>
    /// Contract for routine proxies that are parameterized by both  parameter and result types
    /// </summary>
    /// <typeparam name="P">The parameter type</typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface ISqlRoutineProxy<in P, out TResult> : ISqlRoutineProxy
    {
    }




}