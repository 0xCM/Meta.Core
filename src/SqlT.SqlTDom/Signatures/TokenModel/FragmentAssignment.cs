//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Services;
    
    class FragmentAssignment : AssignmentToken<FragmentAssignment>
    {

        public static implicit operator string(FragmentAssignment token)
            => token.Format();

        public FragmentAssignment(ClrProperty Property, FragmentToken Fragment, int Level)
            : base(Property, Level)
        {
            this.Fragment = Fragment;
        }


        public FragmentToken Fragment { get; }

        public override string ToString()
            => this.Format();

    }

    class FragmentAssignments : TypedItemList<FragmentAssignments, FragmentAssignment>
    {

        public override string ToString()
            => this.Count != 0 
            ?  this.Format(this.FirstOrDefault().TokenLevel) 
            : string.Empty;

    }

}
