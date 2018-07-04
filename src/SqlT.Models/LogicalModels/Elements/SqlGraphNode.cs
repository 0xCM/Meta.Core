//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    


    public class SqlSyntaxGraphContext
    {
        public SqlSyntaxGraphContext IncrementPosition()
        {
            NodePosition = NodePosition + 1;
            return this;

        }

        public int NodePosition { get; private set;}
    }


    public class SqlSyntaxGraphNode
    {


        public SqlSyntaxGraphNode
        (
            SqlSyntaxGraphContext Context,
            object NodeValue, 
            string NodeText, 
            IReadOnlyList<string> Tokens
        )
        {
            this.Context = Context.IncrementPosition();
            this.NodeValue = NodeValue;
            this.NodeText = NodeText;
            this.Tokens = Tokens;            
            
        }

        public SqlSyntaxGraphContext Context { get; }

        public object NodeValue { get; }


        public string NodeText { get; }

        public IReadOnlyList<string> Tokens { get; }


        public int NodePostion
            => Context.NodePosition;

        public string NodeTypeName
            => NodeValue.GetType().Name;

        public string Label
            => $"{NodePostion.ToString().PadLeft(4, '0')}| {NodeTypeName}";

        public string Identifier
            => $"{NodePostion.ToString().PadLeft(4, '0')}_{NodeTypeName}";

        public override string ToString()
            => $"{Label} := {NodeText}";
    }


    public class SqlSyntaxGraph : IReadOnlyList<SqlSyntaxGraphNode>
    {

        public static implicit operator SqlSyntaxGraph(ReadOnlyList<SqlSyntaxGraphNode> src)
            => new SqlSyntaxGraph(src);

        public static implicit operator ReadOnlyList<SqlSyntaxGraphNode>(SqlSyntaxGraph src)
            => src.Nodes;

        readonly ReadOnlyList<SqlSyntaxGraphNode> Nodes;
        
        public SqlSyntaxGraph(IEnumerable<SqlSyntaxGraphNode> Nodes)
            => this.Nodes = Nodes.OrderBy(x => x.NodePostion).ToReadOnlyList();

        public SqlSyntaxGraphNode this[int index] 
            => Nodes[index];

        public int Count
            => Nodes.Count;

        IEnumerator<SqlSyntaxGraphNode> IEnumerable<SqlSyntaxGraphNode>.GetEnumerator()
            => Nodes.GetEnumerator();
        
        IEnumerator IEnumerable.GetEnumerator()
            => Nodes.GetEnumerator();

    }

}
