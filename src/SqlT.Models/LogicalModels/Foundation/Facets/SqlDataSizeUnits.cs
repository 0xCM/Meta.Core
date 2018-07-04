//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public class SqlDataSizeUnits : HostedFieldList<SqlDataSizeUnit, SqlDataSizeUnits>
    {
        public static readonly SqlDataSizeUnit KB = new SqlDataSizeUnit("KB");
        public static readonly SqlDataSizeUnit MB = new SqlDataSizeUnit("MB");
        public static readonly SqlDataSizeUnit GB = new SqlDataSizeUnit("GB");
        public static readonly SqlDataSizeUnit TB = new SqlDataSizeUnit("TB");
    }
}
