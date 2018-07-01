//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public static class UCMemberAssociation
    {
        public class A
        {
            public int P1 { get; }
            public string P2 { get; }
            public DateTime P3 { get; }
            public object P4 { get; }
            public (object x, object y) P5 { get; }
        }

        public class B
        {
            public int P1 { get; }
            public string P2 { get; }
            public DateTime P3 { get; }
        }

        public static MemberAssociationSet<A, B> Associate()
        {
            return MemberAssociationSetBuilder.Build<A, B>()
                        .Associate(
                            (a => a.P1, b => b.P2),
                            (a => a.P3, b => b.P1),
                            (a => a.P5, b => b.P3)
                            );
        }
    }


}
