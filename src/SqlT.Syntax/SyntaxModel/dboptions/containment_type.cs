//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{

    using Meta.Models;
    using Meta.Syntax;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = SqlSyntax;

    partial class SqlSyntax
    {

        public sealed class containment_type : cdu<IKeyword, kwt.NONE, kwt.PARTIAL>, sxc.dboption
        {
            public static implicit operator containment_type(kwt.NONE NONE)
                => new containment_type(NONE);

            public static implicit operator containment_type(kwt.PARTIAL PARTIAL)
                => new containment_type(PARTIAL);


            public containment_type(kwt.NONE NONE)
                : base(NONE)
            { }

            public containment_type(kwt.PARTIAL PARTIAL)
                : base(PARTIAL)
            { }
        }

        public sealed class containment_types : SyntaxList<containment_types, containment_type>
        {
            public static readonly containment_type NONE = sx.NONE;
            public static readonly containment_type PARTIAL = sx.PARTIAL;

        }
    }
}