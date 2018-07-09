//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using SqlT.Models;
    using SqlT.Core;
    using System.Reflection;

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
