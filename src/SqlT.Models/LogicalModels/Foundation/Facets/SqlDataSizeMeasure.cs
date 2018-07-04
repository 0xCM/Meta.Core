//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public class SqlDataSizeMeasure : ValueObject<SqlDataSizeMeasure>
    {
        public static implicit operator SqlDataSizeMeasure(int x) 
            => new SqlDataSizeMeasure(x);

        public readonly int Value;
        public readonly SqlDataSizeUnit Unit;

        public SqlDataSizeMeasure(int Value, SqlDataSizeUnit Unit = null)
        {
            this.Value = Value;
            this.Unit = Unit ?? SqlDataSizeUnits.MB;
        }

        public override string ToString() 
            => $"{Value}{Unit}";
    }
}
