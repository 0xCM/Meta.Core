//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using Meta.Core.Build;

    public abstract class PropertyGroupMember<E, M> : GroupMember<E,M>
        where E : PropertyGroupMember<E, M>
    {
        protected PropertyGroupMember(string ElementName, M ElementContent, string Label, string Condition)
            : base(ElementName, ElementContent, Label, Condition)
        {

        }

    }


    public abstract class PropertyGroupMember<M> : PropertyGroupMember<M,ISymbolicExpression>
        where M : PropertyGroupMember<M>
    {

        protected PropertyGroupMember(string ElementName, ISymbolicExpression ElementContent, string Label, string Condition)
            : base(ElementName, ElementContent, Label, Condition)
        {
        }

        protected PropertyGroupMember(SymbolicVariable Value, string Label, string Condition)
            : base(Value.VariableName, Value, Label, Condition)
        {
        }

    }



}
