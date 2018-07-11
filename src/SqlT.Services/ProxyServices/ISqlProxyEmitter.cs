//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Linq;

    using static metacore;

    public interface ISqlProxyEmitter<F,TResult>
        where F : class, ISqlTableFunctionProxy<F, TResult>, new()
        where TResult : class, ISqlTabularProxy, new()

    {

        Option<FilePath> EmitFile(F proxy, FilePath DstFile);

    }


}