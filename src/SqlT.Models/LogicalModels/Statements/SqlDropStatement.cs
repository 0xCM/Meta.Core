//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using sx = SqlT.Syntax.SqlSyntax;
    using SqlT.Syntax;

    /// <summary>
    /// Base type for SQL drop statements
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    /// <typeparam name="E">The type of element the statement is capable of dropping</typeparam>
    public abstract class SqlDropStatement<T,E> : SqlStatement<T>
        where T : SqlDropStatement<T,E>
        where E : SqlElement<E>
    {

        public SqlDropStatement(bool CheckExistence, statement_kind kind)
            : base(sx.DROP, kind)
        {
            this.CheckExistence = CheckExistence;
        }

        /// <summary>
        /// Specifies whether an existence check should be included 
        /// </summary>
        public bool CheckExistence { get; }

    }
}
