//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    public abstract class FactoredAspect
    {

        protected FactoredAspect()
        {

        }

        protected FactoredAspect(string Elmentname, int MinFactor, int MaxFactor)
        {
            this.ElementName = ElementName;
            this.MinFactor = MinFactor;
            this.MinFactor = MaxFactor;

        }

        public string ElementName { get; set; }

        public int MinFactor { get; set; }

        public int MaxFactor { get; set; }

        public string FactorPrefix { get; set; }
            = "X";

        public IEnumerable<string> FactorNames
            => from i in Enumerable.Range(1, MaxFactor - MinFactor)
               select $"{FactorPrefix}{i}";

        public override string ToString()
            => string.Join(", ", FactorNames);
    }

}