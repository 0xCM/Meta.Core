//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    public interface ISqlDtoServices
    {

        ISqlDataFrame ToFrame(Type DtoType, IEnumerable<object> items, bool PLL = false);

        IEnumerable<T> FromFrame<T>(ISqlDataFrame frame, bool PLL = false)
            where T : new();
        IEnumerable<object> FromFrame(Type DtoType, ISqlDataFrame frame, bool PLL = false);
    }
}