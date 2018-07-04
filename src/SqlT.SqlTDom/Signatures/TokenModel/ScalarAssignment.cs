//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using static metacore;
    using System.Collections.Generic;
    using System.Linq;


    sealed class ScalarAssignment : AssignmentToken<ScalarAssignment>
    {

        public static implicit operator string(ScalarAssignment token)
            => token.ToString();

        public ScalarAssignment(ClrProperty Property, object Value, int Level)
            : base(Property, Level)
        {
            this.Value = Value;


        }

        public object Value { get; }

        public override string ToString()
            => this.Format();
    }

    class ScalarAssignments : TypedItemList<ScalarAssignments, ScalarAssignment>
    {

        public override string ToString()
            => this.Count != 0
            ? this.Format(this.FirstOrDefault().TokenLevel)
            : string.Empty;

    }

}
