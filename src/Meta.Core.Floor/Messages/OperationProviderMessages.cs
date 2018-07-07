﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;


    using static metacore;

    static class OperationProviderMessages
    {
        public static IApplicationMessage OperationNameMalformed(string descriptor)
            => error($"The operation name could not be determined from: {descriptor}");

        public static IApplicationMessage ArgumentsMalformed(string descriptor)
            => error($"The arguments could not be determined from: {descriptor}");

        public static IApplicationMessage MethodNotImplemented(string methodName)
            => error($"The method {methodName} is not supported");

        public static IApplicationMessage AmbiguousMatch(string methodName)
            => error($"More than one method is a potential match for {methodName}");

    }
}