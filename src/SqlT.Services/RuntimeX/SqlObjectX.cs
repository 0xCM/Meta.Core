//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using SqlT.Core;

    public static partial class SqlBrokerExtensions
    {
        static readonly string ExistsScript = @"select  
		isnull(
			try_convert(bit, 
				case 
					when object_id('@ObjectName') is not null 
						then 1 
					else 0 
				end), 0) as ObjectExists";

        public static Option<SqlBooleanValue> Exists(this ISqlObjectHandle h)
        {
            var name = h.ElementName.ToString();
            var script = ExistsScript.Replace("@ObjectName", name);
            var result = h.Broker.ExecuteScalarScript<bool>(script);
            return result.TryMapValue(x => x == true ? SqlBooleanValue.True : SqlBooleanValue.False);

        }
    }
}
