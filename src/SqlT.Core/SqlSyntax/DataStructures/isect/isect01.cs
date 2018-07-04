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

    public class isect<k1> 
        where k1 : IModel
    {
        public static implicit operator isect<k1>(k1 v1)
            => new isect<k1>(v1);

        public isect(k1 v1)
        
        {
            this.v1 = v1;
        }

        public k1 v1 { get; }

        public virtual IEnumerable<IModel> components
            => stream<IModel>(v1);

        public override string ToString()
            => join("&", components);

    }

    public class cisect<k,k1> : isect<k1>
        where k : IModel
        where k1: k
    {
        public cisect(k1 v1)
            : base(v1)
        {

        }

    }



}