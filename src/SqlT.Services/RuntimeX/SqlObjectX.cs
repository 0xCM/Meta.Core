//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
