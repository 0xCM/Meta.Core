//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Syntax;
    using Meta.Syntax;

    using sxc = Syntax.contracts;

    /// <summary>
    /// Base type for statement models
    /// </summary>
    /// <typeparam name="M"></typeparam>
    public abstract class SqlStatement<M> : SqlModel<M>, sxc.statement
        where M : SqlStatement<M>
    {
        protected SqlStatement(IKeyword designator, statement_kind kind)
        {
            this.statement_designator = designator;
            this.statement_kind = kind;
        }

        public IKeyword statement_designator { get; }

        public statement_kind statement_kind { get; }

    }
}
