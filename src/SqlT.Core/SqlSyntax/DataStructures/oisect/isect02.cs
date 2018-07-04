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

    public class oisect<k1,k2> : oisect<k1>
        where k1 : IModel
        where k2 : IModel
    {

        public oisect(k1 v1 = default, k2 v2 = default)
            : base(v1)        
        {
            this.v2 = v2;
        }

        public ModelOption<k2> v2 { get; }

        public override IEnumerable<IModel> components
        {
            get
            {
                foreach (var value in base.components)
                    yield return value;

                if (v2)
                    yield return (k2)v2;
            }
        }


    }

    public class ocisect<k,k1,k2> : isect<k1,k2>
        where k : IModel
        where k1: k
        where k2: k
    {
        public ocisect(k1 v1, k2 v2)
            : base(v1,v2)
        {

        }

    }



}