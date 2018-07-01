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


    public class du<k1, k2, k3> : du<k1, k2>
        where k1 : IModel
        where k2 : IModel
        where k3 : IModel
    {

        public static implicit operator du<k1, k2, k3>(k1 v1)
            => new du<k1, k2, k3>(v1);

        public static implicit operator du<k1, k2, k3>(k2 v2)
            => new du<k1, k2, k3>(v2);

        public static implicit operator du<k1, k2, k3>(k3 v3)
            => new du<k1, k2, k3>(v3);


        protected du()
        { }

        protected override IModel selected_value
            => (IModel)stream<IModelOption>(v1, v2, v3).First(x => x.exists).value;

        public du(k1 v1)
            : base(v1) { }

        public du(k2 v2)
            : base(v2) { }

        public du(k3 v3)
            => this.v3 = v3;

        public ModelOption<k3> v3 { get; }

    }

    public class cdu<k, k1, k2, k3> : du<k1, k2, k3>
        where k : IModel
        where k1 : k
        where k2 : k
        where k3 : k
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

        public new k selected_value
            => (k)base.selected_value;


    }

}