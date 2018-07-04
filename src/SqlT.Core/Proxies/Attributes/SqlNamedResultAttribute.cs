//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlNamedResultAttribute : SqlProxyAttribute
    {
        public SqlNamedResultAttribute()
        {

        }

        public SqlNamedResultAttribute(string ResultName)
        {
            this.ResultName = ResultName;
        }

        public string ResultName
        {
            get { return GetFacetValue<string>(nameof(ResultName)); }
            set { SetFacetValue(nameof(ResultName), value); }
        }

        public override SqlProxyKind ProxyKind 
            => SqlProxyKind.NamedResult;
    }
}