//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    public interface IModelList : IModel, IEnumerable
    {
        string delimiter { get; }
    }

    public interface IModelList<m> : IModelList, IEnumerable<m>
        where m : IModel
    {
        IModelList<m> append(params m[] items);

        IModelList<m> prepend(params m[] items);
    }



}