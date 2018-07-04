//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using SqlT.Core;
    using System.Collections.Generic;

    public static partial class contracts
    {

        public interface proxy_function_call<F, R> : function_call, proxy_expression<R>
           where F : function<R>
           where R : ISqlTabularProxy
        {


        }


    }

}