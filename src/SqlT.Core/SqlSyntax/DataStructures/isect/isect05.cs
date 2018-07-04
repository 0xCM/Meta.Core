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

    public class isect<k1,k2,k3,k4,k5> : isect<k1,k2,k3,k4>
        where k1 : IModel
        where k2 : IModel
        where k3 : IModel
        where k4 : IModel
        where k5 : IModel
    {
        public static implicit operator isect<k1, k2,k3,k4,k5>((k1 v1, k2 v2, k3 v3,k4 v4,k5 v5) i)
            => new isect<k1,k2,k3,k4,k5>(i.v1,i.v2,i.v3,i.v4,i.v5);

        public isect(k1 v1, k2 v2, k3 v3, k4 v4, k5 v5)
            : base(v1,v2,v3,v4)        
        {
            this.v5 = v5;
        }

        public k5 v5 { get; }

        public override IEnumerable<IModel> components
            => stream<IModel>(v1,v2,v3,v4,v5);
    }

    public class cisect<k,k1,k2,k3,k4,k5> : isect<k1,k2,k3,k4,k5>
        where k : IModel
        where k1: k
        where k2: k
        where k3: k
        where k4: k
        where k5: k

    {
        public cisect(k1 v1, k2 v2, k3 v3, k4 v4, k5 v5)
            : base(v1,v2,v3,v4,v5)
        {
            
        }
    }

}