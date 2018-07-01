//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------

public interface ICompositionRoot : IApplicationContext
{
    void Initialized(IApplicationContext context);
}
