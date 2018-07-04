//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    public abstract class SqlObjectAttribute : SqlProxyAttribute
    {
        protected SqlObjectAttribute()
        {

        }

        protected SqlObjectAttribute(string SchemaName, string Name)
        {
            this.SchemaName = SchemaName;
            this.ObjectName = Name;
        }

        public string SchemaName
        {
            get { return GetFacetValue<string>(nameof(SchemaName)); }
            set { SetFacetValue(nameof(SchemaName), value); }
        }

        public string ObjectName
        {
            get { return GetFacetValue<string>(nameof(ObjectName)); }
            set { SetFacetValue(nameof(ObjectName), value); }
        }
    }

    

}