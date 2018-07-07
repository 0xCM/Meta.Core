//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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