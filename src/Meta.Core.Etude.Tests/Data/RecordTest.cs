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

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class RecordTest
    {

        [UT.TestMethod]
        public void JoinRecords0()
        {
            var c1 = seq(1, 2, 3);
            var c2 = seq(4m, 5m, 6m);
            var c3 = seq(7L, 8L, 9L);
            var records = Record.join(c1, c2, c3).AsList();
            claim.equal(3, records.Count);
            claim.equal(record(2, 5m, 8L), records[1]);
            
        }


        [UT.TestMethod]
        public void JoinRecords1()
        {
            var set1 = map(Synthetics.tuples<int, decimal>((55, 75)).Take(500), t => record(t));
            var set2 = map(Synthetics.tuples<byte, string>((55, 75)).Take(500), t => record(t));            
            var joined = map(Seq.zip(set1, set2), s => join(s.x1, s.x2)).AsList();
            claim.equal(500, joined.Count);
            var frame = DataFrame.make(joined);


        }

        [UT.TestMethod]
        public void CreateRecords1()
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
        public void CreateRecords2()
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