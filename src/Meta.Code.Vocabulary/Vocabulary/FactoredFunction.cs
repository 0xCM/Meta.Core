﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    public class FactoredFunction : FactoredAspect
    {
        public FactoredFunction(string ElementName, int MinFactor, int MaxFactor)
            : base(ElementName, MinFactor, MaxFactor)
        {

        }

        public override string ToString()
            => string.Concat(ElementName, "<", base.ToString(), ">");
    }

}