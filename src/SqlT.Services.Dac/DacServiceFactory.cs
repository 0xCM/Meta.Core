//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;

    using static metacore;

    public static class DacServiceFactory
    {
        /// <summary>
        /// Retrieves an instance of the <see cref="ISqlPackageManager"/> service from the context
        /// </summary>
        /// <param name="C">The source context</param>
        /// <returns></returns>
        public static ISqlPackageManager SqlPackageManager(this IApplicationContext C)
            => C.Service<ISqlPackageManager>();

    }
}    
