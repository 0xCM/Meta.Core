//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System.Linq;
using static metacore;

using Meta.Core;

public interface IServiceAgentOptions
{
    Json ToJson();
}




public interface IServiceAgentOptions<O> : IServiceAgentOptions
    where O : IServiceAgentOptions<O>
{

}



