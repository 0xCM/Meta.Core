//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    public class SqlParameterAttribute : SqlProxyAttribute
    {
        public SqlParameterAttribute()
        {

        }

        public SqlParameterAttribute(string ParameterName, int Position, bool IsStructured = false, bool IsOutput = false)
        {
            this.ParameterName = ParameterName;
            this.Position = Position;
            this.IsStructured = IsStructured;
            this.IsOutput = IsOutput;
           
        }

        public string ParameterName
        {
            get { return GetFacetValue<string>(nameof(ParameterName)); }
            set { SetFacetValue(nameof(ParameterName), value); }
        }

        public int Position
        {
            get { return GetFacetValue<int>(nameof(Position)); }
            set { SetFacetValue(nameof(Position), value); }
        }

        public bool IsStructured
        {
            get { return GetFacetValue<bool>(nameof(IsStructured)); }
            set { SetFacetValue(nameof(IsStructured), value); }
        }

        public bool IsOutput
        {
            get { return GetFacetValue<bool>(nameof(IsOutput)); }
            set { SetFacetValue(nameof(IsOutput), value); }
        }

        public override SqlProxyKind ProxyKind 
            => SqlProxyKind.Parameter;

        public override string ToString()
            => ParameterName;

    }
}