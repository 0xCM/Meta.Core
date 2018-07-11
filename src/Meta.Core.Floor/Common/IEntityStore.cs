//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;    

    using static metacore;

    /// <summary>
    /// Defines contract for a URI-based entity respository
    /// </summary>
    public interface IEntityStore 
    {
        Option<T> FindEntity<T>(SystemUri id = null);

        Option<SystemUri> SaveEntity<T>(T Entity, SystemUri id = null);     
    }
}