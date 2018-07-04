//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlTableFunctionResultAttribute : SqlProxyAttribute
    {
        public SqlTableFunctionResultAttribute()
        {

        }

        public SqlTableFunctionResultAttribute(string SchemaName, string RoutineName)
        {
            this.SchemaName = SchemaName;
            this.FunctionName = RoutineName;
        }

        public string SchemaName
        {
            get { return GetFacetValue<string>(nameof(SchemaName)); }
            set { SetFacetValue(nameof(SchemaName), value); }
        }

        public string FunctionName
        {
            get { return GetFacetValue<string>(nameof(FunctionName)); }
            set { SetFacetValue(nameof(FunctionName), value); }
        }


        public override SqlProxyKind ProxyKind
            => SqlProxyKind.TableFunctionResult;

    }


}