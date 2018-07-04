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

    public class isect<k1,k2> : isect<k1>
        where k1 : IModel
        where k2 : IModel
    {
        public static implicit operator isect<k1, k2>((k1 v1, k2 v2) i)
            => new isect<k1,k2>(i.v1,i.v2);

        public isect(k1 v1, k2 v2)
            : base(v1)        
        {
            this.v2 = v2;
        }

        public k2 v2 { get; }

        public override IEnumerable<IModel> components
            => stream<IModel>(v1,v2);


    }

    public class cisect<k,k1,k2> : isect<k1,k2>
        where k : IModel
        where k1: k
        where k2: k
    {
        public cisect(k1 v1, k2 v2)
            : base(v1,v2)
        {

        }

    }



}