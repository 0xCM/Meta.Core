//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;

    public interface ISqlProcedureProxy : ISqlRoutineProxy
    {

    }

    public interface ISqlProcedureProxy<in P> : ISqlRoutineProxy<P>, ISqlProcedureProxy
    {

    }

    /// <summary>
    /// Contract for procedure proxies that are parameterized by both parameter and result types
    /// </summary>
    /// <typeparam name="P">The parameter type</typeparam>
    /// <typeparam name="TResult">The result type</typeparam>
    public interface ISqlProcedureProxy<in P, out TResult> : ISqlRoutineProxy<P, TResult>, ISqlProcedureProxy
        where TResult : class, new()
        where P : ISqlProcedureProxy
    {


    }

}