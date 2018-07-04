//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;
    using sxc = SqlT.Syntax.contracts;
    

    /// <summary>
    /// Base type for classes that specify command actions
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    public abstract class SqlCommandAction<T> : SqlAction<T>, ISqlCommandAction<T>
        where T : ISqlCommandAction, IModel

    {

        protected SqlCommandAction(string ActionName, params SqlRoutineParameter[] Parameters)
            : base(new SqlParameterName(ActionName), Parameters)
        {

        }


    }

}
