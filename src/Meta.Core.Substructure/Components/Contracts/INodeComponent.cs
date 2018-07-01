//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using N = SystemNode;

public interface INodeComponent : IApplicationComponent
{

    N Host { get; }

}
