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

    public readonly struct FactoredTypeInfo
    {
        public FactoredTypeInfo(string TypeName, int ParameterCount)
        {
            this.TypeName = TypeName;
            this.ParameterNames = map(range(1, ParameterCount), i => $"X{i}");
        }

        public FactoredTypeInfo(string TypeName, params string[] ParameterNames)
        {
            this.TypeName = TypeName;
            this.ParameterNames = ParameterNames;
        }

        public string TypeName { get; }

        public Lst<string> ParameterNames { get; }

        public override string ToString()
            => concat($"{TypeName}", angled(join(comma(), ParameterNames.AsArray())));
    }

    public readonly struct TBool : ILabeledUnion<TBool.LabelType, TBool>, IEquatable<TBool>
    {

        public static bool operator ==(TBool x, TBool y)
            => x.label == y.label;

        public static bool operator !=(TBool x, TBool y)
            => x.label != y.label;


        //public static bool operator true(TBool x)
        //    => x == True;

        public static readonly TBool Unknown = new TBool(LabelType.Unknown);
        public static readonly TBool False = new TBool(LabelType.False);
        public static readonly TBool True = new TBool(LabelType.True);

        public LabelType label { get; }

        TBool(LabelType label)
            => this.label = label;

        public Option<TBool> x1
            => label == LabelType.True 
            ? True : label == LabelType.False 
            ? False : Unknown;

        public enum LabelType : sbyte
        {
            False = -1,
            Unknown = 0,
            True = 1
        }

        public override bool Equals(object obj)
            => (obj is TBool x) ? Equals(x) : false;

        public bool Equals(TBool other)
            => this.label == other.label;

        public override int GetHashCode()
            => (int)label;
    }

}