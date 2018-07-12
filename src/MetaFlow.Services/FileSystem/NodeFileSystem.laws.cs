//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Meta.Core;

    using N = SystemNode;

    public interface INodeFileSystem
    {
        T Nav<T>(N Host)
            where T : class, IFileSystemNavigator;

    }





}