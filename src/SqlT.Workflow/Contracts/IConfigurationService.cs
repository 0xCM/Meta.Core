//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License:MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{

    using SqlT.Core;

    public interface IConfigurationService : INodeService
    {


    }

    public interface IConfigurationService<T> : IConfigurationService
        where T : class, ISqlTableTypeProxy, new() 
    {
        T ReadConfiguration();

        Option<int> WriteConfiguration(T Configuration);
    }
}