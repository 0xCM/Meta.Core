//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;

    public static partial class contracts
    {

        public interface order_by_expression : ISyntaxExpression
        {
            sort_direction_kind sort_direction { get; }

            string collation_name { get; }
        }

    }

}