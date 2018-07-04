//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System.Collections.Generic;

    using Meta.Syntax;

    public static partial class contracts
    {

        public interface operator_application : ISyntaxExpression
        {
            IOperator applied_operator { get; }

            IReadOnlyList<ISyntaxExpression> operands { get; }
        }

        public interface operator_application<o> : operator_application
            where o : IOperator
        {
            new o applied_operator { get; }
        }


    }

}