//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using SqlT.Models;

    using SqlT.Services;

    using static metacore;


    public static class ServiceFactory
    {

        public static ISqlGenerationContext SqlGenerationContext(this IApplicationContext C, params SqlOptionValue[] options)
            => new SqlGenerationContext(C, options);
    }

}