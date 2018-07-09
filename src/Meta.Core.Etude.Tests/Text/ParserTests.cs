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
    using Text;


 
    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/text")]
    public class ParserTests
    {
        [UT.TestMethod]
        public void Test01()
        {

            var input = "15320";
            var parser = Parse.run(Parsers.digit, input);
            

        }

    }

}