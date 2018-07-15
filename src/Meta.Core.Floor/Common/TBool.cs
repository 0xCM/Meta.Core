//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    public readonly struct TriBool : ILabeledUnion<TriBool.LabelType, TriBool>, IEquatable<TriBool>
    {

        public static bool operator ==(TriBool x, TriBool y)
            => x.label == y.label;

        public static bool operator !=(TriBool x, TriBool y)
            => x.label != y.label;


        //public static bool operator true(TBool x)
        //    => x == True;

        public static readonly TriBool Unknown = new TriBool(LabelType.Unknown);
        public static readonly TriBool False = new TriBool(LabelType.False);
        public static readonly TriBool True = new TriBool(LabelType.True);


        TriBool(LabelType label)
        {
            this.label = label;
            this.n = (int)label;
        }

        public int n { get; }

        public LabelType label { get; }

        object IUnion.value
            => n is 0 ? Unknown :
               n is 1 ? False :
               True;

        public Option<TriBool> x1
            => label == LabelType.True
            ? True : label == LabelType.False
            ? False : Unknown;

        public enum LabelType
        {
            Unknown = 0,
            False = 1,
            True = 2
        }

        public override bool Equals(object obj)
            => (obj is TriBool x) ? Equals(x) : false;

        public bool Equals(TriBool other)
            => this.label == other.label;

        public override int GetHashCode()
            => (int)label;
    }


}