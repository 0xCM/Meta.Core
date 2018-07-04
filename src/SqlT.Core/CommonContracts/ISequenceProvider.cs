//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;

    public interface ISequenceProvider
    {
        IEnumerable<T> NextRange<T>(int value);

        T NextValue<T>();
    }
}
