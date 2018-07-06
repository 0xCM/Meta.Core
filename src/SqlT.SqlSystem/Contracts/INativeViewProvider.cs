//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System.Collections.Generic;

    using SqlT.SqlSystem;

    public interface INativeViewProvider
    {
        IReadOnlyList<T> GetNativeView<T>() 
            where T : ISystemElement;
    }
}