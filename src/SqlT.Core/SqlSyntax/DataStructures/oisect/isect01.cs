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

    public class oisect<k1>
        where k1 : IModel
    {
        public static implicit operator oisect<k1>(k1 v1)
            => new oisect<k1>(v1);


        public oisect(k1 v1 = default)

        {
            this.v1 = v1;
        }

        public ModelOption<k1> v1 { get; }

        public virtual IEnumerable<IModel> components
        {
            get
            {
                if (v1)
                    yield return (k1)v1;
            }
        }

        public override string ToString()
            => join("&", components);

    }

    public class ocisect<k,k1> : isect<k1>
        where k : IModel
        where k1: k
    {
        public ocisect(k1 v1)
            : base(v1)
        {

        }

    }



}