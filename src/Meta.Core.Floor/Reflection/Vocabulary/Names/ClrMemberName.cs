//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

/// <summary>
/// Base type for member name specifiers
/// </summary>
public abstract class ClrMemberName<T> : ClrElementName<T>
    where T : ClrMemberName<T>
{
    protected ClrMemberName(params ClrItemIdentifier[] Components)
        : base(Components)
    { }
}

