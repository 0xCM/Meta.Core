//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// Subsequent Contributors: <NoneYet/>
// QOTD: Measure thrice before you slice to save your head from the dreaded vice
//-------------------------------------------------------------------------------------------
namespace MetaFlow.WF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SqlT.Core;
    using Meta.Core;

    using static metacore;

    class AppArgs : MetaAppArgs<AppArgs>
    {
        public AppArgs()
        {

        }

        public AppArgs(params string[] args)
            : base(args)
        {

        }
    }




}