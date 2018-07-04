//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{

    using static metacore;

    using SqlT.Core;


    public sealed class SqlEnumProviderProperty   : SqlCustomProperty<SqlEnumProviderProperty,ClrEnumName>
    {

        public SqlEnumProviderProperty FromValue(object value)
        {
            var enumName = value?.ToString();
            return isBlank(enumName) ? new SqlEnumProviderProperty()
                : new SqlEnumProviderProperty(enumName);


        }

        public SqlEnumProviderProperty(ClrEnumName EnumName)
            : base(SqlPropertyNames.EnumProvider, EnumName)
        { }

        public SqlEnumProviderProperty(string EnumName)
            : base(SqlPropertyNames.EnumProvider, EnumName)
        {

        }

        public SqlEnumProviderProperty()
            : base(SqlPropertyNames.EnumProvider, ClrEnumName.Anonymous)
        {

        }

    }

}