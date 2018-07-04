//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Patterns
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Models;
    using sxc = SqlT.Syntax.contracts;



    public abstract class CreateProcedure<M> : CreateObject<M, SqlProcedure, SqlProcedureName>
        where M : CreateProcedure<M>
    {

        
        void SetDefaults()
        {
            TransactionAbort = true;
            NoCount = true;
        }

        protected IList<sxc.statement> Statements { get; } 
            = new List<sxc.statement>();

        protected CreateProcedure()
        {
            SetDefaults();
        }

        protected CreateProcedure(SqlProcedureName Name)
            : base(Name)
        {
            SetDefaults();

        }

        public bool TransactionAbort { get; set; }

        public bool NoCount { get; set; }

        /// <summary>
        /// True if body of procedure will be enclosed within a begin/commit transaction block
        /// </summary>
        public bool EnclosingTransaction { get; set; }

        
    }
}
