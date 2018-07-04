//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Meta.Models;
    using SqlT.Core;

    using static metacore;
    using sxc =  contracts;

    public class oisect<k1,k2,k3> : oisect<k1,k2>
        where k1 : IModel
        where k2 : IModel
        where k3 : IModel
    {

        public oisect
        (
            k1 v1 = default, 
            k2 v2 = default, 
            k3 v3 = default
        )
            : base(v1,v2)        
        {
            this.v3 = v3;
        }

        public ModelOption<k3> v3 { get; }

        public override IEnumerable<IModel> components
        {
            get
            {
                foreach (var value in base.components)
                    yield return value;

                if (v3)
                    yield return (k3)v3;
            }
        }
    }

    public class cocisect<k,k1,k2,k3> : isect<k1,k2,k3>
        where k : IModel
        where k1: k
        where k2: k
        where k3: k
    {
        public cocisect(k1 v1, k2 v2, k3 v3)
            : base(v1,v2,v3)
        {

        }

    }



}