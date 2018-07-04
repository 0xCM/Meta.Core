﻿//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Vocabulary
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;


    /// <summary>
    /// Identifies a monadic model factory, i.e. a function that creates a mondadic builder
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MonadicBuilderFactoryAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Class)]
    public class MonadicBuilderFactoryHostAttribute : Attribute
    {

    }
}