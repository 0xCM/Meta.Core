//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{

    public abstract class ItemGroupMember<E, M> : GroupMember<E, M>
        where E : ItemGroupMember<E, M>
    {
    
        protected ItemGroupMember(string ElementName, M ElementContent, string Label,  string Condition)
            : base(ElementName, ElementContent, Label, Condition)
        {

        }
    }


    public abstract class ItemGroupMember<E> : ItemGroupMember<E, ISymbolicExpression>
        where E : ItemGroupMember<E>
    {
        protected ItemGroupMember(string ElementName, ISymbolicExpression ElementContent, string Label, string Condition)
            : base(ElementName, ElementContent, Label, Condition)
        {
        }
    }



}
