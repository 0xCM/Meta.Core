//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


/// <summary>
/// Specifies the name of a member-defined operator
/// </summary>
public class ClrMemberOperatorName : ClrMemberName<ClrMemberOperatorName>
{
    public static readonly ClrMemberOperatorName Anonymous 
        = new ClrMemberOperatorName(ClrItemIdentifier.Missing);

    public static implicit operator ClrMemberOperatorName(ClrItemIdentifier x)
        => new ClrMemberOperatorName(x);

    public static implicit operator ClrMemberOperatorName(string x)
        => new ClrMemberOperatorName(x);

    public ClrMemberOperatorName(ClrItemIdentifier Identifier)
        : base(Identifier)
    { }
}






