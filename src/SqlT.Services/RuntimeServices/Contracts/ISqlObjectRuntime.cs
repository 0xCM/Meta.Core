//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using SqlT.Core;

    public interface ISqlObjectRuntime : ISqlElementRuntime
    {
        Option<SqlBooleanValue> Exists();
    }

}