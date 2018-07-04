//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using SqlT.Models;
    using sx = Syntax.SqlSyntax;


    partial class SqlProxySyntax
    {

        public abstract class junction_expression<e, p> : proxy_expression<e,p>  
            where e : junction_expression<e, p>
            where p : ISqlTabularProxy, new()
        {

            protected junction_expression(e operand)
                : base(operand)
            {

            }
        }


    }

}
