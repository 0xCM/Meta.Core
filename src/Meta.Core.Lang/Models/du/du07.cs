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

    public class du<k1, k2, k3, k4, k5, k6, k7> : du<k1, k2, k3, k4, k5, k6>
        where k1 : IModel
        where k2 : IModel
        where k3 : IModel
        where k4 : IModel
        where k5 : IModel
        where k6 : IModel
        where k7 : IModel
    {

        public static implicit operator du<k1, k2, k3, k4, k5, k6,k7>(k1 v1)
            => new du<k1, k2, k3, k4, k5, k6, k7>(v1);

        public static implicit operator du<k1, k2, k3, k4, k5, k6, k7>(k2 v2)
            => new du<k1, k2, k3, k4, k5, k6, k7>(v2);

        public static implicit operator du<k1, k2, k3, k4, k5, k6, k7>(k3 v3)
            => new du<k1, k2, k3, k4, k5, k6, k7>(v3);

        public static implicit operator du<k1, k2, k3, k4, k5, k6, k7>(k4 v4)
            => new du<k1, k2, k3, k4, k5, k6, k7>(v4);

        public static implicit operator du<k1, k2, k3, k4, k5, k6, k7>(k5 v5)
            => new du<k1, k2, k3, k4, k5, k6, k7>(v5);

        public static implicit operator du<k1, k2, k3, k4, k5, k6, k7>(k6 v6)
            => new du<k1, k2, k3, k4, k5, k6, k7>(v6);

        public static implicit operator du<k1, k2, k3, k4, k5, k6, k7>(k7 v7)
            => new du<k1, k2, k3, k4, k5, k6, k7>(v7);

        protected du()
        {

        }

        protected override IModel selected_value
            => stream<IModelOption>(v1, v2, v3, v4, v5, v6, v7).First(x => x.exists).value;

        public du(k1 v1)
            : base(v1) { }

        public du(k2 v2)
            : base(v2) { }

        public du(k3 v3)
            : base(v3) { }

        public du(k4 v4)
            : base(v4) { }

        public du(k5 v5)
            : base(v5) { }

        public du(k6 v6)
            : base(v6) { }

        public du(k7 v7)
            => this.v7 = v7;

        public ModelOption<k7> v7 { get; }
    }


    public class cdu<k, k1, k2, k3, k4, k5, k6, k7> : du<k1, k2, k3, k4, k5, k6, k7>
        where k : IModel
        where k1 : k
        where k2 : k
        where k3 : k
        where k4 : k
        where k5 : k
        where k6 : k
        where k7 : k
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

        public cdu(k3 v3)
            : base(v3)
        {

        }

        public cdu(k4 v4)
            : base(v4)
        {

        }

        public cdu(k5 v5)
            : base(v5)
        {

        }

        public cdu(k6 v6)
            : base(v6)
        {

        }

        public cdu(k7 v7)
            : base(v7)
        {

        }

        public new k selected_value
            => (k)base.selected_value;
    }
}