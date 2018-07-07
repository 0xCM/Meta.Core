//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public interface IModelOption : IModel
    {
        bool exists { get; }

        IModel value { get; }
    }


}