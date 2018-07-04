//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{

    /// <summary>
    /// Identifies (within some scope) and describes a SQL Element
    /// </summary>
    public class SqlElementDescriptor : ValueObject<SqlElementDescriptor>
    {
        public readonly SqlElementType ElementType;
        public readonly string FullName;

        public SqlElementDescriptor(SqlElementType ElementType, string FullName)
        {
            this.ElementType = ElementType;
            this.FullName = FullName;
        }

        public override string ToString() 
            => $"{FullName} : {ElementType}";
    }
}
