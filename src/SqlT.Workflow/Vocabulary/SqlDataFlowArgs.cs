//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using SqlT.Models;
    using SqlT.Core;
    using Meta.Core.Workflow;

    public abstract class SqlDataFlowArgs<T> : SqlArguments<T>, ISqlDataFlowArgs<T>
        where T : SqlDataFlowArgs<T>, new()
    {


        protected SqlDataFlowArgs(int? BatchSize = null)
        {
            this.BatchSize = BatchSize;
        }

        public int? BatchSize { get; set;  }
    }


    public sealed class SqlDataFlowArgs : SqlDataFlowArgs<SqlDataFlowArgs>
    {
        public static readonly new SqlDataFlowArgs Empty = new SqlDataFlowArgs(null);

        public SqlDataFlowArgs()
            : base(null)
        {


        }

        public SqlDataFlowArgs(int? BatchSize)
            : base(BatchSize)
        {

        }


    }

}