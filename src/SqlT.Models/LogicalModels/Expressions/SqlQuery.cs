//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;
    using SqlT.Syntax;
    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Base type for classes that specify query actions
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    public abstract class SqlQueryAction<T> : SqlAction<T>, ISyntaxExpression
        where T : SqlQueryAction<T>
    {
        protected SqlQueryAction(params SqlRoutineParameter[] Parameters)
            : base(Parameters)
        {

        }

        protected SqlQueryAction(IName ActionName, params SqlRoutineParameter[] Parameters)
            : base(ActionName, Parameters)
        {

        }
    }

}