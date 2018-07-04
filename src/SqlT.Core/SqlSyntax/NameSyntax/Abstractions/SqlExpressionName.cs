//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = Syntax.contracts;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Syntax;


    public abstract class SqlExpressionName<N> : SqlName<N>
       where N : SqlExpressionName<N>, new()

    {

        protected SqlExpressionName(IName name)
            : base(name)
        { }

        protected SqlExpressionName(string name)
            : base(name)
        {

        }

        public SqlExpressionName()
            : this(string.Empty)
        { }

        public override string FullName
            => CreateFullName(false);


        public bool IsSpecified
            => !string.IsNullOrWhiteSpace(FullName);


    }



}