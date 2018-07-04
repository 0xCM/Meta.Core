namespace SqlT.SqlSystem.SQL13.sys
{

    public partial class extended_properties : IExtendedProperty
    {
        public override string ToString() 
            => $"{name} = {value}";
    }
}