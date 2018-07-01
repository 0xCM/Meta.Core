//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
public interface IApplicationComponent
{
    IApplicationContext Context { get; }

    IAssemblyDesignator DefiningAssembly { get; }

    string ComponentName { get; }
}
