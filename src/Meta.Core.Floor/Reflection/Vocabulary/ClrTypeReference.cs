//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------


public abstract class ClrTypeReference<T> : ValueObject<T>
    where T : ClrTypeReference<T>
{

    public ClrTypeReference(IClrTypeName ReferencedType, bool IsNullable = false)
    {
        this.ReferencedType = ReferencedType;
        this.IsNullable = IsNullable;
    }

    public IClrTypeName ReferencedType { get; }

    public bool IsNullable { get; }


    public override string ToString()
        => ReferencedType.SimpleName.ToString();
}

public class ClrTypeReference : ClrTypeReference<ClrTypeReference>
{

    public ClrTypeReference(IClrTypeName ReferencedType, bool IsNullable = false)
        : base(ReferencedType, IsNullable)
    {
        
    }


}




