//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------

public class ClrMethodDescription : ClrElementDescription<ClrMethodDescription, ClrMethod>
{

    public ClrMethodDescription(ClrMethod Method)
        : base(Method)
    {
        this.Parameters = ClrMethodParameters.Create(Method.Parameters);
        this.DeclaringType = Method.DeclaringType;
    }


    public ClrMethodParameters Parameters { get; }

    public ClrType DeclaringType { get; }

    public ClrMethod Method
        => DescribedElement;

}

