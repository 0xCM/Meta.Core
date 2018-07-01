//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

public interface ILinkedComponent : IApplicationComponent
{
    new ILinkedContext Context { get; }

    NodeLink Link { get; }

}
