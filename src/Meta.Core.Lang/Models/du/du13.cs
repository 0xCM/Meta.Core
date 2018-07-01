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

    public class du<k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, k12, k13> : du<k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11,k12>
        where k1 : IModel
        where k2 : IModel
        where k3 : IModel
        where k4 : IModel
        where k5 : IModel
        where k6 : IModel
        where k7 : IModel
        where k8 : IModel
        where k9 : IModel
        where k10 : IModel
        where k11 : IModel
        where k12 : IModel
        where k13 : IModel

    {

        protected du()
        {

        }

        protected override IModel selected_value
            => stream<IModelOption>(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12).First(x => x.exists).value;

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
            : base(v7) { }

        public du(k8 v7)
            : base(v7) { }

        public du(k9 v9)
            : base(v9) { }

        public du(k10 v10)
            : base(v10) { }

        public du(k11 v11)
            : base(v11) { }

        public du(k12 v12)
             : base(v12) { }

        public du(k13 v13)
             => this.v13 = v13;

        public ModelOption<k13> v13 { get; }
    }


    public class cdu<k, k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, k12, k13> : du<k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, k12, k13>
        where k : IModel
        where k1 : IModel
        where k2 : IModel
        where k3 : IModel
        where k4 : IModel
        where k5 : IModel
        where k6 : IModel
        where k7 : IModel
        where k8 : IModel
        where k9 : IModel
        where k10 : IModel
        where k11 : IModel
        where k12 : IModel
        where k13 : IModel

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

        public cdu(k8 v8)
            : base(v8)
        {

        }

        public cdu(k9 v9)
            : base(v9)
        {

        }

        public cdu(k10 v10)
            : base(v10)
        {

        }

        public cdu(k11 v11)
            : base(v11)
        {

        }

        public cdu(k12 v12)
            : base(v12)
        {

        }

        public cdu(k13 v13)
            : base(v13)
        {

        }

        public new k selected_value
            => (k)base.selected_value;


    }


}