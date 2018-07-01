//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// Identifies the Setoid typeclass
    /// </summary>
    public interface ISetoid : IEq
    {

    }

    /// <summary>
    /// Characterizes the <see cref="ISetoid"/> typeclass
    /// </summary>
    /// <typeparam name="X"></typeparam>
    public interface ISetoid<X> : IEq<X>
    {
        
    }
}