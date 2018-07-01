﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Tests
{
    using System;
    using System.Linq;

    using Meta.Core;
    
    using operators = operators;
    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass]
    public class TupleMatchTest
    {     

        [UT.TestMethod]
        public void Test01()
        {
            var match = ~  from builder in Switch.build<int, int, int>()
                           from x1 in builder.Case((3, 4), operators.add)
                           from x2 in builder.Case((5, 6), operators.sub)
                           from x3 in builder.Case((3, 2), operators.mul)
                           from x4 in builder.Case((1, 1), operators.div)
                           select builder.Evaluator((x, y) => 0);

            claim.equal(match(3, 4), 7);
            claim.equal(match(5, 6), -1);
            claim.equal(match(15, 7), 0);
        }

    }
}