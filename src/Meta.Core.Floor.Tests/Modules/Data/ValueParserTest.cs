//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using static metacore;
    using static operators;

    using Modules;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("modules/valueparser")]
    public class ValueParserTest
    {

        [UT.TestMethod]
        public void Test01()
        {
            
            claim.satisfies(ValueParser.make<decimal>(), 
                parser => parser.Parse("35.0").Satisfies(d => d == 35.0m));
            
        }

    }

}