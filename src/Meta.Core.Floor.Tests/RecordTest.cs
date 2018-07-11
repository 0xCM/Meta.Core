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


    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("meta/floor/records")]
    public class RecordTest
    {
        [UT.TestMethod]
        public void Test01()
        {
            var types = Index.items(MetaFloor.Assembly.GetTypes());
            var outcome = map(types, 
                t => Record.map(
                    t, x => x.Name, 
                    x => x.MemberType, 
                    x => x.UnderlyingSystemType)
                    );

            var expected = types.Select(x =>
                Record.make(x.Name, x.MemberType, x.UnderlyingSystemType));
            claim.equal(outcome, expected);


        }



        [UT.TestMethod]
        public void Test05()
        {
            var types = Index.items(MetaFloor.Assembly.GetTypes());
            var derivation = Record.derive(default(Type), 
                t => t.Name, t => t.MemberType, t => t.UnderlyingSystemType);
            var dataFrame = frame(map(types, t => derivation(t)));

            var expected = frame(types.Select(x =>
                Record.make(x.Name, x.MemberType, x.UnderlyingSystemType)));

            claim.equal(expected, dataFrame);
        }
    }

}