//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public interface IMessageStore
{
    void SaveMessages(IEnumerable<IApplicationMessage> messages);
}
