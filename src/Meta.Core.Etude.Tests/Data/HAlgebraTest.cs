//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using static metacore;
    using static etude;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class HAlgebraTest
    {

        /*
        -- | - Implication:
        -- |   - ``a `implies` a = tt``
        -- |   - ``a && (a `implies` b) = a && b``
        -- |   - ``b && (a `implies` b) = b``
        -- |   - ``a `implies` (b && c) = (a `implies` b) && (a `implies` c)``
        */

        [UT.TestMethod]
        public void HAlgebraImplication()
        {
            var ha = HAlgebra.@bool();

            //a `implies` a = tt
            claim.@true(ha.implies(true, true));
            claim.@true(ha.implies(false, false));

            //a && (a `implies` b) = a && b
            claim.equal(ha.conj(true, ha.implies(true, true)), ha.conj(true, true));
            claim.equal(ha.conj(true, ha.implies(true, false)), ha.conj(true, false));
            claim.equal(ha.conj(false, ha.implies(false, true)), ha.conj(false, true));

            //b && (a `implies` b) = b
            claim.@false(ha.conj(false, ha.implies(true, false)));
            claim.@true(ha.conj(true, ha.implies(false, true)));

            //a `implies` (b && c) = (a `implies` b) && (a `implies` c)
            var evaluator = func(((bool a, bool b, bool c) x)  
                => ha.implies(x.a, ha.conj(x.b, x.c)) 
                == ha.conj(ha.implies(x.a, x.b), ha.implies(x.a, x.c)));

            var triples = from a in list(true, false)
                         from b in list(true, false)
                         from c in list(true, false)
                         select (a, b, c);
            var evaluations = map(triples, t => t > evaluator);
            claim.allTrue(evaluations);

        }

    }

}