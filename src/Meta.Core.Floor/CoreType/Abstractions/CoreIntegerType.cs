public abstract class CoreIntegerType<T> : CoreDataType<T>
{
    internal CoreIntegerType(string DataTypeName)
        : base(DataTypeName)
    {

    }

    public override bool IsInteger
        => true;

}
