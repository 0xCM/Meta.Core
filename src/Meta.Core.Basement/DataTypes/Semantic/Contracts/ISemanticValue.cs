//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public interface ISemanticValue
{
    object Value { get; }
}

public interface ISemanticValue<V> : ISemanticValue
{
    new V Value { get; }
}
