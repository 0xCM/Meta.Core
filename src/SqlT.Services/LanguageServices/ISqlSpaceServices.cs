//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Reflection;

    using Meta.Core;


    public interface ISqlSpaceServices
    {
        Option<NodeFilePath> ReifyModel(Assembly a, NodeFilePath DacPath);
    }



}