//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using sx = SqlT.Syntax.SqlSyntax;
    using SqlT.Syntax;

    /// <summary>
    /// Base type for SQL drop statement models
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
