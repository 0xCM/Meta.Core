//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;

    public abstract class DataJoin : DataJunction, IDataJoin
    {
        
        protected DataJoin(Type JunctionType, DataJunctionName Name = null)
            : base(JunctionType, Name)
        {
            
        }

    }


    public abstract class DataJoin<L, R> : DataJoin, IDataJoin<L, R>
        where L : DataSource<L>
        where R : DataSource<R>
    {
        protected DataJoin(DataJunctionName Name, L Left, R Right)
            : base(typeof((L,R)), Name)
        {
            this.Left = Left;
            this.Right = Right;
        }

        protected DataJoin(Type NodeType, DataJunctionName Name, L Left, R Right)
            : base(NodeType, Name)
        {
            this.Left = Left;
            this.Right = Right;
        }

        public L Left { get; }

        public R Right { get; }

    }


    public abstract class JoinNode<L, R, T> : DataJoin<L, R>, IDataJoin<L, R, T>
            where L : DataSource<L>
            where R : DataSource<R>
            where T : DataTarget<T>
    {
        protected JoinNode(DataJunctionName Name, L Left, R Right, T Target)
            : base(typeof((L,R,T)), Name, Left, Right)
        {
            this.Target = Target;
        }


        public T Target { get; }

    }


}
