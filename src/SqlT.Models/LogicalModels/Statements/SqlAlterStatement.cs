//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Syntax;

    using sxc = Syntax.contracts;
    using sx = SqlT.Syntax.SqlSyntax;


    public abstract class SqlAlterStatement<E> : SqlStatement<E>, sxc.alter_statement
        where E : SqlAlterStatement<E>
    {
        protected SqlAlterStatement(statement_kind kind)
            : base(sx.ALTER, kind)
        {

        }

    }


    /// <summary>
    /// Base type for SQL alter statements
    /// </summary>
    /// <typeparam name="M">The derived subtype</typeparam>
    /// <typeparam name="L">The type of element the statement is capable of altering</typeparam>
    public abstract class SqlAlterStatement<M,L> : SqlAlterStatement<M>
        where M : SqlAlterStatement<M,L>
        where L : ISqlElement
    {


        protected SqlAlterStatement(statement_kind kind)
            : base(kind)
        {
        
        }

    }

}
