//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;


    public abstract class DataFrameRoot<F> : IDataFrameRoot, IEquatable<F>
        where F : DataFrameRoot<F>, new()
    {
        IDataFrame IDataFrameRoot.Construct(IContainer<object[]> data)
            => Construct(data);


        public static bool operator ==(DataFrameRoot<F> x, DataFrameRoot<F> y)
            => x != null ? x.Equals(y) : false;

        public static bool operator !=(DataFrameRoot<F> x, DataFrameRoot<F> y)
            => not(x == y);

        public abstract F Construct(IContainer<object[]> data);

        public bool Equals(F other)
            => other is null ? false
                : ItemArrays.Equals(other.ItemArrays);

        protected DataFrameRoot()
        {
            
        }

        public abstract Seq<Index<object>> ItemArrays { get; }

        public override bool Equals(object obj)
           => (obj is F frame) ? Equals(frame) : false;

        public override int GetHashCode()
            => ItemArrays.GetHashCode();


    }


}