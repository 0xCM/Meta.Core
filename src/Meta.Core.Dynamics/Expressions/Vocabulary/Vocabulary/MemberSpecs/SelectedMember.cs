//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System.Reflection;


    /// <summary>
    /// Represents a member selection
    /// </summary>
    public class SelectedMember
    {

        public SelectedMember(MemberInfo Member, int Order, string Alias = null)
        {
            this.Member = Member;
            this.Order = Order;
            this.Alias = Alias;
        }

        public MemberInfo Member { get; }

        public int Order { get; }

        public Option<string> Alias { get; }


        public override string ToString()
            => Alias.Map(
                a => $"{Order} {Member.Name} as {a}", 
                () => $"{Order} {Member.Name}");
    }



}