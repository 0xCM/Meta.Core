//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    using System.Collections.Concurrent;

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