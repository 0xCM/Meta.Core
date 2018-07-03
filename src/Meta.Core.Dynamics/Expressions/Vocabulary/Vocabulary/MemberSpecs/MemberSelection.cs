//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class MemberSelection : IEnumerable<SelectedMember>
    {

        public MemberSelection(IEnumerable<SelectedMember> selections)
        {
            Selections = selections.OrderBy(item => item.Order).ToList();
        }

        IReadOnlyList<SelectedMember> Selections { get; }

        IEnumerator<SelectedMember> IEnumerable<SelectedMember>.GetEnumerator()
            =>Selections.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Selections.GetEnumerator();
        
    }



}