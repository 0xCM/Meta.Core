namespace SqlT.SqlSystem.SQL14.sys
{

    public partial class extended_properties : IExtendedProperty
    {
        public override string ToString() 
            => $"{name} = {value}";
    }
}