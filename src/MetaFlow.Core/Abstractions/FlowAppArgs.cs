//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;
    

    using static metacore;


    public abstract class FlowAppArgs<Args> : MetaAppArgs<Args>
       where Args : FlowAppArgs<Args>, new()
    {
        public FlowAppArgs()
        {

        }

        public FlowAppArgs(params string[] args)
            : base(args)
        {

        }

    }

    public class FlowAppArgs : FlowAppArgs<FlowAppArgs>
    {
        public FlowAppArgs()
        {

        }

        public FlowAppArgs(params string[] args)
            : base(args)
        {

        }
    }


}