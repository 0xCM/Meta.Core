//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Models
{
    using System;
    using System.Linq;

    using static metacore;


    /// <summary>
    /// Represents a (non-conformed) discriminated union where the encapsulated value must be one of two types
    /// </summary>
    /// <typeparam name="k1">The first potential type of the encapsulated value</typeparam>
    /// <typeparam name="k2">The second potential type of the encapsulated value</typeparam>
    public class du<k1, k2> : du<k1>
        where k1 : IModel
        where k2 : IModel
    {
        public static implicit operator du<k1, k2>(k1 v1)
            => new du<k1, k2>(v1);

        public static implicit operator du<k1, k2>(k2 v2)
            => new du<k1, k2>(v2);

        protected du()
        {

        }

        protected override IModel selected_value
            => stream<IModelOption>(v1, v2).First(x => x.exists).value;

        public du(k1 v1)
            : base(v1) { }


        public du(k2 v2)
            => this.v2 = v2;


        public ModelOption<k2> v2 { get; }


    }

    /// <summary>
    /// Represents a (conformed) discriminated where the encapsulated value must be 
    /// one of two types, each of which specialize a common supertype.
    /// </summary>
    /// <typeparam name="k">The supertype to which conformance is required</typeparam>
    /// <typeparam name="k1">The first potential type of the encapsulated value</typeparam>
    /// <typeparam name="k2">The second potential type of the encapsulated value</typeparam>
    public class cdu<k, k1, k2> : du<k1, k2>
        where k : IModel
        where k1 : k
        where k2 : k
    {

        protected cdu()
        {

        }

        public cdu(k1 v1)
            : base(v1)
        {

        }
        public cdu(k2 v2)
            : base(v2)
        {

        }

        public new k selected_value
            => (k)base.selected_value;


    }


}