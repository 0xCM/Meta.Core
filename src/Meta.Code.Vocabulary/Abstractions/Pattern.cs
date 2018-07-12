//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{

    public abstract class Pattern<P>
        where P : Pattern<P>, new()
    {

    }

}