//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public interface IMutableContext : IApplicationContext
{

    void InjectService<C>(object service, string ImplementationName = null);

    void ReplaceService<C>(object service, string ImplementationName = null);

    void Register(ServiceDescriptor descriptor);

    void InjectValue(string name, object value);

}
