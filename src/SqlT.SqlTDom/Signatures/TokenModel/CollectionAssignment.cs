//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    class CollectionAssignment : AssignmentToken<CollectionAssignment>
    {

        public static implicit operator string(CollectionAssignment token)
            => token.Format();

        public CollectionAssignment(ClrProperty Property, FragmentTokens Tokens, int Level)
            : base(Property, Level)
        {
            this.Tokens = Tokens;
        }

        public FragmentTokens Tokens { get; }


        public override string ToString()
            => this.Format();

    }

    class CollectionAssignments : TypedItemList<CollectionAssignments, CollectionAssignment>
    {

        public override string ToString()
            => this.Count != 0
            ? this.Format(this.FirstOrDefault().TokenLevel)
            : string.Empty;

    }

}
