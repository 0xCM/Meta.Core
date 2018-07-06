//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;

    using SqlT.Core;
    
    using static metacore;

    using sxc = contracts;

    /// <summary>
    /// Abstract base type for function syntax representations
    /// </summary>
    /// <typeparam name="f"></typeparam>
    public abstract class function<f> : sql_object<f,SqlFunctionName>, sxc.function
        where f : function<f>
    {
        protected function(SqlFunctionName name)
            : base(name)
        {
        }
    } 
}