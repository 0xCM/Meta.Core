//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL14.sys
{
    using static metacore;


    public partial class procedures : IProcedure
    {

        public procedures(ISystemObject o)
        {
            this.create_date = o.create_date;
            this.modify_date = o.modify_date;
            this.name = o.name;
            this.object_id = o.object_id;
            this.parent_object_id = o.parent_object_id;
            this.principal_id = o.principal_id;
            this.schema_id = o.schema_id;
            this.type = o.type;
            this.type_desc = o.type_desc;
            this.is_ms_shipped = o.is_ms_shipped;

        }

        public bool is_user_defined 
            => not(is_ms_shipped);

        public override string ToString() 
            => name;
    }
}